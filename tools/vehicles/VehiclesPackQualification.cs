using System;
using System.IO;
using System.Linq;
using System.Threading;
using Astra.ContentHub.Editor;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering;

// Copied only into isolated qualification projects by prepare.py.
// No dependency on a Vehicles assembly: this must compile before the pack exists.
public static class VehiclesPackQualification
{
    // JsonUtility serializes a null nested class as an empty object. Omit the
    // optional thumbnail field entirely until a real presentation image exists.
    [Serializable] private sealed class PageWithoutThumbnail { public int schemaVersion = 1; public SummaryWithoutThumbnail[] packs; }
    [Serializable] private sealed class SummaryWithoutThumbnail
    {
        public string id, displayName, description, category, recommendedVersion, manifestUrl, manifestSha256;
        public string[] tags; public long compressedBytes;
    }
    private const string Id = "astra.vehicles";
    private const string BaseUrl = "https://raw.githubusercontent.com/MisterPxl/astra-content/main/";
    private const string ArchiveUrl = "https://github.com/MisterPxl/astra-content/releases/download/vehicles-v1.0.0/astra.vehicles-1.0.0.zip";
    private static string Root => ContentHubSettings.ProjectRoot;
    private static string Catalogue
    {
        get
        {
            var args = Environment.GetCommandLineArgs(); var i = Array.IndexOf(args, "-vehiclesCatalogue");
            if (i < 0 || i + 1 == args.Length) throw new ArgumentException("Missing -vehiclesCatalogue directory");
            return Path.GetFullPath(args[i + 1]);
        }
    }
    private static PackManifest Manifest => ContractValidation.Read<PackManifest>(File.ReadAllText(
        Path.Combine(Catalogue, "manifests/astra.vehicles/1.0.0.json")));
    private static StagedPack Stage() => PackArchive.Extract(
        Path.Combine(Catalogue, "archives/astra.vehicles-1.0.0.zip"), Manifest,
        Path.Combine(Root, "Library/VehiclesPackStage-" + Guid.NewGuid().ToString("N")), CancellationToken.None, true);

    // Explicit test-project setup; not an installation hook and never shipped in the pack.
    public static void Setup()
    {
        var pipeline = AssetDatabase.LoadAssetAtPath<RenderPipelineAsset>("Assets/Settings/PC_RPAsset.asset");
        ContractValidation.Require(pipeline != null, "Missing test-project URP asset.");
        GraphicsSettings.defaultRenderPipeline = pipeline;
        QualitySettings.renderPipeline = pipeline;
        AssetDatabase.SaveAssets();
        Debug.Log("VEHICLES_PROJECT_PREPARED");
    }
    public static void Export()
    {
        var output = Catalogue;
        ContractValidation.Require(!Directory.Exists(output), "Catalogue output already exists.");
        var metadata = ContractValidation.Read<PackMetadata>(File.ReadAllText(Path.Combine(Root, "vehicles-metadata.json")));
        var manifest = PackExporter.Export(Path.Combine(Root, "Assets/AstraContent/astra.vehicles"), metadata,
            ArchiveUrl, Path.Combine(output, "archives"),
            path => metadata.projectPrerequisites.Any(p => p.kind == "package" &&
                path.StartsWith("Packages/" + p.name + "/", StringComparison.Ordinal)), true);
        // Independently repeat the export to detect nondeterministic payload/ZIP output.
        var repeat = PackExporter.Export(Path.Combine(Root, "Assets/AstraContent/astra.vehicles"), metadata,
            manifest.archive.url, Path.Combine(Root, "Library/VehiclesRepeat-" + Guid.NewGuid().ToString("N")),
            path => metadata.projectPrerequisites.Any(p => p.kind == "package" &&
                path.StartsWith("Packages/" + p.name + "/", StringComparison.Ordinal)), true);
        ContractValidation.Require(repeat.archive.sha256 == manifest.archive.sha256, "Export is not reproducible.");
        HashedUrl Write(string relative, object value)
        {
            var path = Path.Combine(output, relative); SafeFiles.WriteJson(path, value);
            return new HashedUrl { url = BaseUrl + relative, sha256 = SafeFiles.Hash(path), bytes = new FileInfo(path).Length };
        }
        var reference = Write("manifests/astra.vehicles/1.0.0.json", manifest);
        var page = Write("catalogs/vehicles-v1/pages/gameplay.json", new PageWithoutThumbnail
        {
            packs = new[] { new SummaryWithoutThumbnail
            {
                id = Id, displayName = metadata.displayName, description = metadata.description,
                category = metadata.category, tags = metadata.tags, recommendedVersion = metadata.version,
                compressedBytes = manifest.archive.bytes, manifestUrl = reference.url, manifestSha256 = reference.sha256
            } }
        });
        var index = Write("catalogs/vehicles-v1/index.json", new CatalogIndex
        {
            schemaVersion = 1, revision = "vehicles-v1", categories = new[] { metadata.category }, pages = new[] { page },
            versions = new[] { new ManifestReference { id = Id, version = metadata.version, url = reference.url,
                sha256 = reference.sha256, bytes = reference.bytes } }
        });
        Write("catalog.json", new CatalogPointer { schemaVersion = 1, revision = "vehicles-v1", indexUrl = index.url, indexSha256 = index.sha256 });
        var staged = Stage();
        var duplicate = UnityContentHost.Installer.Preflight(new[] { staged }, UnityContentHost.ExistingGuidPath, _ => Array.Empty<string>());
        ContractValidation.Require(!duplicate.CanImport, "Import over the author sources must be blocked: " + string.Join("; ", duplicate.Errors));
        Debug.Log("VEHICLES_EXPORTED " + manifest.archive.fileCount + " files, " + manifest.archive.bytes + " bytes, SHA256=" + manifest.archive.sha256);
    }
    public static void VerifyPublic()
    {
        var cacheRoot = Path.Combine(Root, "Library/VehiclesPublic-" + Guid.NewGuid().ToString("N"));
        System.Threading.Tasks.Task.Run(async () =>
        {
            using (var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(45)))
            using (var cache = new ContentCache(cacheRoot, false, TimeSpan.FromSeconds(15)))
            {
                var client = new CatalogClient(cache);
                var catalog = await client.Load(BaseUrl + "catalog.json", timeout.Token);
                ContractValidation.Require(!catalog.Offline && catalog.Search("vehicles").Any(p => p.id == Id),
                    "Public catalogue does not expose Vehicles online.");
                var packs = await client.Resolve(catalog, Id, "1.0.0", timeout.Token);
                ContractValidation.Require(packs.Count == 1 && packs[0].license == "MIT", "Unexpected public pack resolution.");
                var manifest = packs[0];
                var archive = await cache.Fetch(manifest.archive.url, manifest.archive.sha256, manifest.archive.bytes, timeout.Token);
                PackArchive.Extract(archive, manifest, Path.Combine(cacheRoot, "stage"), timeout.Token);
            }
        }).GetAwaiter().GetResult();
        Debug.Log("VEHICLES_PUBLIC_VERIFIED catalogue, resolution, HTTPS download and archive integrity via the real Hub client.");
    }
    public static void Generate()
    {
        Setup();
        var type = AppDomain.CurrentDomain.GetAssemblies().Select(a => a.GetType("Motion.Vehicles.Boat.Editor.ArcadeBoatAssetsCreator"))
            .First(t => t != null);
        type.GetMethod("CreateAssets").Invoke(null, null);
        // Remove obsolete embedded MonoScript objects by saving loaded scenes.
        const string root = "Assets/AstraContent/astra.vehicles";
        foreach (var path in Directory.GetFiles(Path.Combine(Root, root), "*.unity", SearchOption.AllDirectories))
        {
            var scene = EditorSceneManager.OpenScene(path.Substring(Root.Length + 1));
            foreach (var obj in scene.GetRootGameObjects()) CheckObjects(obj);
            EditorSceneManager.SaveScene(scene);
        }
        AssetDatabase.SaveAssets();
        Debug.Log("VEHICLES_GENERATED");
    }
    private static void CheckReferences(UnityEngine.Object obj)
    {
        var serialized = new SerializedObject(obj);
        var property = serialized.GetIterator();
        while (property.Next(true))
            if (property.propertyType == SerializedPropertyType.ObjectReference)
                ContractValidation.Require(property.objectReferenceValue != null || property.objectReferenceInstanceIDValue == 0,
                    "Broken reference on " + obj.name + ": " + property.propertyPath);
    }
    private static void CheckObjects(GameObject root)
    {
        ContractValidation.Require(root != null, "Missing root/prefab");
        foreach (var transform in root.GetComponentsInChildren<Transform>(true))
        {
            ContractValidation.Require(GameObjectUtility.GetMonoBehavioursWithMissingScriptCount(transform.gameObject) == 0,
                "Missing script on " + transform.name);
            foreach (var component in transform.GetComponents<Component>()) CheckReferences(component);
        }
    }
    public static void MissingPrerequisites()
    {
        var before = PackageHashes();
        var plan = UnityContentHost.Installer.Preflight(new[] { Stage() }, UnityContentHost.ExistingGuidPath, UnityContentHost.Prerequisites);
        ContractValidation.Require(!plan.CanImport && plan.Errors.Any(e => e.Contains("com.unity.inputsystem")) &&
            plan.Errors.Any(e => e.Contains("com.unity.render-pipelines.universal")) &&
            plan.Errors.Any(e => e.Contains("render pipeline")) &&
            plan.Errors.Any(e => e.Contains("Active Input Handling")), "Missing packages/pipeline/input backend must block import.");
        ContractValidation.Require(!Directory.Exists(Path.Combine(Root, "Assets/AstraContent")) && before == PackageHashes(), "Rejected preflight changed consumer.");
        Debug.Log("VEHICLES_MISSING_PREREQUISITES_VERIFIED");
    }
    private static string PackageHashes() => SafeFiles.Hash(Path.Combine(Root, "Packages/manifest.json")) + ":" +
        SafeFiles.Hash(Path.Combine(Root, "Packages/packages-lock.json"));
    public static void Import()
    {
        File.WriteAllText(Path.Combine(Root, "Library/vehicles-packages-before.txt"), PackageHashes());
        var staged = Stage();
        AssetDatabase.DisallowAutoRefresh();
        try
        {
            AssetDatabase.StartAssetEditing();
            try { UnityContentHost.Installer.Commit(new[] { staged }, UnityContentHost.ExistingGuidPath, UnityContentHost.Prerequisites, CancellationToken.None); }
            finally { AssetDatabase.StopAssetEditing(); }
        }
        finally { AssetDatabase.AllowAutoRefresh(); }
        ContractValidation.Require(UnityContentHost.Installer.Pending()?.state == "AwaitingUnityImport", "Missing durable import journal.");
        AssetDatabase.Refresh(); Debug.Log("VEHICLES_IMPORT_COPY_READY");
    }
    public static void Verify()
    {
        var installer = UnityContentHost.Installer;
        if (installer.Pending() != null) installer.FinalizeImport(UnityContentHost.ExistingGuidPath, EditorUtility.scriptCompilationFailed);
        var receipt = installer.Receipt(Id);
        ContractValidation.Require(receipt?.state == "Imported" && receipt.contentDependencies.Length == 0 && installer.Pending() == null,
            "Single-pack receipt did not finalize cleanly.");
        ContractValidation.Require(PackageHashes() == File.ReadAllText(Path.Combine(Root, "Library/vehicles-packages-before.txt")), "Hub modified UPM files.");
        var packRoot = "Assets/AstraContent/" + Id + "/";
        foreach (var file in receipt.files.Where(f => f.path.EndsWith(".cs", StringComparison.Ordinal)))
            ContractValidation.Require(AssetDatabase.LoadAssetAtPath<MonoScript>(packRoot + file.path) != null, "Missing script " + file.path);
        foreach (var file in receipt.files.Where(f => f.path.EndsWith(".mat", StringComparison.Ordinal)))
        {
            var material = AssetDatabase.LoadAssetAtPath<Material>(packRoot + file.path);
            ContractValidation.Require(material != null && material.shader != null && material.shader.name != "Hidden/InternalErrorShader", "Missing material/shader: " + file.path);
        }
        var prefabs = Directory.GetFiles(Path.Combine(Root, packRoot), "*.prefab", SearchOption.AllDirectories);
        ContractValidation.Require(prefabs.Length == 8, "Expected all eight vehicle prefabs.");
        foreach (var prefab in prefabs)
            CheckObjects(AssetDatabase.LoadAssetAtPath<GameObject>(prefab.Substring(Root.Length + 1)));
        foreach (var scenePath in Directory.GetFiles(Path.Combine(Root, packRoot), "*.unity", SearchOption.AllDirectories))
        {
            var scene = EditorSceneManager.OpenScene(scenePath.Substring(Root.Length + 1));
            foreach (var obj in scene.GetRootGameObjects()) CheckObjects(obj);
        }
        foreach (var path in Directory.GetFiles(Path.Combine(Root, packRoot), "*.asset", SearchOption.AllDirectories))
        {
            var asset = AssetDatabase.LoadMainAssetAtPath(path.Substring(Root.Length + 1));
            ContractValidation.Require(asset != null, "Unreadable asset: " + path);
            CheckReferences(asset);
        }
        var guids = Directory.GetFiles(Path.Combine(Root, "Assets"), "*.meta", SearchOption.AllDirectories).Select(SafeFiles.GuidFromMeta).ToArray();
        ContractValidation.Require(guids.Distinct().Count() == guids.Length, "Duplicate GUIDs in consumer.");
        Debug.Log("VEHICLES_IMPORT_VERIFIED " + receipt.files.Length + " files; scene, scripts, materials, GUIDs and unchanged UPM files.");
    }
}

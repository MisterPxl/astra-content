using System.Collections;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
#endif

public class VehiclesPlayModeTests
{
#if UNITY_EDITOR
    private const string Root = "Assets/AstraContent/astra.vehicles/Demo/";
    [UnityTest]
    public IEnumerator AllPrefabsSurvivePhysicsAndReload()
    {
        var paths = AssetDatabase.FindAssets("t:Prefab", new[] { Root.TrimEnd('/') })
            .Select(AssetDatabase.GUIDToAssetPath).OrderBy(p => p).ToArray();
        Assert.AreEqual(8, paths.Length);
        foreach (var path in paths)
        {
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            var instance = Object.Instantiate(prefab, new Vector3(0, 100, 0), Quaternion.identity);
            instance.SetActive(true);
            var body = instance.GetComponent<Rigidbody>();
            Assert.IsNotNull(body, path);
            foreach (var transform in instance.GetComponentsInChildren<Transform>(true))
                Assert.AreEqual(0, GameObjectUtility.GetMonoBehavioursWithMissingScriptCount(transform.gameObject), path);
            for (int frame = 0; frame < 100; frame++) yield return new WaitForFixedUpdate();
            Assert.IsTrue(float.IsFinite(body.position.x) && float.IsFinite(body.position.y) && float.IsFinite(body.position.z), path);
            Assert.IsTrue(float.IsFinite(body.linearVelocity.sqrMagnitude), path);
            Object.Destroy(instance);
            yield return null;
        }
        LogAssert.NoUnexpectedReceived();
    }
    [UnityTest]
    public IEnumerator ThreeDemoScenesRunWithTheirSerializedSettings()
    {
        foreach (var relative in new[] { "Car/CarDemo.unity", "Boat/BoatDemo.unity", "Plane/PlaneDemo.unity" })
        {
            yield return EditorSceneManager.LoadSceneAsyncInPlayMode(Root + relative, new LoadSceneParameters(LoadSceneMode.Single));
            var bodies = Object.FindObjectsByType<Rigidbody>(FindObjectsSortMode.None);
            Assert.IsNotEmpty(bodies, relative);
            for (int frame = 0; frame < 100; frame++) yield return new WaitForFixedUpdate();
            foreach (var body in bodies)
                Assert.IsTrue(float.IsFinite(body.position.sqrMagnitude) && float.IsFinite(body.linearVelocity.sqrMagnitude), relative);
            LogAssert.NoUnexpectedReceived();
        }
    }
#endif
}

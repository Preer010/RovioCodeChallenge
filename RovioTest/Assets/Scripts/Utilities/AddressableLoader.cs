using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableLoader : ScriptableObject
{
    public string prefabAddress;

    public delegate void LoadCompleteCallback(GameObject loadedObject);
    public event LoadCompleteCallback OnLoadComplete;

    public void SpawnPrefab(Vector3 position , Quaternion rotation)
    {
        AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(prefabAddress);

        handle.Completed += (AsyncOperationHandle < GameObject > completedHandle) =>
        {
            OnPrefabLoaded(completedHandle, position, rotation);
        };
    }

    private void OnPrefabLoaded(AsyncOperationHandle<GameObject> handle, Vector3 position, Quaternion rotation)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject instance = Instantiate(handle.Result, position, rotation);
            OnLoadComplete?.Invoke(instance);
        }
        else
        {
            Debug.LogError($"Failed to load prefab: {handle.OperationException}");
        }
        Addressables.Release(handle);
    }

}

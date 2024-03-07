using ModestTree;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField]
    float spawnRate = 1.0f;

    [SerializeField]
    string prefabPath = "Assets/Prefabs/Asteroid.prefab";

    AddressableLoader addressableLoader;

    [Inject] GameManager gameManager;

    List<GameObject> asteroids;

    private void Start()
    {
        asteroids = new List<GameObject>();
        addressableLoader = ScriptableObject.CreateInstance<AddressableLoader>();
        addressableLoader.prefabAddress = prefabPath;
        addressableLoader.OnLoadComplete += HandleLoadComplete;
    }

    public void StartSpawning()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    public void StopSpawning()
    {
        CancelInvoke(nameof(Spawn));
    }

    public void Spawn()
    {
        Vector3 spawnPos = HelperFunctions.RandomOnUnitCircle();
        spawnPos = Camera.main.ViewportToWorldPoint(spawnPos);
        addressableLoader.SpawnPrefab(spawnPos, Quaternion.identity);
    }

    public void DestroyAsteroid(GameObject gameObject)
    {
        asteroids.Remove(gameObject);
        Destroy(gameObject);
    }

    public void RegisterAsteroid(GameObject gameObject)
    {
        asteroids.Add(gameObject);
    }

    public void ResetAsteroids()
    {
        foreach (GameObject obj in asteroids)
        {
            Destroy(obj);
        }

        asteroids.Clear();
    }

    public void HandleLoadComplete(GameObject gameObject)
    {
        Asteroid asteroid = gameObject.GetComponent<Asteroid>();

        Assert.IsNotEqual(asteroid, null);

        asteroid.gameManager = gameManager;
        asteroid.asteroidManager = this;
        asteroid.size = Random.Range(1, 4);
        Vector3 spawnDirection = Random.onUnitSphere;

        asteroid.Spawn();
        asteroid.Project(spawnDirection);
        asteroids.Add(gameObject);
    }

}

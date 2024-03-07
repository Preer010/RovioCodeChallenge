using ModestTree;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    string playerPrefabAddress = "Assets/Prefabs/Player.prefab";

    List<GameObject> players;

    AddressableLoader addressableLoader;

    AsteroidManager asteroidManager;

    public ScoreManager scoreManager;

    private void Start()
    {
        asteroidManager = GetComponent<AsteroidManager>();
        Assert.IsNotEqual(asteroidManager, null);
        scoreManager = GetComponent<ScoreManager>();
        Assert.IsNotEqual(scoreManager, null);

        players = new List<GameObject>();

        addressableLoader = ScriptableObject.CreateInstance<AddressableLoader>();
        addressableLoader.prefabAddress = playerPrefabAddress;
        addressableLoader.OnLoadComplete += OnPlayerLoaded;
    }

    public void StartGame()
    {
        asteroidManager.StartSpawning();
        SpawnPlayer();
    }

    public void EndGame()
    {
        asteroidManager.ResetAsteroids();
        asteroidManager.StopSpawning();
        scoreManager.EndGame();
        StartGame();
    }

    public void SpawnPlayer()
    {
        addressableLoader.SpawnPrefab(new Vector3(), Quaternion.identity);
    }

    void OnPlayerLoaded(GameObject gameObject)
    {
        Assert.IsNotEqual(gameObject, null);
        players.Add(gameObject);
        PlayerHealth playerHealth = gameObject.GetComponent<PlayerHealth>();
        Assert.IsNotEqual(playerHealth, null);
        playerHealth.gameManager = this;
    }

    public void DestroyPlayer(GameObject gameObject)
    {
        players.Remove(gameObject);
        Destroy(gameObject);
        if(players.Count == 0)
        {
            EndGame();
        }
    }
}

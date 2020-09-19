using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    [SerializeField] private float spawnDelay = 2;
    [SerializeField] private float spawnInterval = 1.5f;

    [SerializeField] private float spawnRangeMin = -5;
    [SerializeField] private float spawnRangeMax = 5;
    // Reference to Game Manger
    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Spawn obstacles
    void SpawnObjects()
    {
        // Set random spawn location and random object index
        Vector3 spawnLocation = new Vector3(15, Random.Range(spawnRangeMin, spawnRangeMax), 0);
        int index = Random.Range(0, objectPrefabs.Length);

        // If game is still active, spawn new object
        if (!gameManager.gameOver)
        {
            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        }

    }
}

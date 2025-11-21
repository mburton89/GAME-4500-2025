using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnerAR : MonoBehaviour
{
    public static ZombieSpawnerAR Instance;
    public List<GameObject> zombiePrefabs;
    public List<Transform> spawnPoints;
    int wave;
    public int maxWave;
    Transform player;
    public float minDistance = 5f;
    public bool gameStarted = false;
    private int activeZombies = 0;

    void Awake()
    {
        Instance = this;
        wave = 0; // Start at 0 so first SpawnWaveOfZombies() sets Wave 1
        spawnPoints = new List<Transform>();
    }

    private void Start()
    {
        player = Camera.main.transform;
    }

    void Update()
    {

    }

    public void SetSpawnPoints(List<Transform> points)
    {
        spawnPoints.Clear();
        spawnPoints.AddRange(points);
        gameStarted = true;
    }

    public void SpawnWaveOfZombies()
    {
        wave++;

        // Spawn EXACTLY ONE zombie at random spawnpoint
        if (spawnPoints.Count == 0) return;

        int rand = Random.Range(0, spawnPoints.Count);
        Vector3 spawnPos = spawnPoints[rand].position;
        int attempts = 0;
        int maxAttempts = 10;
        while (Vector3.Distance(spawnPos, player.position) < minDistance && attempts < maxAttempts)
        {
            rand = Random.Range(0, spawnPoints.Count);
            spawnPos = spawnPoints[rand].position;
            attempts++;
        }

        int randZombie = Random.Range(0, zombiePrefabs.Count);
        Instantiate(zombiePrefabs[randZombie], spawnPos, transform.rotation, transform);
        activeZombies = 1;
    }

    public void OnZombieDeath()
    {
        activeZombies--;
        if (activeZombies <= 0)
        {
            activeZombies = 0;
            SpawnWaveOfZombies();
        }
    }
}
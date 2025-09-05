using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZombieSpawner : MonoBehaviour
{
    public List<Transform> zombieSpawnpoints;
    int  numberOfZombiesRemaining;

    private int waveNumber;

    public static ZombieSpawner Instance;

    public GameObject zombie;

    public TextMeshProUGUI waveNumberText;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        
        waveNumber = 1;

        SpawnEnemies(waveNumber);
    }
    void SpawnEnemies(int waveNumber)
    {
        Debug.Log("Spawning wave " + waveNumber);
        for (int x = 0; x < waveNumber; x++)
            for (int i = 0; i < zombieSpawnpoints.Count; i++)
                Instantiate(zombie, zombieSpawnpoints[i].position, transform.rotation, transform);
    }

    public void CountZombies()
    {
        Zombie[] zombiesInScene = FindObjectsOfType<Zombie>();
        numberOfZombiesRemaining = zombiesInScene.Length;

        if (numberOfZombiesRemaining <= 0)
        {
            waveNumber++;
            SpawnEnemies(waveNumber);
        }
    }
}

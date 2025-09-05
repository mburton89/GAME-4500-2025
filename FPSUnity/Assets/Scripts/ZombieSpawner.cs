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

        SpawnEnemies();
    }
    void SpawnEnemies()
    {
        Debug.Log("Spawning wave " + waveNumber);
        waveNumberText.text = "Wave " + waveNumber;
        for (int x = 0; x < waveNumber; x++)
            for (int i = 0; i < zombieSpawnpoints.Count; i++)
                Instantiate(zombie, zombieSpawnpoints[i].position, transform.rotation, transform);
    }

    public void CountZombies()
    {
        Zombie[] zombiesInScene = FindObjectsOfType<Zombie>();
        numberOfZombiesRemaining = zombiesInScene.Length - 1;
        Debug.Log("Counting zombies: "+ numberOfZombiesRemaining);

        if (numberOfZombiesRemaining < 1)
        {
            Debug.Log("Spawning next wave");
            waveNumber++;
            SpawnEnemies();
        }
    }
}

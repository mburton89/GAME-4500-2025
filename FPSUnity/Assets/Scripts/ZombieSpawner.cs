using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public static ZombieSpawner Instance;

    public GameObject zombiePrefab;
    public List<Transform> spawnPoints;

    GameObject zombie;

    int wave;
    public int MaxWave;

    // TextMeshPro waveText;

    int zombieCount;

    void Awake()
    {
        Instance = this;
        wave = 1;
    }

    private void Start()
    {
        spawnWave();
    }

    void Update()
    {
        
    }

    public void spawnWave()
    {
        wave++;

        // waveText.SetText("Wave: " + wave);

        for (int i = 0; i < wave; i++) 
        {
            int randInt = Random.Range(0, spawnPoints.Count);
            Instantiate(zombiePrefab, spawnPoints[randInt].position, transform.rotation, transform);
        }

        // Update HUD with Wave #

    }

    public void countZombies()
    {
        Zombie[] allZombiesInScene = FindObjectsOfType<Zombie>();
        if (allZombiesInScene.Length == 1) { spawnWave(); }
    }
}

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public static ZombieSpawner Instance;

    public List<GameObject> zombiePrefab;
    public List<Transform> spawnPoints;

    GameObject zombie;

    int wave;
    public int MaxWave;
    int zombieCount;

    public TextMeshProUGUI waveText;

    Transform player;
    public float minDistance = 5f;

    void Awake()
    {
        Instance = this;
        wave = 1;
    }

    private void Start()
    {
        player = FindObjectOfType<FPSController>().transform;
        spawnWave();
    }

    public void spawnWave()
    {
        wave++;
        waveText.SetText("Wave: " + wave);

        for (int i = 0; i < wave; i++) 
        {
            int randInt = Random.Range(0, spawnPoints.Count);
            int randZombieInt = Random.Range(0, zombiePrefab.Count);
            Vector3 spawnPos = spawnPoints[randInt].position;
            int attempts = 0, maxAttempts = 10;
            while ((Vector3.Distance(spawnPos, player.position) < minDistance) && (attempts < maxAttempts))
            {
                randInt = Random.Range(0, spawnPoints.Count);
                spawnPos = spawnPoints[randInt].position;
                attempts++;
            }

            Instantiate(zombiePrefab[randZombieInt], spawnPos, transform.rotation, transform);
        }

    }

    public void countZombies()
    {
        Zombie[] allZombiesInScene = FindObjectsOfType<Zombie>();
        if (allZombiesInScene.Length == 1) { spawnWave(); }
    }
}

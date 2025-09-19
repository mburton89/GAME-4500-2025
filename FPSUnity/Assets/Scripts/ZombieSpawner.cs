using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZombieSpawner : MonoBehaviour
{
    public static ZombieSpawner Instance;

    public GameObject zombiePrefab;
    public List<Transform> spawnPoints;

    int wave;
    public int maxWave;

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
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnWaveofZombies()
    {

        wave++;

        waveText.SetText("Wave: " + wave);

        for (int i = 0; i < wave; i++)
        {
            // assigning i = 0, when i is less than wave, add 1 more, loop
            int rand = Random.Range(0,spawnPoints.Count);
            Vector3 spawnPos = spawnPoints[rand].position;
            int attempts = 0;
            int maxAttempts = 10;

            while(Vector3.Distance(spawnPos, player.position) < minDistance && attempts < maxAttempts)
            {
               rand = Random.Range(0, spawnPoints.Count);
               spawnPos = spawnPoints[rand].position;
                attempts++;
            }
            
            Instantiate(zombiePrefab, spawnPos, transform.rotation, transform);
        }

    }

    public void CountZombies()
    {
        print("Count Zombie");

       Zombie[] allZombiesInScene = FindObjectsOfType<Zombie>();

        if(allZombiesInScene.Length == 1)
        {
            SpawnWaveofZombies();
        }
    }
}

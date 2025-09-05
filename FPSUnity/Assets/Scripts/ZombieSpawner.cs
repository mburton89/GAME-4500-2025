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

    void Awake()
    {
        Instance = this;
        wave = 1;
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
            Instantiate(zombiePrefab, spawnPoints[rand].position, transform.rotation, transform);
        }

        //Update HUB with Wave #

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

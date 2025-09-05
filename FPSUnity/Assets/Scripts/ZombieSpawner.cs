using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public static ZombieSpawner Instance;

    public GameObject zombiePrefab;
    public List<Transform> spawnPoints;

    int wave;
    public int maxWave;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        wave = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnWaveOfZombies()
    {
        wave++;
        for(int i = 0; i < wave; i++)
        {
            int rand = Random.Range(0, spawnPoints.Count);
            Instantiate(zombiePrefab, spawnPoints[rand].position, transform.rotation, transform);
        }

        //Update HUD with Wave
    }

    public void CountZombies()
    {
        Zombie[] allZombiesInScene = FindObjectsOfType<Zombie>();
        if (allZombiesInScene.Length == 1)
        {
            SpawnWaveOfZombies();
        }
    }
}

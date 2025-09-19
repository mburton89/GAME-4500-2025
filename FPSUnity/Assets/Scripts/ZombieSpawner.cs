using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using TMPro;

public class ZombieSpawner : MonoBehaviour
{
    public static ZombieSpawner Instance;
    
    public List<GameObject> zombiePrefab;
    public List<Transform> spawnPoints;

    public int wave;
    public int maxWave;

    public TextMeshProUGUI waveText;

    private Transform player;
    public float minDistanceFromPlayer = 5f;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        wave = 1;
        //SpawnWaveOfZombies();

    }

    private void Start()
    {
        player = FindObjectOfType<FPSController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SpawnWaveOfZombies()
    {
        wave++;
        waveText.SetText("Wave: " + wave);
        for(int i = 0; i < wave; i++)
        {
            int rand = Random.Range(0, spawnPoints.Count);
            Vector3 spawnPos = spawnPoints[rand].position;
            int attempts = 0;
            int maxAttempts = 10;

            while (Vector3.Distance(spawnPos, player.position) < minDistanceFromPlayer && attempts < maxAttempts)
            {
                rand = Random.Range(0, spawnPoints.Count);
                spawnPos = spawnPoints[rand].position;
                attempts++;
            }

            int randPrefab = Random.Range(0, zombiePrefab.Count);
            GameObject CurrentZombiePrefab = zombiePrefab[randPrefab];
            Instantiate(CurrentZombiePrefab, spawnPos, transform.rotation, transform);

        }
    }

    public void CountZombies()
    {
        Zombie[] allZombiesInScene = FindObjectsOfType<Zombie>();

        print("Zombie Count: " + allZombiesInScene.Length); 

        if (allZombiesInScene.Length == 1)
        {
            SpawnWaveOfZombies();
        }
    }

}

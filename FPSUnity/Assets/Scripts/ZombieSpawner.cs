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

    public void SpawnWaveOfZombies()
    {
        wave++;
        waveText.SetText("Wave: " + wave);

        for (int i = 0; i < wave; i++)
        {
            int rand = Random.Range(0, spawnPoints.Count);
            //if player too close to spawnPoints[rand].position, get a new rand
            Instantiate(zombiePrefab, spawnPoints[rand].position, transform.rotation, transform);
        }

        //Update HUD with Wave
    }

    public void CountZombies()
    {
        print("Count Zombies");

        Zombie[] allZombiesInScene = FindObjectsOfType<Zombie>();

        if (allZombiesInScene.Length == 1)
        { 
            SpawnWaveOfZombies();
        }
    }
}

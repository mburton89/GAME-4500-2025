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

    public float minDistance = 5;

    // Start is called before the first frame update
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
            Vector3 spawnPos = spawnPoints[rand].position;
            int attempt = 0;
            int maxAttempt = 10;

            while (Vector3.Distance(spawnPos, player.position) < minDistance && attempt < maxAttempt) 
            {
                rand = Random.Range(0, spawnPoints.Count);
                spawnPos = spawnPoints[rand].position;
                attempt++;
            }

            Instantiate(zombiePrefab, spawnPos, transform.rotation, transform);


        }    
        
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

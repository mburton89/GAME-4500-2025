using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
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
        waveText.SetText("Wave: " + wave);
        for(int i = 0; i < wave; i++)
        {
            int rand = Random.Range(0, spawnPoints.Count);
            Instantiate(zombiePrefab, spawnPoints[rand].position, transform.rotation, transform);

        }
        //Update Hud with Wave
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

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZomSpawner : MonoBehaviour
{
    public static ZomSpawner instance;
    public GameObject zombiePrefab;

    public List<Transform> spawnLocations;

    private int waveNum;

    private void Awake()
    {
        instance = this;
        waveNum = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform) // doesn't work in Awake()
        {
            spawnLocations.Add(child);
        }
        SpawnWave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnWave()
    {
        int m = 5;
        for (int i = 0; i < (waveNum*2)*m; i++)
        {
            int rand = Random.Range(0, spawnLocations.Count);
            Instantiate(zombiePrefab, spawnLocations[rand].position, transform.rotation, transform);
        }
    }

    public void CountZombies()
    {
        Zombie[] allZombiesInScene = FindObjectsOfType<Zombie>();
        if(allZombiesInScene.Length < 2)
        {
            waveNum++;
            SpawnWave();
        }
        //Debug.Log(allZombiesInScene.Length);
    }

    public int getWaveNum()
    {
        return waveNum;
    }
}

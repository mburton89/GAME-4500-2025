using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZombieSpawner : MonoBehaviour
{
    public List<Transform> zombieSpawnpoints;
    public static ZombieSpawner Instance;
    public GameObject zombie;
    public TextMeshProUGUI waveNumberText;
    Transform Player;

    public int prepTime, safeDistance;
    int waveNumber, numberOfZombiesRemaining;


    private void Start()
    {
        if (Instance == null)
            Instance = this;

        Player = FindObjectOfType<FPSController>().transform;

        waveNumber = 1;

        SpawnEnemies();
    }
    void SpawnEnemies()
    {
        if (waveNumber == 1)
        {
            StartCoroutine(DoPrepTime());
        }
        waveNumberText.text = "Wave " + waveNumber;
        for (int x = 0; x < waveNumber; x++)
            for (int i = 0; i < zombieSpawnpoints.Count; i++)
            {
                int attempts = 10;
                if ((Player.position - zombieSpawnpoints[i].position).magnitude > safeDistance)
                    Instantiate(zombie, zombieSpawnpoints[i].position, transform.rotation, transform);
                else if (attempts > 0)
                {
                    attempts--;
                }
                else
                {
                    break;
                }
            }
    }

    public void CountZombies()
    {
        Zombie[] zombiesInScene = FindObjectsOfType<Zombie>();
        numberOfZombiesRemaining = zombiesInScene.Length - 1;

        if (numberOfZombiesRemaining < 1)
        {
            waveNumber++;
            SpawnEnemies();
        }
    }

    IEnumerator DoPrepTime()
    {
        yield return new WaitForSeconds(prepTime);
    }
}

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{

    public  GameObject ammoPrefab;
    public float respawnTime = 15f; //seconds before ammo respawns

    private GameObject currentAmmo; //keeps track of spawned ammo

    // Start is called before the first frame update
    void Start()
    {
        SpawnAmmo();
    }

    public List<Transform> spawnPoints;

    void SpawnAmmo()
    {
        if (spawnPoints == null || spawnPoints.Count == 0)
        {
            Debug.LogWarning("No spawn points assigned to AmmoSpawner.");
            return;
        }

        // Choose a random spawn point
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

        // Spawn ammo at selected point
        currentAmmo = Instantiate(ammoPrefab, spawnPoint.position, spawnPoint.rotation);

        // Assign reference to this spawner
        AmmoPickup pickup = currentAmmo.GetComponent<AmmoPickup>();
        if (pickup != null)
        {
            pickup.spawner = this;
        }
    }
    public void NotifyAmmoCollected()
    {
        Invoke(nameof(SpawnAmmo),respawnTime);
    }
}

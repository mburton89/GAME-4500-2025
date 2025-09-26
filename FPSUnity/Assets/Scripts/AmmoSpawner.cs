using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    public float spawnCooldown = 30;
    public float initialSpawnCooldown = 30;

    public List<GameObject> ammoBoxPrefabs;
    public List<Transform> ammoBoxSpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        initialSpawnCooldown = spawnCooldown;
        spawnCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCooldown -= Time.deltaTime;

        if (spawnCooldown < 0 && Cannon.Instance.ammoCount < 10)
        {
            SpawnAmmo();
            spawnCooldown = initialSpawnCooldown;
        }

        if (Cannon.Instance.ammoCount <= 0)
        {
            spawnCooldown -= Time.deltaTime * 2;
        }
    }

    // Should try to make teh ammo respawn at the same locatin as it despawned

    // Pass int (same as isP1 in VGProgramming) to tell the ammoSpawner class which spawn point to use

    public void SpawnAmmo()
    {
        int rand = Random.Range(0, ammoBoxSpawnPoints.Count);
        Vector3 spawnPos = ammoBoxSpawnPoints[rand].position;

        // int randPrefab = Random.Range(0, ammoBoxPrefabs.Count);
        //GameObject CurrentAmmoBoxPrefab = ammoBoxPrefabs[randPrefab];
        GameObject CurrentAmmoBoxPrefab = ammoBoxPrefabs[0];
        Instantiate(CurrentAmmoBoxPrefab, spawnPos, transform.rotation, transform);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    public static AmmoSpawner Instance;

    public GameObject ammoPrefab;
    public Transform spawnPoint;

    public float respawnRate;

    private void Start()
    {
        SpawnAmmo();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AmmoRespawn()
    {
        StartCoroutine(AmmoRespawnCo());
    }

    public void SpawnAmmo()
    {
        GameObject newAmmoPickup = Instantiate(ammoPrefab, spawnPoint.position, transform.rotation, transform);

        newAmmoPickup.GetComponent<Ammo>().parentSpawner = this;
    }

    private IEnumerator AmmoRespawnCo()
    {
        yield return new WaitForSeconds(respawnRate);

        SpawnAmmo();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmmoSpawner : MonoBehaviour
{
    public GameObject ammoPickupPrefab;
    public Transform spawnPoint;
    public float respawnRate = 30f;

    private void Start()
    {
        SpawnAmmo();
    }

    public void DelaySpawnAmmo()
    {
        StartCoroutine(DelaySpawnCo());
    }

    public void SpawnAmmo()
    {
        GameObject newAmmoPickup = Instantiate(ammoPickupPrefab, spawnPoint.position, transform.rotation, transform);

        newAmmoPickup.GetComponent<AmmoPickup>().parentSpawner = this;
    }

    private IEnumerator DelaySpawnCo()
    {
        yield return new WaitForSeconds(respawnRate);

        SpawnAmmo();
    }
}

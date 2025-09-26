using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUpSpawner : MonoBehaviour
{
    public GameObject ammoPickupPrefab;

    public List<Transform> ammoSpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnAmmo()
    {
        Instantiate(ammoPickupPrefab, transform, transform);

    }



}

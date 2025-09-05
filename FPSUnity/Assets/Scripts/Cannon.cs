using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileLaunchSpeed;
    public Transform projectileSpawnPoint;
    public AudioSource plunk;

    public List<Transform> ShotgunSpawnpoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Shotgun();
        }
    }

    void Shoot()
    {
        // print("Shoot");
        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        newProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.forward * projectileLaunchSpeed);

        float rand = Random.Range(0.9f, 1.1f);
        plunk.pitch = rand;
        plunk.Play();

        Destroy(newProjectile, 5);
    }

    void Shotgun()
    {
        for (int i = 0; i < 3; i++)
        {
            int randInt = Random.Range(0, ShotgunSpawnpoints.Count);
            GameObject newShotgunProjectile = Instantiate(projectilePrefab, ShotgunSpawnpoints[randInt].position, transform.rotation);
            newShotgunProjectile.GetComponent<Rigidbody>().AddForce(ShotgunSpawnpoints[randInt].forward * projectileLaunchSpeed);
        }
     
    }
}

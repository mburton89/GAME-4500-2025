using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAR : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileLaunchSpeed;
    public Transform projectileSpawnPoint;
    public AudioSource plunk;
    public Vector3 offsetForce;

    void Update()
    {
        if (!ZombieSpawnerAR.Instance.gameStarted) return;

        // Support both editor mouse and mobile touch
        bool inputDetected = Input.GetMouseButtonDown(0) ||
                             (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began);

        if (inputDetected)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        print("Shoot");
        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        newProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.forward * projectileLaunchSpeed + offsetForce);
        float rand = Random.Range(0.9f, 1.1f);
        plunk.pitch = rand;
        plunk.Play();
        Destroy(newProjectile, 5);
    }
}
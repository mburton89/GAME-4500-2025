using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileLaunchSpeed;
    public Transform projectileSpawnPoint;
    public AudioSource plunk;

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
    }

    void Shoot()
    {
        print("shoot");
        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        newProjectile.GetComponent<Rigidbody>().AddForce(transform.up * projectileLaunchSpeed);
        newProjectile.GetComponent<Rigidbody>().AddForce(transform.up * projectileLaunchSpeed);

        ShootSound();

        Destroy(newProjectile, 5f);
    }

    void ShootSound()
    {
        plunk.pitch = Random.Range(0.8f, 1.2f);
        plunk.Play();

    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileLaunchSpeed;
    public Transform projectileSpawnPoint;
    public AudioSource plunk;
    public float shootCooldown;
    private bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && canShoot) 
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        newProjectile.GetComponent<Rigidbody>().AddForce(transform.up * projectileLaunchSpeed);
        newProjectile.GetComponent<Rigidbody>().AddForce(transform.up * projectileLaunchSpeed);

        ShootSound();

        StartCoroutine(Cooldown(shootCooldown));

        Destroy(newProjectile, 5f);
    }

    void ShootSound()
    {
        plunk.pitch = Random.Range(0.8f, 1.2f);
        plunk.Play();

    }

    IEnumerator Cooldown(float cooldown)
    {
        canShoot = false;
        yield return new WaitForSeconds(cooldown);
        canShoot = true; 
    }
}

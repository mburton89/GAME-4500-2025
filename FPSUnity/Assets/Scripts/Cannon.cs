using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileLaunchSpeed;
    public Transform projectileSpawnPoint;
    public AudioSource plunk;

    public int maxAmmo;
    public int currentAmmo;

    public static Cannon instance;

    public TextMeshProUGUI ammoCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0)
        {
            Shoot();

        }
        string ammoCounterString = "Ammo: " + currentAmmo + "/" + maxAmmo;
        ammoCounter.SetText(ammoCounterString);

    }

    void Shoot()
    {
        print("Shoot");
        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        newProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.forward * projectileLaunchSpeed);
        currentAmmo--; 
        float rand = Random.Range(0.9f, 1.1f);
        plunk.pitch = rand;
        plunk.Play();
        Destroy(newProjectile, 2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<AmmoPickup>())
        {
            currentAmmo = maxAmmo;
        }
    }
}

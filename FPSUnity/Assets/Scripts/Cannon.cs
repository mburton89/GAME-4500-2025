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
    public AudioSource noAmmo;

    public int startingAmmo;
    public int currentAmmo;
    public TextMeshProUGUI ammoText;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = startingAmmo;
        UpdateAmmoUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentAmmo > 0)
            {
                Shoot();
            }
            else
            {
                HandleNoAmmo();
            }
        }
    }

    void Shoot()
    {
        print("Shoot");
        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        newProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.forward * projectileLaunchSpeed);

        float rand = Random.Range(0.9f, 1.1f);

        plunk.pitch = rand;
        plunk.Play();
        Destroy(newProjectile, 5);

        currentAmmo--;

        UpdateAmmoUI();
    }

    void HandleNoAmmo()
    {
        noAmmo.Play();
    }

    public void HandleAmmoPickup(int numberOfAmmo)
    {
        currentAmmo += numberOfAmmo;
        UpdateAmmoUI();
    }

    public void UpdateAmmoUI()
    {
        string ammoString = "Ammo: " + currentAmmo;
        ammoText.SetText(ammoString);
    }
}

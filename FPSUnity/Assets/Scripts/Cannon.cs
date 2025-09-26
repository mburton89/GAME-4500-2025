using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public TextMeshProUGUI ammoAmount;

    public int maxAmmo;
    public int currentAmmo;

    public float projectileLaunchSpeed;
    public Transform projectileSpawnPoint;
    public AudioSource plunk;


    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;

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
        }

    }

    void Shoot()
    {
        print("Shoot");
        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        newProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.forward * projectileLaunchSpeed);
        currentAmmo--;
        UpdateAmmoUI();

        
        

        float rand = Random.Range(0.9f, 1.1f);
        plunk.pitch = rand;

        plunk.Play();
        Destroy(newProjectile, 5);
    }

    public void HandleAmmoPickup(int numberOfAmmo)
    {
        currentAmmo += numberOfAmmo;
        UpdateAmmoUI();
    }

    public void UpdateAmmoUI() 
    {
        string ammoString = "Ammo: " + currentAmmo;
        ammoAmount.SetText(ammoString); 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileLaunchSpeed;
    public Transform projectileSpawnPoint;
    public AudioSource plunk;

    public int MaxAmmo = 50;
    public int currentAmmo;

    public TextMeshProUGUI ammoText;



    void Start()
    {
        currentAmmo = MaxAmmo;
        UpdateAmmoUI();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        currentAmmo--;
        UpdateAmmoUI();

        print("Shoot");
        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        newProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.forward * projectileLaunchSpeed);


        float rand = Random.Range(0.9f, 1.1f);

        plunk.pitch = rand;
        plunk.Play();
        Destroy(newProjectile, 5);
    }


    public void AddAmmo(int amount)
    {
        currentAmmo = Mathf.Min(currentAmmo + amount, MaxAmmo);
        UpdateAmmoUI();
    }

    void UpdateAmmoUI()
    {
        if (ammoText != null)
        {
            ammoText.text = "Ammo: " + currentAmmo + " / " + MaxAmmo;
        }
    }
}







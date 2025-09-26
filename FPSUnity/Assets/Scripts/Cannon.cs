using JetBrains.Annotations;
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
    public int currentAmmo = 10;
    public TextMeshProUGUI ammoText;



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
    void UpdateAmmoUI()
    {
        string ammoString = "Ammo: " + currentAmmo;
        ammoText.SetText(ammoString);

    }

}
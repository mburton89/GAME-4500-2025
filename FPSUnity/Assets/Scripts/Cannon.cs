using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileLaunchSpeed;
    public Transform projectileSpawnPoint;
    public AudioSource plunk;

    //ammo
    public int ammo;
    public int ammoMax;

    public TextMeshProUGUI ammoText;

    private bool ammoEnabled = true;
    

    // Start is called before the first frame update
    void Start()
    {
        ammo = ammoMax;
        


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryShoot();
        }

        if (ammo < 0)
        {
            ammo = 0;
        }

        ammoText.text = " Ammo: " + ammo;
    }


    void TryShoot()
    {
        


        if (ammo> 0 && ammoEnabled)
        {
            Shoot();
        }
    }

    public void AddAmmmo(int Amount)
    {
        ammo += Amount;
        ammoEnabled = true;
        ammoText.text = " Ammo: " + ammo;
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

        ammoText.text = " Ammo: " + ammo;

        ammo--;

        if (ammo <= 0)
        {
            ammoEnabled = false;
        }


    }




}

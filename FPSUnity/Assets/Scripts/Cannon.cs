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
    public AudioSource error;
    public int ammoCount;
    public int maxAmmoCount;
    public TextMeshProUGUI ammoText;


    // Start is called before the first frame update
    void Start()
    {
        ammoText.SetText("Ammo: " + ammoCount + "/" + maxAmmoCount);
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
        if (ammoCount > 0)
        {
            print("Shoot");
            GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
            newProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.forward * projectileLaunchSpeed);
            
            ammoCount--;
            ammoText.SetText("Ammo: " + ammoCount + "/" + maxAmmoCount);

            float rand = Random.Range(0.9f, 1.1f);

            plunk.pitch = rand;
            plunk.Play();
            Destroy(newProjectile, 5);

        }
        else
        {
            float rand = Random.Range(0.9f, 1.1f);

            error.pitch = rand;
            error.Play();
        }
    }

    public void AddAmmo(int ammoToGive)
    {     
        if (ammoCount + ammoToGive > maxAmmoCount)
        {
            ammoCount = maxAmmoCount;
        }
        else
        {
            ammoCount = ammoCount + ammoToGive;
        }
        ammoText.SetText("Ammo: " + ammoCount + "/" + maxAmmoCount);
    }
}

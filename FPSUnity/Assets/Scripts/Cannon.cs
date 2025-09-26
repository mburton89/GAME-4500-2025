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

    public TextMeshProUGUI ammoText;
    public int maxAmmo;
    public int currentAmmo;

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
            Shoot();
        }
    }

    void Shoot()
    {
        if (currentAmmo > 0)
        {
            print("Shoot");
            GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
            newProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.forward * projectileLaunchSpeed);
            currentAmmo--;
            UpdateAmmoDisplay();

            float rand = Random.Range(0.0f, 1.1f);

            plunk.pitch = rand;
            plunk.Play();
            Destroy(newProjectile, 4);
        }

        //else () {emptyAmmo.play()} find sound :3
    }

    public void HandleAmmoPickup(int numOfAmmo)
    {
        currentAmmo += numOfAmmo;
        UpdateAmmoDisplay();
    }

    void UpdateAmmoDisplay()
    {
        ammoText.text = "Ammo: " + currentAmmo + "/" + maxAmmo;
    }
}

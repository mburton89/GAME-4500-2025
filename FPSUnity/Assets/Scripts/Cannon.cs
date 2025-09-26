using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cannon : MonoBehaviour
{
    public static Cannon Instance;

    public GameObject projectilePrefab;
    public float projectileLaunchSpeed;
    public Transform projectileSpawnPoint;
    public AudioSource plunk;
    public int ammoCount = 20;
    public TextMeshProUGUI ammoCountText;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        ammoCountText.SetText("Ammo: " + ammoCount);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammoCount >= 1)
        {
            Shoot();
            ammoCount = ammoCount - 1;
            ammoCountText.SetText("Ammo: " + ammoCount);
        }
    }

    void Shoot()
    {
        print("Shoot");
        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        newProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.forward * projectileLaunchSpeed);

        float rand = Random.Range (0.9f, 1.1f);
        plunk.pitch = rand;
        plunk.Play();
        Destroy(newProjectile, 1);
    }

    public void AddAmmo()
    {
        ammoCount = ammoCount + 12;
        ammoCountText.SetText("Ammo: " + ammoCount);
    }
}

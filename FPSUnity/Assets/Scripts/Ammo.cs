using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int ammoToGive;
    public AmmoSpawner parentSpawner;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<FPSController>())
        {
            GameManager.Instance.cannon.AddAmmo(ammoToGive);
            parentSpawner.AmmoRespawn();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FPSController>())
        {
            GameManager.Instance.cannon.AddAmmo(ammoToGive);
            parentSpawner.AmmoRespawn();
            Destroy(gameObject);
        }
    }
}

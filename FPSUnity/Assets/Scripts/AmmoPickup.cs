using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    private int ammoAmmount = 5;
    public AmmoSpawner parentSpawner;

    private void OnCollisionEnter(Collision collision)
    {
        GameManager.instance.cannon.HandleAmmoPickup(ammoAmmount);
        //parentSpawner.DelaySpawnAmmo();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FPSController>())
        {
            GameManager.instance.cannon.HandleAmmoPickup(ammoAmmount);
            //parentSpawner.DelaySpawnAmmo();
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 10;
    public AmmoSpawner spawner; 

    void OnTriggerEnter(Collider other)
    {
        Cannon cannon = other.GetComponent<Cannon>();
        if (cannon != null)
        {
            cannon.AddAmmo(ammoAmount);

            //notify spawner ammo was picked up
            if (spawner != null)
            {
                spawner.NotifyAmmoCollected();
            }
            
            Destroy(gameObject);
        }
    }
}

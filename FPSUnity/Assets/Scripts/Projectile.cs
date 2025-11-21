using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damageToGive = 2;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Zombie>())
        {
            collision.gameObject.GetComponent<Zombie>().TakeDamage(damageToGive);
        }
        if (collision.gameObject.GetComponent<ZombieAR>())
        {
            collision.gameObject.GetComponent<ZombieAR>().TakeDamage(damageToGive);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Zombie>())
        {
            other.gameObject.GetComponent<Zombie>().TakeDamage(damageToGive);
        }
        if (other.gameObject.GetComponent<ZombieAR>())
        {
            other.gameObject.GetComponent<ZombieAR>().TakeDamage(damageToGive);
        }
    }
}

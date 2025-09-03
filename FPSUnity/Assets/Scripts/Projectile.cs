using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float damageToGive;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Zombie>())
        {
            collision.gameObject.GetComponent<Zombie>().TakeDamage(damageToGive);
        }
    }

}

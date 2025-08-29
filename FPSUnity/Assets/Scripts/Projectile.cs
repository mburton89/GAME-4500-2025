using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damageOut;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Zombie enemy = collision.gameObject.GetComponent<Zombie>();
            if (enemy != null)
            {
                enemy.TakeDamage(damageOut);
            }
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float currentHealth;
    public float maxHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Zombie z = collision.gameObject.GetComponent<Zombie>();
        if (z != null)
        {
            if(currentHealth > 0)
            {
                currentHealth -= z.getAttackPower();
                Debug.Log(currentHealth);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            
        }
    }

    public float getHealth()
    {
        return currentHealth;
    }
}

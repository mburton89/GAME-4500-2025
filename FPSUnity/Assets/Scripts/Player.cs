using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float currentHealth;
    public float maxHealth;

    public Image hpBarFill;

    private void Awake()
    {
        currentHealth = maxHealth;
        hpBarFill.fillAmount = 1;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Zombie z = collision.gameObject.GetComponent<Zombie>();
        if (z != null)
        {
            if(currentHealth > 0)
            {
                currentHealth -= z.getAttackPower();
                hpBarFill.fillAmount = currentHealth/maxHealth;
                //Debug.Log(currentHealth);
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

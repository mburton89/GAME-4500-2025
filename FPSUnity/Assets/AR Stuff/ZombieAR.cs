using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ZombieAR : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;
    public AudioSource getHitSound;
    public float moveSpeed = 3f;
    Transform target;
    public GameObject zombieGuts;
    public Image healthBarFill;
    public GameObject healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        target = Camera.main.transform;
    }

    void Update()
    {
        if (target != null)
        {
            // Simple chase: move towards player camera on XZ plane only (no floating)
            Vector3 direction = (target.position - transform.position);
            direction.y = 0;  // Lock to ground level
            direction.Normalize();
            transform.position += direction * moveSpeed * Time.deltaTime;
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        }
    }

    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;
        getHitSound.Play();
        healthBarFill.fillAmount = currentHealth / maxHealth;
        healthBar.SetActive(true);

        if (currentHealth <= 0)
        {
            GameObject spawnedZombieGuts = Instantiate(zombieGuts, transform.position, transform.rotation);
            ZombieSpawnerAR.Instance.OnZombieDeath();
            Destroy(gameObject);
            Destroy(spawnedZombieGuts, 2);
        }
    }
}
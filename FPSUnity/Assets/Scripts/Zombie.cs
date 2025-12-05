using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;

    public AudioSource getHitSound;

    NavMeshAgent agent;
    Transform target;

    public GameObject zombieGuts;

    public Image healthBarFill;

    public GameObject healthBar;

    public bool isARZombie;
    public float arMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        if (isARZombie)
        {
            target = Camera.main.transform;
        }
        else
        { 
            target = FindObjectOfType<FPSController>().transform;
        }

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isARZombie)
        {
            ChaseARPlayer();
        }
        else
        { 
            ChasePlayer();
        }
    }

    public void TakeDamage(float damageToTake)
    { 
        currentHealth -= damageToTake;
        getHitSound.Play();

        healthBarFill.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            GameObject spawnedZombieGuts = Instantiate(zombieGuts, transform.position, transform.rotation, null);
            ZombieSpawner.Instance.CountZombies(); 
            Destroy(gameObject);
            Destroy(spawnedZombieGuts, 2);
        }

        healthBar.SetActive(true);
    }

    void ChasePlayer()
    {
        agent.destination = target.position;
    }

    void ChaseARPlayer()
    {
        if (target != null)
        {
            // Simple chase: move towards player camera on XZ plane only (no floating)
            Vector3 direction = (target.position - transform.position);
            direction.y = 0;  // Lock to ground level
            direction.Normalize();
            transform.position += direction * arMoveSpeed * Time.deltaTime;
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        }
    }
}

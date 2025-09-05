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


    void Start()
    {
        currentHealth = maxHealth;

        target = FindAnyObjectByType<FPSController>().transform;

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }

    public void TakeDamage(float damageToTake) 
    {
        currentHealth -= damageToTake;
        getHitSound.Play();

        healthBarFill.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0) 
        {
           GameObject spawnZombieGuts = Instantiate(zombieGuts, transform.position, transform.rotation, null);
            ZombieSpawner.Instance.CountZombies();
            Destroy(gameObject);
            Destroy(spawnZombieGuts, 2);
        }

    }

    void ChasePlayer() 
    {
        agent.destination = target.position;
    }

}

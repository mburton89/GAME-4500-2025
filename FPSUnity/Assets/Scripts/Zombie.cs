using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;

    public AudioSource getHitSound;

    NavMeshAgent agent;
    Transform target;

    public GameObject zombieGuts;




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

        if (currentHealth <= 0) 
        {
            Instantiate(zombieGuts, transform.position, transform.rotation, null);
            Destroy(gameObject);
        }

    }

    void ChasePlayer() 
    {
        agent.destination = target.position;
    }

}

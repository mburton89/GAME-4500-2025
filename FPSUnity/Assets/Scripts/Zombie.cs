using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;
    public float  walkSpeed;

    Transform target;

    public AudioSource impactSound;

    NavMeshAgent agent;

    public GameObject gutsPrefab;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<FPSController>().transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ChasePlayer();
    }

    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;
        float rand = Random.Range(0.9f, 1.1f);
        impactSound.pitch = rand;
        impactSound.Play();
        if(currentHealth <= 0)
        {
            GameObject zombieGuts = Instantiate(gutsPrefab, transform.position, transform.rotation, null);
            Destroy(gameObject);
            Destroy(zombieGuts, 2);
        }
    }

    void ChasePlayer()
    {
        agent.destination = target.position;
    }
}

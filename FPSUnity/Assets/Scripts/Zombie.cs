using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;
    public float  walkSpeed;

    Transform target;

    public AudioSource impactSound;

    NavMeshAgent agent;

    public GameObject gutsPrefab;
   
    public Image healthBarFill;

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

        healthBarFill.fillAmount = currentHealth / maxHealth;

        if(currentHealth <= 0)
        {
            GameObject zombieGuts = Instantiate(gutsPrefab, transform.position, transform.rotation, null);
            Destroy(gameObject);
            Destroy(zombieGuts, 2);
            ZombieSpawner.Instance.CountZombies();
        }
    }

    void ChasePlayer()
    {
        agent.destination = target.position;
    }
}

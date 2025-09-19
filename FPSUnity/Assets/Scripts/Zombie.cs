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
    public Image healthBarBackground;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        target = FindObjectOfType<FPSController>().transform;

        agent = GetComponent<NavMeshAgent>();

        healthBarFill.enabled = false;
        healthBarBackground.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }

    public void TakeDamage(float damageToTake)
    {
        healthBarFill.enabled = true;
        healthBarBackground.enabled = true;
        currentHealth -= damageToTake;

        float rand = Random.Range(0.9f, 1.1f);

        getHitSound.pitch = rand;
        getHitSound.Play();

        healthBarFill.fillAmount = currentHealth/maxHealth;

        if (currentHealth <= 0)
        {
            GameObject spawnedZombieGuts = Instantiate(zombieGuts, transform.position, transform.rotation, null);
            ZombieSpawner.Instance.CountZombies();
            Destroy(gameObject);
            Destroy(spawnedZombieGuts, 5);
        }
    }

    void ChasePlayer()
    {
        agent.destination = target.position;
    }
}

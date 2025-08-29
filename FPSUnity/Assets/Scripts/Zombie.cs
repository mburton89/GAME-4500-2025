using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{ 
  public float maxHealth;
  float currentHealth;
  public AudioSource getHitSound;
  public GameObject zombieGuts;

  NavMeshAgent agent;
  Transform target;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<FPSController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
      ChasePlayer();
    }

    public void TakeDamage(float damageToTake)
    {
      currentHealth -= damageToTake;

      float rand = Random.Range (0.9f, 1.1f);
      getHitSound.pitch = rand;
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

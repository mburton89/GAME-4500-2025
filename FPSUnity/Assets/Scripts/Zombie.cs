using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    int currentHealth;
    public int maxHealth;
    public int attackDamage;
    float attackSpeed;
    FPSController player;
    bool canAttack = true;
    NavMeshAgent navMeshAgent;
    public GameObject bloodEffect;

    public AudioSource hitAudioSource;

    private void Start()
    {
        player = FindObjectOfType<FPSController>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        ChasePlayer();

    }

    public void TakeDamage(int damageDealt) // called by projectile
    {
        hitAudioSource.Play();

        currentHealth -= damageDealt;
        if (currentHealth <= 0)
        {
            Instantiate(bloodEffect, transform.position, transform.rotation, null);
            Destroy(gameObject);
        }
    }
    void DealDamge(FPSController player)
    {
        player.TakeDamage(attackDamage);
    }
    void ChasePlayer()
    {
        navMeshAgent.SetDestination(player.transform.position);
    }

    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player") && canAttack)
        {
            DealDamge(player);
        }
    }
}

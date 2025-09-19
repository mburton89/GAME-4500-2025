using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    int currentHealth;
    public int maxHealth, attackDamage;
    public float attackSpeed;
    FPSController player;
    bool canAttack;
    NavMeshAgent navMeshAgent;
    public GameObject bloodEffect;
    public Image zombieHealthBar;
    public AudioSource hitAudioSource;

    HealthBarVisibility healthBarVisibility;

    private void Start()
    {
        player = FindObjectOfType<FPSController>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
        canAttack = true;

        healthBarVisibility = GetComponentInChildren<HealthBarVisibility>();
    }

    private void Update()
    {
        ChasePlayer();
    }

    public void TakeDamage(int damageDealt) // called by projectile
    {
        healthBarVisibility.BecomeVisible();

        hitAudioSource.Play();

        currentHealth -= damageDealt;

        zombieHealthBar.fillAmount = (float)currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            GameObject zombieGutsOnFloor = Instantiate(bloodEffect, transform.position, transform.rotation, null);
            ZombieSpawner.Instance.CountZombies();
            Destroy(gameObject);
            Destroy(zombieGutsOnFloor, 2f);
        }
    }
    
    void ChasePlayer()
    {
        navMeshAgent.SetDestination(player.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<FPSController>() && canAttack)
        {
            player.TakeDamage(attackDamage);
            StartCoroutine(AttackCooldown(attackSpeed));
        }
    }

    IEnumerator AttackCooldown(float cooldown)
    {
        canAttack = false;
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }
}

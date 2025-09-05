using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;
    public float  walkSpeed;
    public AudioSource impactSound;
    public GameObject gutsPrefab;
    public Image hpBarFill;
    public int attackPower;
    
    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<FPSController>().transform;
        agent.speed = walkSpeed;
    }

    private void Start()
    {
        attackPower = ZomSpawner.instance.getWaveNum();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ChasePlayer();
        hpBarFill.transform.parent.LookAt(target);
    }

    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;
        float rand = Random.Range(0.9f, 1.1f);
        impactSound.pitch = rand;
        impactSound.Play();

        hpBarFill.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            ZomSpawner.instance.CountZombies();
            GameObject zombieGuts = Instantiate(gutsPrefab, transform.position, transform.rotation, null);
            Destroy(gameObject);
            Destroy(zombieGuts, 2);
        }
    }

    void ChasePlayer()
    {
        agent.destination = target.position;
    }

    public int getAttackPower()
    {
        return attackPower;
    }
}

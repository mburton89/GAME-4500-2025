using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Zombie : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;

    public AudioSource oof;

    NavMeshAgent agent;

    public Transform target;

    public GameObject zombieGuts;

    public Image healthBarFill;

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

        float rand = Random.Range(0.9f, 1.1f);
        oof.pitch = rand;
        oof.Play();

        healthBarFill.fillAmount = currentHealth / maxHealth;

        if (currentHealth < 0) 
        {
            GameObject guts = Instantiate(zombieGuts, transform.position, transform.rotation, null);
            ZombieSpawner.Instance.countZombies();
            Destroy(gameObject);
            Destroy(guts, 1);

        }
    }

    void ChasePlayer()
    {
        agent.destination = target.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<FPSController>()) { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); print("player died!"); }
        else if (collision.gameObject.GetComponent<Projectile>()) { Destroy(collision.gameObject); }
    }
}

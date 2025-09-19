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
    public float minDistance = 10f;

    public AudioSource oof;

    NavMeshAgent agent;

    public Transform target;

    public GameObject zombieGuts;

    public Image healthBarFill;
    public Canvas healthBarCanvas;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<FPSController>().transform;
        // healthBarCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
        // if (currentHealth != maxHealth) { healthBarCanvas.enabled = true; }
        if (Vector3.Distance(transform.position, target.position) < minDistance)
        {
            healthBarCanvas.enabled = true;
        }
        else { healthBarCanvas.enabled = false; }
    }

    public void TakeDamage(float damageToTake)
    {
        float rand = Random.Range(0.9f, 1.1f);
        oof.pitch = rand;
        oof.Play();

        currentHealth -= damageToTake;

        healthBarFill.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0) 
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

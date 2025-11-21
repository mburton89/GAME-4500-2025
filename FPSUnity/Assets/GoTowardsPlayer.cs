using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTowardsPlayer : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;
    public float speed;
    CubeSpawner cubeSpawner;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();
        cubeSpawner = FindFirstObjectByType<CubeSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Cube hit the player!");
            cubeSpawner.activeCubes.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}

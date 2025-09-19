using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public int damage;
    public float fuseTimer, throwSpeed;
    public GameObject grenadeExplosionEffect;

    bool exploding;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fuse());
        exploding = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Fuse()
    {
        yield return new WaitForSeconds(fuseTimer);
        Explode();
    }

    void Explode()
    {
        Instantiate(grenadeExplosionEffect);
        exploding = true;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (exploding && collision.gameObject.GetComponent<Zombie>())
        {
            collision.gameObject.GetComponent<Zombie>().TakeDamage(damage);
        }
    }
}

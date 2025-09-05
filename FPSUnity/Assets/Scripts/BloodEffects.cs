using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyEffect());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestroyEffect()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}

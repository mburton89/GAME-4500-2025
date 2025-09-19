using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponInput : MonoBehaviour
{
    public KeyCode grenadeKey;
    public GameObject grenade, gun;
    public float grenadeForceMult;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(grenadeKey))
        {
            GameObject g = Instantiate(grenade, gun.transform.position, Quaternion.identity);
            g.GetComponent<Rigidbody>().AddForce(grenadeForceMult * (gun.transform.forward), ForceMode.Force);
        }
    }
}

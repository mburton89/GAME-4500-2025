using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FPSController player = other.GetComponent<FPSController>();
            if (player != null && player.cannon != null)
            {
                player.cannon.AddAmmmo(ammoAmount);
            }

            Destroy(gameObject);

        }
    }








}

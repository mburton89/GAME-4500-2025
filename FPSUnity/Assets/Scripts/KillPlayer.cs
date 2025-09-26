using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<FPSController>())
        {
           GameManager.instance.RestartGame(); //NEW
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FPSController>())
        {
            GameManager.instance.RestartGame();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{

    public Image hpFill;
    public Player playerObject;

    private float currentHealth;
    private float fillHP;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = playerObject.getHealth();
        //playerObject = transform.parent.parent.GetComponent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        fillHP = currentHealth / playerObject.maxHealth;
        hpFill.fillAmount = fillHP;
    }
}

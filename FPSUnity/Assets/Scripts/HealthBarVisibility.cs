using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarVisibility : MonoBehaviour
{
    Image[] hb;
    public int secondsToShow = 3;
    void Start()
    {
        hb = GetComponentsInChildren<Image>();
        for (int i = 0; i < hb.Length; i++)
        {
            hb[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BecomeVisible()
    {
        StartCoroutine(SetHealthBarVisibility());
    }

    IEnumerator SetHealthBarVisibility()
    {
        for(int i = 0; i < hb.Length; i++)
        {
            hb[i].enabled = true;
            Debug.Log(hb[i].name+"enabled");
        }
        yield return new WaitForSeconds(secondsToShow);
        for (int i = 0; i < hb.Length; i++)
        {
            hb[i].enabled = false;
        }
    }
}

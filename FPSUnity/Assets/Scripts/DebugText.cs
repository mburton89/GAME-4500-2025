using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugText : MonoBehaviour
{
    public static DebugText instance;

    public TextMeshProUGUI debug;

    private void Awake()
    {
        instance = this; 
    }

    public void UpdateDebugText(string message)
    {
        debug.SetText(message);
    }
}

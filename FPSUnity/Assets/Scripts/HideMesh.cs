using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMesh : MonoBehaviour
{
    MeshRenderer mesh;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    public void Hide()
    { 
        mesh.enabled = false;

        DebugText.instance.UpdateDebugText("mesh.enabled: " + mesh.enabled);
    }
}

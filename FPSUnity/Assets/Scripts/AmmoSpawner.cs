using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmmoSpawner : MonoBehaviour
{
    public List<GameObject> ammoSpawners;

    public int ammoCooldownTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator AmmoReloadCo()
    {
        yield return new WaitForSeconds(ammoCooldownTime);

        
    }
}

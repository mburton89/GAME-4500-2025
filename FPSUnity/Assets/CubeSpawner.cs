using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public List<GameObject> activeCubes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckCubeSpawn();
    }

    void CheckCubeSpawn()
    {
        if (activeCubes.Count<5)
        {
            SpawnCube();
        }
    }

    void SpawnCube()
    {
        activeCubes.Add(Instantiate(cubePrefab, new Vector3(Random.Range(-10,10), Random.Range(-10, 10), Random.Range(-10, 10)), Quaternion.identity));
    }
}

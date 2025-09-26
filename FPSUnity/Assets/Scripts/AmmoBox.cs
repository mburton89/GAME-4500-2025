using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public float spinSpeed;
    public float bounceSpeed;
    public float bounceDistance;
    float bounceDistanceMaxY;
    float bounceDistanceMinY;


    // Start is called before the first frame update
    void Start()
    {
        bounceDistanceMaxY = transform.position.y + bounceDistance;
        bounceDistanceMinY = transform.position.y - bounceDistance;
    }

    // Update is called once per frame
    void Update()
    {
        //spin
        transform.Rotate(Vector3.up *  spinSpeed * Time.deltaTime);

        //bob up and down
        transform.position += new Vector3(0, bounceSpeed, 0);
        if (transform.position.y > bounceDistanceMaxY && bounceSpeed > 0)
        {
            bounceSpeed = bounceSpeed * -1;
        }

        if (transform.position.y < bounceDistanceMinY && bounceSpeed < 0)
        {
            bounceSpeed = bounceSpeed * -1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FPSController>())
        {
            Cannon.Instance.AddAmmo();
            Destroy(gameObject);
        }
    }
}

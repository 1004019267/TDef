using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float speed = 10;
    bool isOn = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.y < 0.3&&isOn==true)
        {
            transform.Rotate(Vector3.up, speed * Time.deltaTime);
        }
        if (transform.rotation.y >0.3)
        {
            isOn = false;
        }
        if (isOn==false)
        {
            transform.Rotate(Vector3.down, speed * Time.deltaTime);
        }
        if (transform.rotation.y < -0.3)
        {
            isOn = true;
        }

    }
}

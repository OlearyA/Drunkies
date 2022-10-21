using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public carGen carGen;
    public float speed;
    public bool incoming;
    // Start is called before the first frame update
    void Start()
    {
        if (incoming) 
        { 
        speed = carGen.GetComponent<carGen>().getSpeedIncoming();
        }
        else
        {
        speed = carGen.GetComponent<carGen>().getSpeedOncoming();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (incoming)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}

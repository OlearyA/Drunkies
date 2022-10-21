using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class road : MonoBehaviour
{
    // Start is called before the first frame update
    public roadGen roadGen;
    public float speed;
    public bool incoming;
    void Start()
    {
        speed = roadGen.GetComponent<roadGen>().speed;
        Invoke("kys", 13f);
    }

    // Update is called once per frame
    void Update()
    {
        if (incoming)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }
    void kys()
    {
        Destroy(gameObject);
    }
}

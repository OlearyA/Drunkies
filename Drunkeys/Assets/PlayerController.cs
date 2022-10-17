using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horInput, verInput;
    Rigidbody rb;
    public float speed,rotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        getInput();
        transform.Rotate(0, Time.deltaTime * rotSpeed * horInput, 0, Space.Self);

        //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, verInput) * speed * Time.deltaTime;
        transform.position += transform.forward * Time.deltaTime * speed* verInput;
        
    }
    private void getInput()
    {
        horInput = Input.GetAxis("Horizontal");
        verInput = (Input.GetAxis("Vertical") + 1F) / 2;
    }
}

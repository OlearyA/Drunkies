using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
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

        rb.velocity = new Vector3(horInput, rb.velocity.y, verInput) * speed * Time.deltaTime;
       // transform.position += transform.forward * Time.deltaTime * speed* verInput;
        //rotate a little with dirrectional press
    }
    private void getInput()
    {
        horInput = Input.GetAxis("Horizontal");
        verInput = (Input.GetAxis("Vertical")) / 2;
    }
    private void scream()
    {
        audioSource.PlayOneShot(audioClipArray[1]);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("car"))
        {

            audioSource.PlayOneShot(audioClipArray[0]);
            Invoke("scream", 0.5f);
            //game over
        }
        if (collision.gameObject.CompareTag("PlayerDeath"))
        {
            audioSource.PlayOneShot(audioClipArray[0]);
            Invoke("scream", 0.5f);
            //game over
        }

    }
}

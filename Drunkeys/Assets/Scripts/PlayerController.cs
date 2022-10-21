using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    public float horInput, verInput;
    Rigidbody rb;
    public float speed,rotSpeed;
    public bool buffer,start;
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        buffer = true;
        start = false;
    }
    private void Update()
    {
        if (Input.anyKey)
        {
            start = true;
            image.SetActive(false);
        }

        if (start == true)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;

        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
        // Update is called once per frame
        void FixedUpdate()
    {
        getInput();
        rb.velocity = new Vector3(horInput, rb.velocity.y, verInput) * speed * Time.deltaTime;
        // transform.position += transform.forward * Time.deltaTime * speed* verInput;
        //rotate a little with dirrectional press
        if (buffer)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                audioSource.PlayOneShot(audioClipArray[2]);
                buffer = false;
                Invoke("bufferT", 1f);
            }
            if (Input.GetKey(KeyCode.E))
            {
                audioSource.PlayOneShot(audioClipArray[3]);
                buffer = false;
                Invoke("bufferT", 1f);
            }
            
        }

        
    }
    void bufferT()
    {
        buffer = true;
    }
    private void getInput()
    {
        horInput = Input.GetAxis("Horizontal");
        verInput = (Input.GetAxis("Vertical"));

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
            Invoke("Restart", 1.2f);
        }
        if (collision.gameObject.CompareTag("PlayerDeath"))
        {
            audioSource.PlayOneShot(audioClipArray[0]);
            Invoke("scream", 0.5f);
            Invoke("Restart", 1.2f);
        }

    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

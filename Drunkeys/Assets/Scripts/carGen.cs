using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carGen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject taxi, car, suv;
    public float minOncomingSpeed, maxOncomingSpeed, minIncomingSpeed, maxIncomingSpeed, minSpawnTime,maxSpawnTime;
    private float spawnTime;
    public Vector3 OncomingSpawn, IncomingSpawn;
    public bool offCooldown;
    void Start()
    {
        spawnTime = 5f;
        offCooldown = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (offCooldown)
        {
            Invoke("genACar", spawnTime);
            offCooldown = false;
        }
    }
    public float getSpeedOncoming()
    {
        float t = Random.Range(minOncomingSpeed, maxOncomingSpeed);
        return t;
    }
    public float getSpeedIncoming()
    {
        float t = Random.Range(minIncomingSpeed, maxIncomingSpeed);
        return t;
    }
    void genACar()
    {
        int temp= Random.Range(1,7);
        switch (temp)
        {
            case 1:
                GameObject truck = Instantiate(taxi, OncomingSpawn, transform.rotation);
                truck.transform.Rotate(0f, 180f, 0f);
                truck.GetComponent<Car>().carGen = this;
                truck.GetComponent<Car>().incoming = false;
                break;
            case 2:
                GameObject truck1 = Instantiate(car, OncomingSpawn, transform.rotation);
                truck1.transform.Rotate(0f, 180f, 0f);
                truck1.GetComponent<Car>().carGen = this;
                truck1.GetComponent<Car>().incoming = false;
                break;
            case 3:
                GameObject truck2 = Instantiate(suv, OncomingSpawn, transform.rotation);
                truck2.transform.Rotate(0f, 180f, 0f);
                truck2.GetComponent<Car>().carGen = this;
                truck2.GetComponent<Car>().incoming = false;
                break;
            case 4:
                GameObject truck3 = Instantiate(taxi, IncomingSpawn, transform.rotation);
                truck3.GetComponent<Car>().carGen = this;
                truck3.GetComponent<Car>().incoming = true;
                break;
            case 5:
                GameObject truck4 = Instantiate(car, IncomingSpawn, transform.rotation);
                truck4.GetComponent<Car>().carGen = this;
                truck4.GetComponent<Car>().incoming = true;
                break;
            case 6:
                GameObject truck5 =Instantiate(suv, IncomingSpawn, transform.rotation);
                truck5.GetComponent<Car>().carGen = this;
                truck5.GetComponent<Car>().incoming = true;
                break;
            default:break;
        }
        offCooldown = true;
    }
}


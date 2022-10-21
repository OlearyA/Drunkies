using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadGen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject road, houseTileOne, houseTileTwo, lightPost, trashCan;
    public bool roadIsUp, leftIsUp, LightIsUp, trashIsUp;
    public float speed, timeTillNextRoad,timeUntillNextHouse, timeUntillNextLight,timeUntillNextTrash;
    public Vector3  nextRoadSpawn, leftSideSpawn, leftSideSpawn2,rightSideSpawn, rightSideSpawn2, nextLightSpawnLeft, nextLightSpawnRight, nextCanSpawnLeft, nextCanSpawnRight;
    void Start()
    {
        roadIsUp = true;
        leftIsUp = true;
        LightIsUp = true;
        trashIsUp = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (roadIsUp)
        {
            spawnRoad();
            roadIsUp = false;
            Invoke("roadTimer", timeTillNextRoad);
        }
        if (leftIsUp)
        {
            spawnLeftSide();
            spawnRightSide();
            leftIsUp = false;
            Invoke("leftTimer", timeUntillNextHouse);
        }
        if (LightIsUp)
        {
            spawnStreetLight();
            LightIsUp = false;
            Invoke("lightTimer", timeUntillNextLight);
        }
        if (trashIsUp)
        {
            spawnTrashCan();
            trashIsUp = false;
            Invoke("trashTimer", timeUntillNextTrash);
        }
    }
    void spawnRoad()
    {
        GameObject temp = Instantiate(road, nextRoadSpawn, Quaternion.identity);
        temp.GetComponent<road>().roadGen = this;
        temp.GetComponent<road>().incoming = false;

    }
    void roadTimer()
    {
        roadIsUp = true;
    }
    void leftTimer()
    {
        leftIsUp = true;
    }
    void lightTimer()
    {
        LightIsUp = true;
    }
    void trashTimer()
    {
        trashIsUp = true;
    }
    void spawnLeftSide()
    {
        int tempn = Random.Range(1, 3);
        if (tempn == 1)
        {
            GameObject temp1 = Instantiate(houseTileTwo, leftSideSpawn2, Quaternion.identity);
            temp1.transform.Rotate(0f, 180f, 0f);
            temp1.GetComponent<road>().roadGen = this;
            temp1.GetComponent<road>().incoming = true;
        }
        else
        {
            GameObject temp1 = Instantiate(houseTileOne, leftSideSpawn, Quaternion.identity);
            temp1.GetComponent<road>().roadGen = this;
            temp1.GetComponent<road>().incoming = false;
        }
        
    }
    void spawnRightSide()
    {
        int tempn = Random.Range(1, 3);
        if (tempn == 1)
        {
            GameObject temp1 = Instantiate(houseTileTwo, rightSideSpawn, Quaternion.identity);
            temp1.GetComponent<road>().roadGen = this;
            temp1.GetComponent<road>().incoming = false;
        }
        else
        {
            GameObject temp1 = Instantiate(houseTileOne, rightSideSpawn2, Quaternion.identity);
            temp1.transform.Rotate(0f, 180f, 0f);
            temp1.GetComponent<road>().roadGen = this;
            temp1.GetComponent<road>().incoming = true;
        }
    }
    void spawnStreetLight()
    {

        GameObject temp = Instantiate(lightPost, nextLightSpawnLeft, Quaternion.identity);
        GameObject temp1 = Instantiate(lightPost, nextLightSpawnRight, Quaternion.identity);
        temp1.transform.Rotate(0f, 180f, 0f);
        temp.GetComponent<road>().roadGen = this;
        temp.GetComponent<road>().incoming = false;
        temp1.GetComponent<road>().roadGen = this;
        temp1.GetComponent<road>().incoming = true;
    }
    void spawnTrashCan()
    {

        GameObject temp4 = Instantiate(trashCan, nextCanSpawnLeft, Quaternion.identity);
        GameObject temp3 = Instantiate(trashCan, nextCanSpawnRight, Quaternion.identity);
        temp3.transform.Rotate(0f, 180f, 0f);
        temp4.transform.Rotate(0f, 180f, 0f);
        temp4.GetComponent<road>().roadGen = this;
        temp4.GetComponent<road>().incoming = true;
        temp3.GetComponent<road>().roadGen = this;
        temp3.GetComponent<road>().incoming = true;
    }

}


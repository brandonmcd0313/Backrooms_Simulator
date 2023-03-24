using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSequence : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        //set player to semi random rotation
        float xPos = Random.Range(-30f, 30f);
        float yPos = Random.Range(-30f, 30f);
        float zPos = Random.Range(-30f, 30f);
        transform.Rotate(xPos /** 2 * Time.deltaTime z*/,
            yPos /** 2 * Time.deltaTime */,
            zPos /** 2 * Time.deltaTime */);
        //start the wobble
        StartCoroutine(wobble());
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator wobble()
    {
        /*
        for (int i = 0; i < 2; i++)
        {
            //rotate it randomly by -5 to 5 degrees every 0.1 sec
            //will create dizzyign effect
            yield return new WaitForSeconds(0.05f);
            float xPos = Random.Range(-15f, 15f);
            float yPos = Random.Range(-15f, 15f);
            float zPos = Random.Range(-15f, 15f);
            transform.Rotate(xPos * 2 * Time.deltaTime ,
                yPos * 2 * Time.deltaTime, 
                zPos * 2 * Time.deltaTime);
        }
       */

        //set to correct position slowly
        for (int i = 0; i < 80; i++)
        {
            yield return new WaitForSeconds(0.05f);
            //starts moving positions towards 0 by 
            //one third of themselves
            //if neg double negative is addition
            //if positive is substraction normal
            //moving towards 0
            transform.Rotate(transform.rotation.x / -0.2f, 0 ,0);
            
            transform.Rotate(0, 0, transform.rotation.z / -0.2f);

            //y handing
            /*
            if(transform.rotation.y > -90)
            {
                //need to subtract
                transform.Rotate(0, Random.Range(-0f, -0.1000f), 0);
            }
            else
            {
                //need to add
                transform.Rotate(0, Random.Range(0f, 0.1000f), 0);
            }
            */
            
        }
        //last call - y is controleld by player
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, eulerRotation.y, 0);

    }
}

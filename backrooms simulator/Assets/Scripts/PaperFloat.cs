using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperFloat : MonoBehaviour {

    Rigidbody rb;
    public float forcehigh = 20f;
    public float forcelow = 20f;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        rb = GetComponent<Rigidbody>();
        StartCoroutine(shake());
        StartCoroutine(wobble());
    }


    IEnumerator shake()
    {
        for (int i = 0; i < 15; i++)
        {
            if (rb.position.y > 0.1)
            {
                yield return new WaitForSeconds(0.1f);
                //random int 0- 5 (not inclusive)
                float direction = Random.Range(0f, 4f);
                //random force in range
                float force = Random.Range(forcelow, forcehigh);
                //can do x,y,z
                //x 0-1
                if (direction < 1)
                    rb.AddForce(force, 0, 0);
                //y 1-2
                else if (direction < 2)
                    rb.AddForce(0, force / 2, 0);
                //z all else
                else
                    rb.AddForce(0, 0, force);

            }
        }
    }

    IEnumerator wobble()
    {
        for (int i = 0; i < 10; i++)
        {
            if (rb.position.y > 0.1)
            {
                //rotate it randomly by -5 to 5 degrees every 0.1 sec
                //will create dizzyign effect
                yield return new WaitForSeconds(0.1f);
                float xPos = Random.Range(-5f, 5f);
                float yPos = Random.Range(-5f, 5f);
                float zPos = Random.Range(-5f, 5f);
                transform.Rotate(xPos, yPos,zPos);
            }
        }
        
    }
}

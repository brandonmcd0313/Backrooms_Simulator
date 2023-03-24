using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyManage : MonoBehaviour
{
    bool canDie = true;
    public bool dying = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void tryKill(GameObject other)
    {
        if (!dying)
        {
            StartCoroutine(destroy(other));
            //if destroying the door destroy it paper too
            if (this.gameObject.name == "Door")
            {
                StartCoroutine(destroy(GameObject.Find("DoorPaper")));
                //destroying door create the spawners for monsters
                GameObject.Find("SpawnerManager")
                   .GetComponent<CreateSpawners>().StartSpawnings();
            }

        }
    }

    IEnumerator destroy(GameObject other)
    {
        dying = true;
        yield return new WaitForSeconds(5);
        if (canDie)
        {
            Destroy(other);
        }
        else
        {
            while (!canDie)
            {
                yield return new WaitForSeconds(0.5f);
            }
            Destroy(other);
        }

    }

    void OnTriggerStay(Collider other)
    {
        //print(name + " is in " + other.name);
        //if not player move the wall out of the trigger zone
        if (other.tag == "Player" || other.tag == "WallStop")
        {
            //in the player 
            //DONT DIE
            canDie = false;
            //print("set " + name + " to false");
        }

    }

    void OnTriggerExit(Collider other)
    {
        //when leaves player no move zone
        //allow it to move
        if (other.tag == "Player" || other.tag == "WallStop")
        {
            canDie = true;
            //print("set " + name + " to true");
        }
    }


}
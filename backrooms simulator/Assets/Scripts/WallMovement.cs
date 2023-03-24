using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
	bool canMove = false;
	bool direction; //true = x, false = z

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void move()
	{
		//if in time to move and it isnt in player
		if (canMove)
		{
			//print("moving " + name);
			direction = Random.Range(1, 3) == 2; //50 50 true false
			if (direction) //x
			{
				float xPos = Random.Range(-5f, 5f);
				transform.parent.transform.position += new Vector3(xPos, 0, 0);
			}
			else //z
			{
				float zPos = Random.Range(-5f, 5f);
				transform.parent.transform.position += new Vector3(0, 0, zPos);
			}
		}
	}

	//when in another wall
	void OnTriggerStay(Collider other)
	{
		//print(name + " is in " + other.name);
		//if not player move the wall out of the trigger zone
		if(other.tag == "Player" || other.tag == "WallStop")
		{
			//in the player 
		    //DONT MOVE
			canMove = false;
			//print("set " + name + " to false");
		}
		else
        {
			//neither runs if it can't move or in floor
			if (direction && canMove && other.tag != "Floor") //x
				transform.parent.transform.position += new Vector3(-1, 0, 0);
			else if (canMove && other.tag != "Floor") //z
				transform.parent.transform.position += new Vector3(0, 0, -1);
		}


		

	}

	void OnTriggerExit(Collider other)
    {
		//when leaves player no move zone
		//allow it to move
		if(other.tag == "Player" || other.tag == "WallStop")
        {
			canMove = true;
			//print("set " + name + " to true");
		}
    }

	/*
	IEnumerator WallTiming()
	{
		while (true)
		{
			timer = false;
			yield return new WaitForSeconds(10);
			timer = true;
			yield return new WaitForSeconds(1);

		}
	}
	*/
}

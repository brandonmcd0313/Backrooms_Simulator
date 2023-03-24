using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		StartCoroutine(RayTiming());
	}
	
	// Update is called once per frame
	void Update () {
		


		//raycast in the directon we are facing
		//	 see if we hit anything
		/*
		if (Physics.Raycast(
			transform.position, transform.right, 5))
		{
			GameObject hit = Physics.Raycast(
				transform.position, transform.right, 5).collider.
				gameObject;

			print("Detected" + hit.name);
			//turn the game object red
			hit.GetComponent<SpriteRenderer>().color = Color.red;
		}
		*/
	}

	IEnumerator RayTiming()
	{
		while (true)
		{
			yield return new WaitForSeconds(1);
			Ray ray = new Ray(transform.position, -transform.forward);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 50f))
			{
				//transform.position = ray.GetPoint(100.0f);
				//print("Detected" + hit.collider.name);
				//print(hit.collider.gameObject.transform.parent.name);
				if (hit.collider.gameObject.
					GetComponent<WallMovement>() != null && hit.collider.gameObject.tag
					!= "floor")
				{
					//print("detected " + hit.collider.gameObject.transform.parent.name);
					hit.collider.gameObject.
						GetComponent<WallMovement>().move();
				}
				//turn the game object red
				//hit.collider.GetComponent<Renderer>().color = Color.red;

			}
		}
		
	}


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleporter : MonoBehaviour {
	// Use this for initialization
	bool canTele = true;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
			if (other.tag == "TeleporterX" && canTele)
		{
			print("teleported from " + other.tag);
				transform.parent.transform.position = new Vector3(
					transform.position.x, transform.position.y, -113.3f);
			StartCoroutine(cooldown());
			if(GameObject.Find("Spawn Trigger").
				GetComponent<SpawnMonster>().monst != null)
            {
				GameObject.Find("Spawn Trigger").
				GetComponent<SpawnMonster>().monst
					.GetComponent<ChasingAI>().teleport(0, 0, -250.1f);

			}

		}

			if (other.tag == "TeleporterY" && canTele)
		{
			print("teleported from " + other.tag);
			transform.parent.transform.position = new Vector3(
					transform.position.x, transform.position.y, 136.8f);
			StartCoroutine(cooldown());
			if (GameObject.Find("Spawn Trigger").
				GetComponent<SpawnMonster>().monst != null)
			{
				GameObject.Find("Spawn Trigger").
				GetComponent<SpawnMonster>().monst
					.GetComponent<ChasingAI>().teleport(0, 0, 250.1f);

			}

		}

			if (other.tag == "TeleporterZ" && canTele)
		{
			print("teleported from " + other.tag);
			transform.parent.transform.position = new Vector3(
					111.5f, transform.position.y, transform.position.z);
			StartCoroutine(cooldown());
			if (GameObject.Find("Spawn Trigger").
				GetComponent<SpawnMonster>().monst != null)
			{
				GameObject.Find("Spawn Trigger").
				GetComponent<SpawnMonster>().monst
					.GetComponent<ChasingAI>().teleport(201.7f, 0, 0);

			}

		}

			if (other.tag == "TeleporterA" && canTele)
		{
			print("teleported from " + other.tag);
			transform.parent.transform.position = new Vector3(
					-90.2f, transform.position.y, transform.position.z);
			StartCoroutine(cooldown());
			if (GameObject.Find("Spawn Trigger").
			GetComponent<SpawnMonster>().monst != null)
			{
				GameObject.Find("Spawn Trigger").
				GetComponent<SpawnMonster>().monst
					.GetComponent<ChasingAI>().teleport(-201.7f, 0, 0);

			}

		}
		
	} 

	IEnumerator cooldown()
    {
		canTele = false;
		yield return new WaitForSeconds(0.5f);
		canTele = true;
    }


}

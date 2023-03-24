using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpawnMonster : MonoBehaviour {

	public GameObject lid;
	public GameObject bin;
	Rigidbody lidrb;
	bool launched = false;
	public GameObject runImage;
    public GameObject monster;
	public GameObject monst;
	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startRel()
	{
		if (!launched)
		{
			print("begining release");
			//instaniate objects im gonna use
			//get lid rigidbody
			lidrb = lid.GetComponent<Rigidbody>();
			StartCoroutine(release());
		}
	}

	IEnumerator release()
    {
		print("launching");
		launched = true;
		//half sec after looking launch lid
		yield return new WaitForSeconds(0.5f);
        lidrb.AddForce(0, 1500, 0);
        yield return new WaitForSeconds(0.2f);
        lidrb.AddForce(Random.Range(1000, 2000), 0, Random.Range(1000, 2000));
        //UI message that says RUN ???
        yield return new WaitForSeconds(0.5f);
		GameObject clone = Instantiate(runImage);
		//monster spawns
		monst = Instantiate(monster);
		monst.transform.position = bin.transform.position;
		monst.transform.Translate(0, 0.5f, 0);
		yield return new WaitForSeconds(1.5f);
		Destroy(clone);
		//monster grows
		//it is at 0.25
		//increase by .01
		//go upto 1.75
		
		for (int i = 0; i < 170; i++)
        {
			yield return new WaitForSeconds(0.05f);
			monst.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
			

		}

		//steps out

		//gets to full size

		//start chasing player
		monst.GetComponent<ChasingAI>().initiate();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChasingAI : MonoBehaviour
{
	public bool initiated = false;
	GameObject target;
	public float speed;
	AudioSource aud;
	// Use this for initialization
	void Start()
	{
		aud = GetComponent<AudioSource>();
		target = GameObject.Find("Capsule");
		aud.Play();
		aud.loop = true;
	}
	// Update is called once per frame
	float timer = 0;
	void Update()
	{
		if (initiated)
		{
			timer += Time.deltaTime;
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position,
				new Vector3(target.transform.position.x, 0,
				target.transform.position.z), step);
			transform.LookAt(transform.position + target.transform.rotation
							* Vector3.left, target.transform.rotation * Vector3.up);
		}
	}

	public void teleport(float x, float y, float z)
    {
			print("moving " + x + " " + y + " " + z + " ");
			transform.position = new Vector3(
				transform.position.x + x,
				transform.position.y + y,
				transform.position.z + z);
	}

	public GameObject GetGameObject()
	{ return GetComponent<GameObject>(); }


	public void initiate()
	{
		
		initiated = true;
	}

	void OnTriggerEnter(Collider other) 
    {
		print("monst enter trig");
		if(other.tag == "Death")
        {
			print("die");
			//initate death sequence
			SceneManager.LoadScene("Death Scene");
		}
    }
	}


	


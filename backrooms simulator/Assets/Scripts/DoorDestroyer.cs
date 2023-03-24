using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDestroyer : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 40f))
		{
			//transform.position = ray.GetPoint(100.0f);
			//print("Detected" + hit.collider.name);
			//print(hit.collider.gameObject.transform.parent.name);
			if (hit.collider.gameObject.tag == "ToKill")
			{
                if (hit.collider.gameObject.
                    GetComponent<DestroyManage>() != null)
                {
                    hit.collider.gameObject.
                        GetComponent<DestroyManage>().
                        tryKill(hit.collider.gameObject);
                }
			}

			if (hit.collider.gameObject.tag == "MonsterSpawn")
            {
				print("found it");
				hit.collider.gameObject.GetComponent<SpawnMonster>().
						startRel();
			}
			//turn the game object red
			//hit.collider.GetComponent<Renderer>().color = Color.red;

		}
	}

	
}

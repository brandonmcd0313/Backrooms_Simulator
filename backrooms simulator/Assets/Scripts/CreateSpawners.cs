using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSpawners : MonoBehaviour
{

	public GameObject spawner;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void StartSpawnings()
	{
		StartCoroutine(SpawnTrashCans());
	}
	public IEnumerator SpawnTrashCans()
	{
		bool spawned = false;
		//every 12 seconds a new one spawns
		print("starting spawning");
		for (int i = 0; i < 100; i++)
		{
			
			GameObject spawn = Instantiate(spawner,
				new Vector3(Random.Range(-85f, 100f),
				9.551643f, Random.Range(-95f, 140f)),
				Quaternion.identity);
			print("spawed " + (i + 1));
			spawned = true;
			GameObject model = spawn.transform.GetChild(1).gameObject;
			GameObject bin = model.transform.GetChild(1).gameObject;
			yield return new WaitForSeconds(2f);
			//if it feel over... uhhh destroy it
			bool x = (Mathf.Abs(0 - bin.transform.rotation.x) < 1f);
			bool y = (Mathf.Abs(0 - bin.transform.rotation.y) < 1f);
			bool z = (Mathf.Abs(0 - bin.transform.rotation.z) < 1f);
			if (!(x && y && z))
            {
				print(x);
					print(y);
					print(z);
				Destroy(spawn);
				spawned = false;
            }
			if (spawned)
			{
				yield return new WaitForSeconds(10.5f);
			}
			spawned = false;
		}
	}
}

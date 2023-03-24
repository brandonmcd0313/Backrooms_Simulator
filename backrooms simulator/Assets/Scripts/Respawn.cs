using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator reload()
    {
		yield return new WaitForSeconds(11.5f);
		SceneManager.LoadScene("scene");
    }
}

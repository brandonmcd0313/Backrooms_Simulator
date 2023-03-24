using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(countdown());
	}
	
	IEnumerator countdown()
    {
        yield return new WaitForSeconds(22);
        SceneManager.LoadScene("scene");
    }
}

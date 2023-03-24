using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScript : MonoBehaviour
{
    public void Awake()
    {
		Screen.SetResolution(1024,768,false);
		

	}
	public void Load()
	{
		SceneManager.LoadScene("cutscene");
	}

    public void Credz()
    {
        SceneManager.LoadScene(5);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

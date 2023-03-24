using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{

    public float reset, increment;
    public float speed = 1.5f;
    // Use this for initialization
    void Start()
    {
        increment = reset;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(
            0, -(speed * Time.deltaTime));

        if(transform.position.y < -42)
        {
            SceneManager.LoadScene(0);
        }
    }
}

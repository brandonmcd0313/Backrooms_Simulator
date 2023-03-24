using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class SensManage : MonoBehaviour {
   
   float n;
   public Text myText;
   public Slider mySlider;
    public void Start()
    {
        mySlider.value = 0.2f;
    }

    void Update() {
        //use int casting to get to three decimals
        float holder = Mathf.Floor(mySlider.value * 100);
        n = holder / 100;
        n *= 10;
      myText.text = "Current Sensitivity: " + n
            + "\nRecommended : 2";
    }

    public void Exit()
    {
        SC_FPSController.lookSpeed = n;
        SceneManager.LoadScene(0);

    }
}


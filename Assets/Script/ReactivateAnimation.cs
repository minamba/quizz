using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReactivateAnimation : MonoBehaviour {
    // Use this for initialization
    public void Start() {

        try
        {
            GameObject.Find("Bulle").SetActive(false);
        }
        catch(Exception e)
        {
            GameObject.Find("BulleCharacter").SetActive(false);
        }

       
        if (GameOver.endGame == true)
        {
            Time.timeScale = 1;
        }
    }
}

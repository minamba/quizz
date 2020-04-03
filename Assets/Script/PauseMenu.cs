using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool showGUI = false;
    public static bool pause = false;
    public static bool tscale = false;
    public GameObject canvas;
    public static string nameCharact;

    // Update is called once per frame
    public void Start()
    {
        //canvas = GameObject.Find("CanvasGamePause");
    }

    public void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    showGUI = !showGUI;
        //    pause = showGUI;
        //    //Debug.Log("pause state : " + pause);
        //}

        //if (showGUI == true)
        //{
        //    nameCharact = Choice.buttonName;
        //    //Debug.Log("jai appuyer sur pauuuuuse et le nom du joueur en cours est : " + nameCharact);
        //    canvas.SetActive(true);
        //    if (tscale == false)
        //    {
        //        Time.timeScale = 0;
        //        GameObject.Find("Canvas").GetComponent<HideControls>().Hide();
        //    }
        //    else
        //    {
        //        Time.timeScale = 1;
        //    }
        //    //Debug.Log("le temps s'arrette");
        //}
        //else
        //{
        //    canvas.SetActive(false);
        //}
    }
}

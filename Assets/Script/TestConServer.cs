using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConServer : MonoBehaviour {
    public GameObject canvasError;
    private static bool a = false;
    private static bool b = false;
    CallWebService cwb = new CallWebService();

    // Use this for initialization
    void Start () {
        canvasError = GameObject.Find("CanvasError");
        canvasError.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (TestConnection() != false)
        {
            b = false;
            if (a == false)
            {

                canvasError.SetActive(true);
                a = true;
            }
        }
        else
        {
            a = false;

            if (b == false)
            {
                canvasError.SetActive(false);
                b = true;
            }
        }

    }

    public bool TestConnection()
    {
        try
        {
            cwb.CharactersList();
            return false;
        }
        catch (Exception)
        {
            //canvasError.SetActive(true);
            return true;

        }
    }
}

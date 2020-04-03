using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionDropDown : MonoBehaviour {
    public static string dropDownSelected;
    public static string tempDropDownSelected = "empty";
    public GameObject canvasdeb;
    private static int idx;
    public Dropdown dd;
    public GameObject canvas;

    CallWebService ws = new CallWebService();
    //ws.CharactersList();

    // Use this for initialization
    void Start()
    {
        canvasdeb = GameObject.Find("Canvasd");
        ListofLevels();
    }

    void Update()
    {
        //Debug.Log("temp : "+tempDropDownSelected + " " +"selected : "+dropDownSelected);
        if (tempDropDownSelected != dropDownSelected)
        {
            tempDropDownSelected = dropDownSelected;
        }
    }

    public void Dropdown_IndexChanged(int index)
    {
        idx = index;


        tempDropDownSelected = dropDownSelected;
        dropDownSelected = ws.CharactersList()[index];
        //Debug.Log(tempDropDownSelected + dropDownSelected);
        //SceneManager.LoadScene(sceneBuildIndex: 4);
        //Dropdown_IndexChanged(idx);
        //dd.value = idx;
        UnityEngine.Canvas.ForceUpdateCanvases();


    }


    //GET LIST OF LEVELS
    void ListofLevels()
    {
        try
        {
            List<string> l = new List<string>();

            l.Add("Selectionnez votre niveau");
            foreach(var i in ws.GetLevels())
            {
                l.Add(i.l_name);
            }

            dd.AddOptions(l);
        }
        catch (Exception e)
        {
            //var mess = e.Message;
            //canvasdeb.GetComponentsInChildren<Text>()[0].text = mess;

            Console.WriteLine(e.Message);
        }
    }
}

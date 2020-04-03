using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DropDown : MonoBehaviour {
    public static string dropDownSelected;
    public static string tempDropDownSelected = "empty";
    public GameObject canvasdeb;
    private static int idx;
    public Dropdown  dd;
    public GameObject canvas;
    
    CallWebService ws = new CallWebService();
    //ws.CharactersList();

    // Use this for initialization
    void Start()
    {
        canvasdeb = GameObject.Find("Canvasd");
        ListofCharacters();
    }

     void Update()
    {
        //Debug.Log("temp : "+tempDropDownSelected + " " +"selected : "+dropDownSelected);
        if (tempDropDownSelected != dropDownSelected)
        {
            tempDropDownSelected = dropDownSelected;
            GameObject.Find("Canvas").GetComponent<SaveDatas>().RefreshScoreTable();
            
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


    //GET LIST OF CHARACTERS
    void ListofCharacters() {
        try
        {
            dd.AddOptions(ws.CharactersList());
        }
        catch(Exception e)
        {
            var mess = e.Message;
            canvasdeb.GetComponentsInChildren<Text>()[0].text = mess;
        }
    }
}

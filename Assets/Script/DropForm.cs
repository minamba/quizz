using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DropForm : MonoBehaviour
{
    public static string dropDownSelectedSexe;
    public Dropdown dds;
    public GameObject canvas;
    private List<string> sexeList = new List<string>();

    // Use this for initialization
    public void Start()
    {
        ListofSexe();
    }

    public void Dropdown_IndexChanged(int index)
    {
        dropDownSelectedSexe = sexeList[index];
        //Debug.Log(dropDownSelectedSexe);
    }

    // Update is called once per frame
    public void ListofSexe()
    {
        sexeList.Add("Selectionnez votre sexe");
        sexeList.Add("Homme");
        sexeList.Add("Femme");
        dds.AddOptions(sexeList);
    }
}

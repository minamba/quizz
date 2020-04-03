using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DropForm : MonoBehaviour
{
    public static string dropDownSelectedSexe;
    public static string dropDownSelectedLevel;
    public Dropdown dds;
    public Dropdown ddl;
    public GameObject canvas;
    private List<string> sexeList = new List<string>();

    CallWebService webServ = new CallWebService();


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


    public void DropdownLevel_IndexChanged(int index)
    {

        var datas = webServ.GetLevels();
        List<string> lev = new List<string>();

        lev.Add("Selectionnez votre niveau");
        foreach (var i in datas)
        {
            lev.Add(i.l_name);
         }

        dropDownSelectedLevel = lev[index];

        //Debug.Log(dropDownSelectedLevel);
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

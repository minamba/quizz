using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownStatus : MonoBehaviour {

    public static string dropDownSelectedStatus;
    public Dropdown dds;
    public GameObject canvas;
    private List<string> statusList = new List<string>();
    public GameObject canvasOn;
    public GameObject canvasBusy;
    public GameObject canvasOff;
    private static int s;
    CallWebService webServ = new CallWebService();
    // Use this for initialization
    public void Start()
    {
        canvasOn = GameObject.Find("CanvasOn");
        canvasBusy = GameObject.Find("CanvasBusy");
        canvasOff = GameObject.Find("CanvasOff");
       
        ListofStatus();
        //LaunchStatus();
        //ShowStatus();
        StartCoroutine(LaunchStatus());

    }

    public void Dropdown_IndexChanged(int index)
    {
        dropDownSelectedStatus = statusList[index];
        int ss;

        if (dropDownSelectedStatus == "En ligne")
            ss = 1;
        else if (dropDownSelectedStatus == "Absent")
            ss = 2;
        else
            ss = 0;

        try
        {
            webServ.UserUpdateStatus(Deconnexion.pseudo, ss);
        }
        catch (Exception)
        {
            return;
        }

        ShowStatus();
        
        
        //Debug.Log(dropDownSelectedStatus);
    }

    // Update is called once per frame
    public void ListofStatus()
    {
        //statusList.Add("En ligne");
        //statusList.Add("Absent");
        //statusList.Add("Hors ligne");
        //dds.AddOptions(statusList);
    }

    public void ShowStatus()
    {
        switch (dropDownSelectedStatus)
        {
            case "En ligne":
                canvasOn.SetActive(true);
                canvasBusy.SetActive(false);
                canvasOff.SetActive(false);
                break;
            case "Absent":
                canvasBusy.SetActive(true);
                canvasOn.SetActive(false);
                canvasOff.SetActive(false);
                break;
            case "Hors ligne":
                canvasOff.SetActive(true);
                canvasOn.SetActive(false);
                canvasBusy.SetActive(false);
                break;
            default:
                canvasOn.SetActive(true);
                canvasBusy.SetActive(false);
                canvasOff.SetActive(false);
                break;
        }
    }

    public int GetStatusIndex()
    {
        int? status = webServ.GetUserStatus(Deconnexion.pseudo);
        string st;

        if (status == 1)
            st = "En ligne";
        else if (status == 2)
            st = "Absent";
        else
            st = "Hors ligne";

            for (int i = 0; i < statusList.Count; i++)
            {
                if (st == statusList[i].ToString())
                {
                    Debug.Log(status);
                    return i;
                }
            }
        return 0;
    }



    public IEnumerator LaunchStatus()
    {
        yield return new WaitForSeconds((float)0.001);
        s = GetStatusIndex();
        dds.value = s;
        Dropdown_IndexChanged(s);
    }
}

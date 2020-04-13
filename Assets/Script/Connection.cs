﻿using Assets.Script;
using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Connection : MonoBehaviour
{
    CallWebService webServ = new CallWebService();
    public UserStatus datas;
    public UserStatus datas2;
    public UserStatus datas3;
    public GameObject PseudoG;
    public GameObject PWDG;
    public  GameObject canvasFormC;
    private string destination;
    public static string currentUser;
    public static int currentUserLevel;
    private static bool canVisible = false;
    

    // Use this for initialization
    void Start()
    {

        canvasFormC = GameObject.Find("CanvasErrorFormC");     
        PseudoG = GameObject.Find("CanvasPseudo");
        PWDG = GameObject.Find("CanvasPwd");
 
        UserStatus();
    }


     void Update()
    {
        try
        {
            if (canVisible == false)
            {
                canvasFormC.SetActive(false);
            }
            else
            {
                canvasFormC.SetActive(true);
                canvasFormC.GetComponentsInChildren<Text>()[1].text = "Vos informations de connexion ne sont pas valide !";
            }
        }
        catch { }
    }

    public void CallUserConnexion()
    {
        StartCoroutine(UserConnexion());
    }

    //USER CONNECTION
    public IEnumerator UserConnexion()
    {
        yield return new WaitForSeconds(0);
        string pseudo = PseudoG.GetComponentsInChildren<Text>()[1].text;
        string pwd = PWDG.GetComponentsInChildren<InputField>()[0].text;

        //Debug.Log("pseuuudo :::::::  " + pseudo);
        //Debug.Log("pwd :::::::  " + pwd);
        try
        {
            if (webServ.UserConnection(pseudo, pwd) == true)
            {
                UserCreateStatus(pseudo); //création du fichier de connexion l'orsque l'utilisateur se connecte
                Application.LoadLevel("MainMenu");
            }
            else
            {
                canVisible = true;
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    //CREATION DU STATUS DE CONNECTION DE LUTILISATEUR (1 = en ligne, 0 = deconnecté)
    public void UserCreateStatus(string pseudo)
    {
        StreamWriter sw1;
        //Debug.Log("delete data : " + deleteData);
        string destination = Application.persistentDataPath + "/user.json";
        //Debug.Log(destination);
        try
        {
            var user = webServ.GetUserByPseudo(pseudo);
            int lid = int.Parse(user.u_fk_level_id.ToString());

            if (!File.Exists(destination))
            {
                sw1 = System.IO.File.CreateText(destination);
                sw1.Close();
                datas = new UserStatus(pseudo, 1, user.sexe, lid, true);
                string jnDataString = JsonUtility.ToJson(datas, true);
                sw1 = new StreamWriter(destination);
                sw1.WriteLine(jnDataString);
                sw1.Close();
            }
            else
            {
                string loadedDatas = File.ReadAllText(destination);
                datas2 = JsonUtility.FromJson<UserStatus>(loadedDatas);

                datas = new UserStatus(pseudo, 1, user.sexe, lid,datas2.SoundPref);
                string jnDataString = JsonUtility.ToJson(datas, true);
                sw1 = new StreamWriter(destination);
                sw1.WriteLine(jnDataString);
                sw1.Close();
            }
        }
        catch (Exception e)
        {
            //Debug.Log(e.Message);
        }
    }

    //CETTE METHODE PERMET DE SAVOIR SI UN UTILISATEUR S'EST DEJAS CONNECTE UNE FOIS ET QU'IL NE S'EST PAS DECONNECTE DE SON PLEIN GRES
    public void UserStatus()
    {
        
        try
        {
#if UNITY_EDITOR
                     destination = Application.persistentDataPath + "/user.json";
#elif UNITY_ANDROID
                      destination = Application.persistentDataPath + "/user.json";
                            Debug.Log("SACAMACHE "+destination);
                      StartCoroutine(GetDataInAndroid(destination));
#endif
            //Debug.Log(destination);

            if (File.Exists(destination))
            {
                string loadedDatas = File.ReadAllText(destination);
                datas2 = JsonUtility.FromJson<UserStatus>(loadedDatas);

                if (datas2.Status == 1)
                {
                    Console.WriteLine(destination);
                    currentUser = datas2.UserPseudo;
                    Console.WriteLine("user level :" + currentUser);
                    currentUserLevel = datas2.Level;
                    Console.WriteLine("user level :" + datas2.Level);
                    Application.LoadLevel("MainMenu");
                }
            }
            else
            {
                //Debug.Log("Le fichier de connexion n'existe pas !");
            }
        }
        catch (Exception e)
        {
            //Debug.Log(e.Message);
        }

        canvasFormC.SetActive(false);
    }



    //TO LOAD FILE ON ANDROID
    IEnumerator GetDataInAndroid(string url)
    {
        //Debug.Log("je suis dans lemul android : " + url);

        WWW www = new WWW(url);
        yield return www;
        try
        {
            if (www.text != null)
            {
                string dataAsJson = www.text;
                UserStatus loadedData = JsonUtility.FromJson<UserStatus>(dataAsJson);
            }
        }
        catch (Exception e)
        {
            //GameObject.Find("Chemin").GetComponentsInChildren<Text>()[0].text = e.Message;
            //Debug.Log("t'as une erreur nogero : " +e.Message);
        }
    }


    public void CloseCanvasError()
    {
        canvasFormC = GameObject.Find("CanvasErrorFormC");
        canVisible = false;
    }



    public void CloseCanvasError2()
    {
        GameObject.Find("CanvasErrorFormRegister").SetActive(false);
    }


    //public IEnumerator HideCanvas()
    //{
    //    PauseMenu.tscale = true;
    //    yield return new WaitForSeconds((float)0.2);
    //    PauseMenu.tscale = false;
    //}
}

using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Deconnexion : MonoBehaviour {
    public UserStatus datas;
    public UserStatus datas2;
    public static string pseudo;
    CallWebService cwb = new CallWebService();

    // Use this for initialization
    void Start () {

        string destination = Application.persistentDataPath + "/user.json";
        //GameObject.Find("TextD").GetComponent<Text>().text = destination;
        ShowPlayerPseudo();
        ShowIcon();
    }

    //PERMET A L'UTILISATEUR DE SE DECONNECTER
    public void Deconnect()
    {
        StreamWriter sw1;
        string destination = Application.persistentDataPath + "/user.json";
        Debug.Log(destination);

        try
        {
            if (File.Exists(destination))
            {
                string loadedDatas = File.ReadAllText(destination);
                datas = JsonUtility.FromJson<UserStatus>(loadedDatas);

                if (datas.Status == 1)
                {
                    var UserSexe = cwb.GetUserByPseudo(datas.UserPseudo);
                    datas2 = new UserStatus(datas.UserPseudo, 0, UserSexe.sexe);
                    string jnDataString = JsonUtility.ToJson(datas2, true);
                    sw1 = new StreamWriter(destination);
                    sw1.WriteLine(jnDataString);
                    sw1.Close();
                    cwb.UserUpdateStatus(pseudo,0);
                    Application.LoadLevel("Connexion");
                }
            }
        }
        catch(Exception e)
        {
            GameObject.Find("TextD").GetComponent<Text>().text = e.Message;
        }
    }

    //SHOW PLAYER PSEUDO
    public void ShowPlayerPseudo()
    {
        try
        {
            StreamWriter sw1;
            string destination = Application.persistentDataPath + "/user.json";
            Debug.Log(destination);

            if (File.Exists(destination))
            {
                string loadedDatas = File.ReadAllText(destination);
                datas = JsonUtility.FromJson<UserStatus>(loadedDatas);
                pseudo = datas.UserPseudo;
                GameObject.Find("PseudoText").GetComponentsInChildren<Text>()[0].text = datas.UserPseudo;
            }
        }
        catch (Exception e)
        {
            GameObject.Find("TextD").GetComponent<Text>().text = e.Message;
        }
    }

    //SHOW USER ICON
    public void ShowIcon()
    {
        StreamWriter sw1;
        string destination = Application.persistentDataPath + "/user.json";
        //Debug.Log(destination);

        if (File.Exists(destination))
        {
            string loadedDatas = File.ReadAllText(destination);
            datas = JsonUtility.FromJson<UserStatus>(loadedDatas);
            GameObject.Find("Panel").GetComponentsInChildren<TextMesh>()[0].text = ": " + datas.UserPseudo;
            if(datas.Sexe == "Homme")
            {
                GameObject.Find("Havatar").SetActive(true);
                GameObject.Find("Favatar").SetActive(false);
            }
            else
            {
                GameObject.Find("Havatar").SetActive(false);
                GameObject.Find("Favatar").SetActive(true);
            }
        }
    }
}

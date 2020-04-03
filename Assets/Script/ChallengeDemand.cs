using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChallengeDemand : MonoBehaviour {
    private static int compteur;
    private static int compteur2;
    public static string candidatChallengeClicked;
    public bool b = false;
    public GameObject canvasdddd;
    string upseudo;
    public static string DemandeurCHallenge = Deconnexion.pseudo;
    CallWebService webServ = new CallWebService();
    t_alert_duel al = new t_alert_duel();
    t_users us = new t_users();
    bool a = false;
    private static bool m = false;
    public static bool challengeActivate = false;
    List<string> questionList = new List<string>();

    void Start()
    {
        canvasdddd = GameObject.Find("CanvasDefi");
        //canvasdddd.SetActive(false);

        if (a == false)
        {
            //GameObject.FindGameObjectWithTag("CanvasDefi").SetActive(false);
            a = true;
        }
         StartCoroutine(hide());
    }


    public IEnumerator hide()
    {
        yield return new WaitForSeconds((float)0);
        canvasdddd.SetActive(false);
    }

    public IEnumerator show()
    {
        yield return new WaitForSeconds((float)0);
        canvasdddd.SetActive(true);
    }

    public IEnumerator hide2()
    {
        yield return new WaitForSeconds((float)2);
        canvasdddd.SetActive(false);
    }


    public IEnumerator LaunchChallenge()
    {
        yield return new WaitForSeconds((float)3);
        GameObject.Find("Canvas").GetComponent<Choice>().LaunchGame(questionList);
        canvasdddd.SetActive(false);

    }

    //LAUNCH THE CHALLENGE///////////////////////////////////////////////////////////////////////////////////////////////////////
    public void ChallengePlayer()
    {
        GameObject.Find("Audio Click").GetComponent<AudioSource>().Play();// play level win sond
        //Debug.Log(DropDown.dropDownSelected);
        //canvasdddd.SetActive(true);
        StartCoroutine(show());
        StartCoroutine(StartCc());
        candidatChallengeClicked = EventSystem.current.currentSelectedGameObject.GetComponentsInChildren<Text>()[1].text;
        //Debug.Log(candidatChallengeClicked);
        webServ.RegisterAlertDuel(Deconnexion.pseudo, candidatChallengeClicked, DropDown.dropDownSelected);
        //DropDown.dd.value = 0;
        //DropDown.dd.Select();
        //DropDown.dd.RefreshShownValue();
    }


    // Update is called once per frame
    void Update()
    {
        //if (DropDown.dropDownSelected != null || DropDown.dropDownSelected != "Selectionnez un personnage")
        //{

        //    if (candidatChallengeClicked != null)
        //    {
        //        al = webServ.GetAlertDuel(Deconnexion.pseudo, candidatChallengeClicked, DropDown.dropDownSelected);
        //        upseudo = webServ.GetUserByPseudo(candidatChallengeClicked).u_pseudonym;

        //        if (al.a_accept != null)
        //        {
        //            if (al.a_accept == true)
        //            {
        //                GameObject.Find("AudioAccepted").GetComponent<AudioSource>().Play();// play level win sond   
        //                GameObject.Find("CanvasDefi").GetComponentsInChildren<Text>()[1].text = "Le joueur " + upseudo.Trim() + " a accepté votre demande !";
        //                questionList = GameObject.Find("Canvas").GetComponent<Choice>().ListOfQuestions(DropDown.dropDownSelected);
        //                challengeActivate = true;
        //                webServ.RegisterDuel(Deconnexion.pseudo, candidatChallengeClicked, DropDown.dropDownSelected);
        //                StartCoroutine(LaunchChallenge());
        //                try
        //                {
        //                    webServ.DeleteAlertDuel(Deconnexion.pseudo, candidatChallengeClicked, DropDown.dropDownSelected);
        //                }
        //                catch (Exception e)
        //                {
        //                    Debug.Log(e.Message);
        //                }
        //            }
        //            else
        //            {
        //                GameObject.Find("AudioRefused").GetComponent<AudioSource>().Play();// play level win sond   
        //                GameObject.Find("CanvasDefi").GetComponentsInChildren<Text>()[1].text = "Le joueur " + upseudo.Trim() + " a refusé votre challenge";
        //                StartCoroutine(hide2());
        //                try
        //                {
        //                    webServ.DeleteAlertDuel(Deconnexion.pseudo, candidatChallengeClicked, DropDown.dropDownSelected);
        //                    webServ.DeleteDuel(Deconnexion.pseudo, candidatChallengeClicked, DropDown.dropDownSelected);
        //                }
        //                catch (Exception e)
        //                {
        //                    Debug.Log(e.Message);
        //                }
        //            }

        //        }
        //        else
        //        {
        //            if (compteur > 0)
        //                GameObject.Find("CanvasDefi").GetComponentsInChildren<Text>()[1].text = "En attente de la réponse du joueur " + upseudo.Trim() + " : " + compteur;
        //            else
        //            {
        //                GameObject.Find("CanvasDefi").GetComponentsInChildren<Text>()[1].text = "Le joueur " + upseudo.Trim() + " n'a pas accepté votre challenge";
        //                StartCoroutine(hide2());
        //                try
        //                {
        //                    webServ.DeleteAlertDuel(Deconnexion.pseudo, candidatChallengeClicked, DropDown.dropDownSelected);
        //                }
        //                catch (Exception e)
        //                {
        //                    Debug.Log(e.Message);
        //                }
        //            }
        //        }
        //    }
        //}

    }


    public void DeleteDemand()
    {
        GameObject.Find("Audio Click").GetComponent<AudioSource>().Play();// play level win sond
        StartCoroutine(hide());
        try
        {
            webServ.DeleteAlertDuel(Deconnexion.pseudo, candidatChallengeClicked, DropDown.dropDownSelected);
        }
        catch (Exception e)
        {
            //Debug.Log(e.Message);
        }
    }

    private IEnumerator StartCc(int c = 10)
    {
        compteur = c;
        while (compteur > 0)
        {
            yield return new WaitForSeconds(1);
            compteur--;
        }
    }

}

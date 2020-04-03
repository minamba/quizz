using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChallengeSniffer : MonoBehaviour {
    public GameObject canvasChallenge;
    public GameObject canvas;
    public static string challenger;
    public static string character;
    CallWebService webServ = new CallWebService();
    t_alert_duel al = new t_alert_duel();
    List<string> questionList = new List<string>();
    public static bool challengeActivate2;
    private static bool accepted = false;
    private static bool challengeMe = false;
    private int challengeId = -1;
    private static bool challengeCanvasEnable = false;
    public static int currentCounter;
    //bool b = false;

    private static bool c = false;
    bool d = false;
    // Use this for initialization
    void Start () {
        challengeActivate2 = false;
        canvasChallenge = GameObject.Find("CanvasChallenge");
        canvasChallenge.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {  

        //Tant qu'on me challenge pas, je verifie dans la table des challenge si j'apparais
        //if (challengeMe == false)
        //{
        //    try
        //    {
        //        al = webServ.ChallengeSniffer(Deconnexion.pseudo);

        //        if (al != null)
        //        {
        //            challengeMe = true;
        //            //canvasChallenge.SetActive(true);
        //        }
        //    }

        //    catch (Exception e)
        //    {
        //        //Debug.Log("dddddd : " + e.Message);
        //        return;
        //    }

        //}
        //else
        //{
        //   al = webServ.ChallengeSniffer(Deconnexion.pseudo);

        //    if (al != null)
        //    {
        //        //Debug.Log(al.a_id);
        //        //Debug.Log(challengeMe);

        //        if (challengeCanvasEnable == false)
        //        {
        //            GameObject.Find("Challenge").GetComponent<AudioSource>().Play();// play level win sond   
        //            canvasChallenge.SetActive(true);
        //            challengeCanvasEnable = true;          
        //        }

        //        challenger = webServ.UserPseudonym((int)al.a_user_id_1);
        //        character = webServ.GetCharacterNameById((int)al.a_character_id).c_name;

        //        if (accepted == true)
        //        {
        //            canvasChallenge.GetComponentsInChildren<Text>()[1].text = "Vous avez accepté le Défi de " + challenger.Trim();
        //            challengeActivate2 = true;
        //        }
        //        else
        //        {                 
        //            canvasChallenge.GetComponentsInChildren<Text>()[1].text = "Le joueur ' " + challenger.Trim() + " ' vous défi sur le personnage " + "' " + character + " '" + " Acceptez-vous le défi? ";
        //        }
        //    }
        //    else
        //    {
        //        if (challengeCanvasEnable == true)
        //        {
        //            canvasChallenge.SetActive(false);
        //            challengeCanvasEnable = false;
        //        }
        //        challengeMe = false;
        //        Debug.Log(challengeMe);
        //    }
        //}


        //JE SAIS PLUS POURQUOI MAIS C COMMENTE DONC JE DOIS LE RECOMMENTER
        //if (al != null)
        //{
        //    challenger = webServ.UserPseudonym((int)al.a_user_id_1);
        //    character = webServ.GetCharacterNameById((int)al.a_character_id).c_name;

        //    //canvas.SetActive(false);
        //    try
        //    {

        //        if (c == false)
        //        {
        //            Debug.Log("j'active le canvas challenge");
        //            canvasChallenge.SetActive(true);
        //            c = true;
        //        }

        //        if (accepted == true)
        //        {
        //            canvasChallenge.GetComponentsInChildren<Text>()[1].text = "Vous avez accepté le Défi de " + challenger;
        //            challengeActivate2 = true;
        //        }
        //        else
        //        {
        //            canvasChallenge.GetComponentsInChildren<Text>()[1].text = "Le joueur " + challenger + "vous défi sur le personnage " + "' " + character + " '" + " Acceptez-vous le défi? " +currentCounter;
        //        }

        //    }//Debug.Log("Le joueur : " + challenger + "vous défi sur le personnage : " + character +"Acceptez-vous le défi? "+ currentCounter);
        //    catch (Exception) { }
        //}

        //if (currentCounter == 0)
        //{
        //    if (d == false)
        //    {
        //        try
        //        {
        //            Debug.Log("je desactive le canvas challenge");
        //            canvasChallenge.SetActive(false);
        //            //StopCoroutine(StartCounter(interation));
        //            currentCounter = 10;
        //            //StartCoroutine(ReloadScene());
        //            c = false;
        //            return;
        //        }
        //        catch (Exception) { }
        //        webServ.RegisterAlertDuelUpDate(challenger, Deconnexion.pseudo, character, false);
        //        d = true;
        //    }
        //}
    }




    public IEnumerator LaunchChallenge()
    {
        yield return new WaitForSeconds((float)3);
        GameObject.Find("Canvas").GetComponent<Choice>().LaunchGame(questionList);
        //canvasdddd.SetActive(false);
    }


    public void ChallengeAccepted()
    {
        //accepted = true;
        //Debug.Log(challenger +" "+ Deconnexion.pseudo + " "+character);
        //webServ.RegisterAlertDuelUpDate(challenger, Deconnexion.pseudo, character, true);      
        //questionList = GameObject.Find("Canvas").GetComponent<Choice>().ListOfQuestions(character);
        //challengeActivate2 = true;
        //StartCoroutine(LaunchChallenge());
        //accepted = false;
    }

    public void ChallendeDenied()
    {
        //accepted = false;
        //challengeActivate2 = false;
        //challengeMe = false;
        //webServ.RegisterAlertDuelUpDate(challenger, Deconnexion.pseudo, character, false);
        //al = null;
    }



    //CETAIT COMMANTER IL FAUT QUE JE RECOMMENTE 
    //private IEnumerator StartCounter(int counter = 10)
    //{
    //     canvasChallenge.SetActive(false);

    //    currentCounter = counter;
    //    while (currentCounter > 0)
    //    {
    //        yield return new WaitForSeconds(1);
    //        currentCounter--;
    //    }


    //    //if (currentCounter == 0)
    //    //    currentCounter = counter;
    //}




    //public IEnumerator ReloadScene()
    //{
    //    yield return new WaitForSeconds(10);
    //    //Application.LoadLevel(Application.loadedLevel);
    //    SceneManager.LoadScene("MainMenu");
    //}


    //public IEnumerator HideChallengeCanvas()
    //{
    //    //if (challengeCanvasEnable == false)
    //    //{
    //        yield return new WaitForSeconds(2);
    //        canvasChallenge.SetActive(false);
    //    //}
    //}







}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeResult : MonoBehaviour {
    public bool dg = false;
    CallWebService webServ = new CallWebService();
    t_duels duel = new t_duels();
    private static bool a = false;
    private static bool b = false;
    private static bool c = false;
    public static GameObject canvasWinChallenge;
    public static GameObject canvasFailChallenge;
    // Use this for initialization
    public void Start () {
    }

    public IEnumerator HideWinCanvas()
    {
        yield return new WaitForSeconds((float)0.0);
        canvasWinChallenge.SetActive(false);
    }

    public IEnumerator HideFailCanvas()
    {
        yield return new WaitForSeconds((float)0.0);
        canvasFailChallenge.SetActive(false);
    }



    public IEnumerator ShowWinCanvas()
    {
        yield return new WaitForSeconds((float)1);
        canvasWinChallenge.SetActive(true);
    }

    public IEnumerator ShowFailCanvas()
    {
        yield return new WaitForSeconds((float)0.2);
        canvasFailChallenge.SetActive(true);
    }

    // Update is called once per frame
    //public void Update(t_duels du)
    //{
        //yield return new WaitForSeconds((float)0);
        ////Debug.Log("je rentre dans la methode de verif du score de lautre joueur");

        //if (ChallengeDemand.challengeActivate == true)
        //{
        //    if (du.d_score_user_id_2 != null)
        //    {
        //        if (du.d_score_user_id_1 > du.d_score_user_id_2)
        //        {
        //            ChallengeDemand.challengeActivate = false;
        //            //Debug.Log("jai gagné");
        //            TimerScript.canvasWinChallenge.SetActive(true);
        //            TimerScript.canvasChallenge.GetComponentsInChildren<Text>()[1].text = "Tu as gagné le match : " + du.d_score_user_id_1 + "-" + du.d_score_user_id_2;
        //            GameObject.Find("AudioWinChallenge").GetComponent<AudioSource>().Play();// play level win sond
        //            webServ.DeleteDuel(ChallengeDemand.DemandeurCHallenge, ChallengeDemand.candidatChallengeClicked, DropDown.dropDownSelected);
        //        }
        //        else if (du.d_score_user_id_1 < du.d_score_user_id_2)
        //        {
        //            //Debug.Log("jaiii perrrrrrrrrdu");
        //            TimerScript.canvasFailChallenge.SetActive(true);
        //            ChallengeDemand.challengeActivate = false;
        //            TimerScript.canvasChallenge.GetComponentsInChildren<Text>()[1].text = "Tu as perdu le match : " + du.d_score_user_id_1 + "-" + du.d_score_user_id_2;
        //            GameObject.Find("AudioLooseChallenge").GetComponent<AudioSource>().Play();// play level fail sond
        //            webServ.DeleteDuel(ChallengeDemand.DemandeurCHallenge, ChallengeDemand.candidatChallengeClicked, DropDown.dropDownSelected);
        //        }
        //        else
        //        {
        //            TimerScript.canvasChallenge.GetComponentsInChildren<Text>()[1].text = "Match nul : " + du.d_score_user_id_1 + "-" + du.d_score_user_id_2;
        //            webServ.DeleteDuel(ChallengeDemand.DemandeurCHallenge, ChallengeDemand.candidatChallengeClicked, DropDown.dropDownSelected);
        //        }
        //    }
        //    else
        //    {
        //        TimerScript.canvasChallenge.GetComponentsInChildren<Text>()[1].text = "En attente du resultat de l'adversaire...";
        //    }
        //}

        //if (ChallengeSniffer.challengeActivate2 == true)
        //{
        //    try
        //    {
        //        if (du.d_score_user_id_1 != null)
        //        {
        //            GameObject.Find("Canvas").GetComponent<HideControls>().Hide();
        //            if (du.d_score_user_id_2 > du.d_score_user_id_1)
        //            {
        //                TimerScript.canvasWinChallenge.SetActive(true);
        //                TimerScript.canvasChallenge.GetComponentsInChildren<Text>()[1].text = "Tu as gagné le match : " + du.d_score_user_id_2 + "-" + du.d_score_user_id_1;
        //                GameObject.Find("AudioWinChallenge").GetComponent<AudioSource>().Play();// play level win sond

        //            }
        //            else if (du.d_score_user_id_2 < du.d_score_user_id_1)
        //            {
        //                TimerScript.canvasFailChallenge.SetActive(true);
        //                TimerScript.canvasChallenge.GetComponentsInChildren<Text>()[1].text = "Tu as perdu le match : " + du.d_score_user_id_2 + "-" + du.d_score_user_id_1;
        //                GameObject.Find("AudioLooseChallenge").GetComponent<AudioSource>().Play();// play level fail sond
        //            }
        //            else
        //            {
        //                TimerScript.canvasChallenge.GetComponentsInChildren<Text>()[1].text = "Match nul : " + du.d_score_user_id_2 + "-" + du.d_score_user_id_1;
        //            }
        //        }
        //        else
        //        {
        //            TimerScript.canvasChallenge.GetComponentsInChildren<Text>()[1].text = "En attente du resultat de l'adversaire...";
        //        }
        //    }
        //    catch (Exception e) { Debug.Log(e.Message); }
        //}
           
    //}



    public void Mainmenu()
    {
        if (ChallengeDemand.challengeActivate == true)
        {
           Application.LoadLevel("MainMenu");                   
        }


        if (ChallengeDemand.challengeActivate == false)
        {
            //webServ.DeleteDuel(ChallengeSniffer.challenger, Deconnexion.pseudo, "al boukhari");
            Application.LoadLevel("MainMenu");
        }
    }
}

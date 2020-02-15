using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
//using System.Threading.Tasks; FRAMEWORK 4.6
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsActions : MonoBehaviour
{
    public static List<string> listR { get; set; }
    public static List<string> listRTemp { get; set; }
    private static string buttonName { get; set; }
    public static string characterSCopeName { get; set; }
    public static int sizeListR { get; set; }
    public static bool replayClick = false;
    private static string candidat;
    public static GameObject canvasDef;
    t_duels duel = new t_duels();
    CallWebService webServ = new CallWebService();

    //Main menu game pause////////////////////////////////////////////////////////////////////////////////////////////////////
    public void Mainmenu()
    {
        if(ChallengeDemand.challengeActivate == true)
        {
            ChallengeDemand.challengeActivate = false;
            webServ.DeleteDuel(ChallengeDemand.DemandeurCHallenge, ChallengeDemand.candidatChallengeClicked, DropDown.dropDownSelected);
        }

        if (ChallengeSniffer.challengeActivate2 == true)
        {
            ChallengeSniffer.challengeActivate2 = false;
             webServ.DeleteDuel(ChallengeSniffer.challenger, Deconnexion.pseudo, ChallengeSniffer.character);
        }
        StartCoroutine(LaunchMainmenu());
    }
    //Main menu game over////////////////////////////////////////////////////////////////////////////////////////////////////
    public void Mainmenu2()
    {
        Application.LoadLevel("MainMenu");
    }

    //level choice////////////////////////////////////////////////////////////////////////////////////////////////////
    public void LevelChoice()
    {
        StartCoroutine(LaunchLevelChoice());
        //Application.LoadLevel("Levels");
    }

    //Character choice  game pause////////////////////////////////////////////////////////////////////////////////////////////////////
    public void CharactersChoice()
    {
        if (ChallengeDemand.challengeActivate == true)
        {
            webServ.DeleteDuel(ChallengeDemand.DemandeurCHallenge, ChallengeDemand.candidatChallengeClicked, DropDown.dropDownSelected);
        }

        if (ChallengeSniffer.challengeActivate2 == true)
        {
            webServ.DeleteDuel(ChallengeSniffer.challenger, Deconnexion.pseudo, ChallengeSniffer.character);
        }
        StartCoroutine(LaunchCharactersChoice());
    }

    //Character choice game over////////////////////////////////////////////////////////////////////////////////////////////////////
    public void CharactersChoice2()
    {
        Application.LoadLevel("CharacterChoice");
    }

    //Replay game pause////////////////////////////////////////////////////////////////////////////////////////////////////
    public void Replay()
    {

        if (ChallengeDemand.challengeActivate == true)
        {
            webServ.DeleteDuel(ChallengeDemand.DemandeurCHallenge, ChallengeDemand.candidatChallengeClicked, DropDown.dropDownSelected);
        }

       else if (ChallengeSniffer.challengeActivate2 == true)
        {
            webServ.DeleteDuel(ChallengeSniffer.challenger, Deconnexion.pseudo, ChallengeSniffer.character);
        }
        else
        {
            StartCoroutine(LaunchReplay());
        }      
    }


    public void ScoreTable()
    {
        StartCoroutine(LaunchScoreTable());
    }

    public void BackOptions()
    {
        StartCoroutine(LaunchBackOptions());
    }

    public void ShowPlayer()
    {
        StartCoroutine(LaunchShowPlayer());
    }

    public void Myscores()
    {
        StartCoroutine(LaunchMyscores());
    }


/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    public IEnumerator LaunchMainmenu()
    {
        PauseMenu.tscale = true;
        yield return new WaitForSeconds((float)0.2);
        Application.LoadLevel("MainMenu");
        PauseMenu.tscale = false;
    }

    public IEnumerator LaunchLevelChoice()
    {
        PauseMenu.tscale = true;
        yield return new WaitForSeconds((float)0.2);
        Application.LoadLevel("Levels");
        PauseMenu.tscale = false;
    }

    public IEnumerator LaunchCharactersChoice()
    {
        PauseMenu.tscale = true;
        yield return new WaitForSeconds((float)0.2);
        Application.LoadLevel("CharacterChoice");
        PauseMenu.tscale = false;
    }


    public IEnumerator LaunchReplay()
    {
        PauseMenu.tscale = true;
        yield return new WaitForSeconds((float)0.2);
        try
        {
         
            replayClick = true;
            GameObject.Find("TimeBarImg").GetComponent<TimerScript>().gameOver = false;
            //SceneManager.LoadScene(sceneBuildIndex: 3);
            Application.LoadLevel("quizz");
        }
        catch (Exception e)
        {
            Debug.Log("Mess : " + e);
        }
        PauseMenu.tscale = false;
    }

    //Launch replay game over///////////////////////////////////////////////////////////////////////////////////////////////////////
    public void LaunchReplay2()
    {
        try
        {

            replayClick = true;
            GameObject.Find("TimeBarImg").GetComponent<TimerScript>().gameOver = false;
            //SceneManager.LoadScene(sceneBuildIndex: 3);
            Application.LoadLevel("quizz");
        }
        catch (Exception e)
        {
            Debug.Log("Mess : " + e);
        }
    }


    public IEnumerator LaunchScoreTable()
    {
        //SceneManager.LoadScene(sceneBuildIndex: 4);
        yield return new WaitForSeconds((float)0.5);
        Application.LoadLevel("Scores");
    }

    public IEnumerator LaunchBackOptions()
    {
        //SceneManager.LoadScene(sceneBuildIndex: 2);
        yield return new WaitForSeconds((float)0.5);
        Application.LoadLevel("Options");
    }


    public IEnumerator LaunchShowPlayer()
    {
        //SceneManager.LoadScene(sceneBuildIndex: 2);
        yield return new WaitForSeconds((float)0.5);
        Application.LoadLevel("PlayerChalleng");
    }


    public void CallUserRegister()
    {
        StartCoroutine(UserRegister());
    }

    //USER REGISTER
    public IEnumerator UserRegister()
    {
        string lastName = GameObject.Find("lastName").GetComponentsInChildren<Text>()[1].text;
        string firstName = GameObject.Find("firstName").GetComponentsInChildren<Text>()[1].text;
        string pseudonym = GameObject.Find("pseudonym").GetComponentsInChildren<Text>()[1].text;
        string pwd = GameObject.Find("password").GetComponentsInChildren<Text>()[1].text;
        string pwd2 = GameObject.Find("password2").GetComponentsInChildren<Text>()[1].text;
        string sexe = DropForm.dropDownSelectedSexe;
        int status = 1;
        //try
        //{
            GameObject.Find("done").GetComponent<Text>().text = webServ.UserRegister(firstName, lastName, pseudonym, pwd, pwd2, sexe, status);
            if (GameObject.Find("done").GetComponent<Text>().text == "Merci, vous inscription a bien été pris en compte !")
            {
                yield return new WaitForSeconds(2);
                Application.LoadLevel("Connexion");
            }
        //}
        /*catch (Exception e)
        {
            GameObject.Find("done").GetComponent<Text>().text = e.Message;
        }*/
    }

    //FRAMEWORK 4.6/////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //public async void UserRegister()
    //{
    //    string lastName = GameObject.Find("lastName").GetComponentsInChildren<Text>()[1].text;
    //    string firstName = GameObject.Find("firstName").GetComponentsInChildren<Text>()[1].text;
    //    string pseudonym = GameObject.Find("pseudonym").GetComponentsInChildren<Text>()[1].text;
    //    string pwd = GameObject.Find("password").GetComponentsInChildren<Text>()[1].text;
    //    string pwd2 = GameObject.Find("password2").GetComponentsInChildren<Text>()[1].text;
    //    string sexe = DropForm.dropDownSelectedSexe;
    //    try
    //    {
    //        GameObject.Find("done").GetComponent<Text>().text = webServ.UserRegister(firstName, lastName, pseudonym, pwd, pwd2,sexe);
    //        if (GameObject.Find("done").GetComponent<Text>().text == "Merci, vous inscription a bien été pris en compte !")
    //        {
    //            await Task.Delay(System.TimeSpan.FromSeconds(2));
    //            Application.LoadLevel("Connexion");
    //        }
    //    }
    //    catch (Exception e)
    //    {
    //        GameObject.Find("done").GetComponent<Text>().text = e.Message;
    //    }
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    public IEnumerator LaunchMyscores()
    {
        //SceneManager.LoadScene(sceneBuildIndex: 8);
        yield return new WaitForSeconds((float)0.2);
        Application.LoadLevel("MyScores");
    }







}

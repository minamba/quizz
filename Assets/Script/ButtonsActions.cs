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
    private static GameObject canvasFormR;
    public static bool clickMainMenu = false;
    t_duels duel = new t_duels();
    CallWebService webServ = new CallWebService();


    void Start()
    {
    }

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
        clickMainMenu = true;
        Game.endOfGame = false;
        Application.LoadLevel("MainMenu");
    }

    public void MainMenugQuizz()
    {
        clickMainMenu = true;
        Game.endOfGame = false;
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
        clickMainMenu = true;
        Game.endOfGame = false;
        Application.LoadLevel("CharacterChoice");
    }

    //Replay game pause////////////////////////////////////////////////////////////////////////////////////////////////////
    public void Replay()
    {

       // if (ChallengeDemand.challengeActivate == true)
       // {
       //     webServ.DeleteDuel(ChallengeDemand.DemandeurCHallenge, ChallengeDemand.candidatChallengeClicked, DropDown.dropDownSelected);
       // }

       //else if (ChallengeSniffer.challengeActivate2 == true)
       // {
       //     webServ.DeleteDuel(ChallengeSniffer.challenger, Deconnexion.pseudo, ChallengeSniffer.character);
       // }
       // else
       // {
            StartCoroutine(LaunchReplay());
        //}      
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

    public void Parameters()
    {
        StartCoroutine(LaunchParameters());
    }


    public void BackToConnection()
    {
        StartCoroutine(LaunchConnexion());
    }


    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public IEnumerator LaunchParameters()
    {
        //SceneManager.LoadScene(sceneBuildIndex: 8);
        yield return new WaitForSeconds((float)0.2);
        Application.LoadLevel("Parameters");
    }

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


    public IEnumerator LaunchConnexion()
    {
        //SceneManager.LoadScene(sceneBuildIndex: 2);
        PauseMenu.tscale = true;
        yield return new WaitForSeconds((float)0.5);
        Application.LoadLevel("Connexion");
        PauseMenu.tscale = false;
    }


    public IEnumerator LaunchReplay()
    {
        clickMainMenu = true;
        Game.endOfGame = false;
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
            //Debug.Log("Mess : " + e);
        }
        PauseMenu.tscale = false;
    }

    //Launch replay game over///////////////////////////////////////////////////////////////////////////////////////////////////////
    public void LaunchReplay2()
    {
        try
        {

            clickMainMenu = true;
            Game.endOfGame = false;
            //SceneManager.LoadScene(sceneBuildIndex: 3);
            Application.LoadLevel("quizz");
        }
        catch (Exception e)
        {
            //Debug.Log("Mess : " + e);
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






    public void SendMail ()
    {
        string mailTo = GameObject.Find("mail").GetComponentsInChildren<Text>()[1].text;
        var user = webServ.GetUserByMail(mailTo);
        string mailFrom = "webmaster.malik.ibn.anas@gmail.com";     
        string title = "Malik ibn anas - Mot de passe perdu";
        string message = "As salamou 3alaykoum "+user.u_first_name+ ". Voici votre mot de passe : " + user.u_password;

        try
        {
            webServ.SendMail(mailFrom,mailTo,title,message);

            Console.WriteLine("Mail send with succes !");
        }
        catch(Exception e)
        {
            Console.WriteLine(webServ.SendMail(mailFrom, mailTo, title, message));
        }
    }







}

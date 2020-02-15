using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;

public class Choice : MonoBehaviour {
    public static List<string> list { get; set; }
    public static List<string> listTemp { get; set; }
    public static string buttonName { get; set; }
    public static int sizeList { get; set; }
    public bool b = false;
    public GameObject grid;
    public GameObject button;
    public GameObject characterButton;
    CallWebService webServ = new CallWebService();


    public void Start()
    {
        Time.timeScale = 1;
        ShowCharacters();
    }


    public List<string> ListOfQuestions()
    {
        ChallengeDemand.challengeActivate = false;
        ChallengeSniffer.challengeActivate2 = false;
        //Get the name of the cliked button
        buttonName = EventSystem.current.currentSelectedGameObject.GetComponentsInChildren<Text>()[0].text;
        //Questions q = new Questions();
        //switch (buttonName)
        //{
        //    case "Bukhari":
        //        //Debug.Log("jai cliqué sur "+buttonName+" : ");
        //        return q.Bukhari();
        //    case "OmarAlMoukhtar":
        //        //Debug.Log("jai cliqué sur OmarAlMoukhtar : ");
        //        return q.OmarAlMoukhtar();
        //    case "IbnKhaldoun":
        //        //Debug.Log("jai cliqué sur IbnKhaldoun : ");
        //        return q.IbnKhaldoun();

        //    default:
        //        //Debug.Log("jai cliqué sur random : ");
        //        return  q.RandomCharacter();
        //}
        Debug.Log("jai cliqué sur : "+ buttonName);
  
            sizeList = webServ.CountQuestionsByCharacter(buttonName);
            return webServ.ListOfQuestionsByCharacter(buttonName);
    }


    //SHOW LIST OF CHARACTERS
    public void ShowCharacters()
    {
        try
        {
            CallWebService cw = new CallWebService();
            int randomNumber;
            grid = GameObject.Find("GridWithOurElements");
            button = GameObject.Find("CharacterButton");
            List<string> characterList;
            try
            {
                 characterList = cw.CharactersList();
            }
            catch(Exception)
            {
                return;
            }

            List<Color> colors = new List<Color>();
            colors.Add(Color.red);
            colors.Add(Color.blue);
            colors.Add(Color.green);
            colors.Add(Color.yellow);
            colors.Add(Color.black);

            for (int i = 1; i < characterList.Count; i++)
            {
                randomNumber = UnityEngine.Random.Range(0, colors.Count);
                characterButton = Instantiate(button);// instantiate permet de copier un gameobject ! ici je copy le bouton Bukhari
                characterButton.GetComponentsInChildren<Text>()[0].text = characterList[i];
                characterButton.GetComponentsInChildren<Text>()[0].color = colors[randomNumber];
                characterButton.transform.parent = grid.transform;
            }
        }
        catch (Exception e)
        {
            
                //GameObject.Find("TextDebug").GetComponent<Text>().text = e.Message;
        }
        
    }

    public void LaunchGame()
    {
        if (PauseMenu.pause == true)
            PauseMenu.pause = false;
        try
        {
            Questions q = new Questions();
            list = ListOfQuestions();
            listTemp = ListOfQuestions();
        }
        catch (Exception e)
        {
            Debug.Log("Mess : " + e);
        }
        //SceneManager.LoadScene(sceneBuildIndex: 3);
        Application.LoadLevel("quizz");
    }


    
    public List<string> ListOfQuestions(string charachaterName)
    {
        Debug.Log("jai cliqué sur : " + charachaterName);

        sizeList = webServ.CountQuestionsByCharacter(charachaterName);
        return webServ.ListOfQuestionsByCharacter(charachaterName);
    }



    public void LaunchGame(List<string> listS)
    {
        if (PauseMenu.pause == true)
            PauseMenu.pause = false;
        try
        {
            Questions q = new Questions();
            list = listS;
            listTemp = listS;
        }
        catch (Exception e)
        {
            Debug.Log("Mess : " + e);
        }
        //SceneManager.LoadScene(sceneBuildIndex: 3);
        Application.LoadLevel("quizz");
    }



}

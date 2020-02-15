using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
    private List<string> listOfquestions = new List<string>();
    private Text question;
    private Text counter;
    private Text score;
    public static Text leftAnswer;
    private Text rightAnswer;
    private Text bottomRightAnswer;
    private Text bottomLeftAnswer;
    private List<string> listOfQuestions;
    public string response;
    private int randomNumber;
    public int incrementScore = 0;
    public static int sc;
    public static int sc_2;
    public static int point;
    public static int getScSaved = 0;
    public int idQuestion;
    public float timeSecond;
    public static int numberLine;
    public static string characterName;
    private List<string> l;
    public bool b = false;
    Questions tableQuestions = new Questions();
    public GameObject canvasStart;
    public GameObject canvas;
    public GameObject canvasAnimGood;
    public static GameObject canvasAnimBad;
    public static string medalState;
    CallWebService webServ = new CallWebService();
    // Use this for initialization
    public void Start()
    {
        sc = 0;
        listOfQuestions = Choice.list;
        Responses.pointCount = 0;      
        GameObject.Find("AnimationBad").SetActive(false);
        //GameObject.Find("AnimationGood").SetActive(false);
        canvasAnimGood = GameObject.Find("AnimationGood");
        canvasAnimBad = GameObject.Find("AnimationBad");
        canvasStart = GameObject.Find("CanvasGameStart");
        question = GameObject.Find("Question").GetComponent<Text>();
        leftAnswer = GameObject.Find("LeftAnswer").GetComponent<Text>();
        rightAnswer = GameObject.Find("RightAnswer").GetComponent<Text>();
        bottomLeftAnswer = GameObject.Find("BottomLeftAnswer").GetComponent<Text>();
        bottomRightAnswer = GameObject.Find("BottomRightAnswer").GetComponent<Text>();
        score = GameObject.Find("Score").GetComponent<Text>();
        characterName = Choice.buttonName;
        numberLine = NumberTableLine(Choice.sizeList);
        //getScSaved = GameObject.Find("Canvas").GetComponent<SaveDatas>().ReturnScore(Game.characterName);
        Debug.Log("List  : " + numberLine);
    }

    // Update is called once per frame
    void Update() {
        score.text = "Score : "+ incrementScore;
        sc = incrementScore;
        sc_2 = incrementScore;
    }

    public void RandomQuestion()
    {
        if (TimerSartGame.currCountdownValue == 0)
        {
            canvasStart.SetActive(false);
            GameObject.Find("Canvas").GetComponent<HideControls>().HideBadGoodResponses();
            //medalState = GameObject.Find("Canvas").GetComponent<SaveDatas>().ReturnMedal();
            GameObject.Find("Canvas").GetComponent<HideControls>().Enable();
            randomNumber = UnityEngine.Random.Range(0, numberLine);       

            //When the replay button is clicked
            if (ButtonsActions.replayClick == true)
            {
               //Debug.Log("j'ai cliqué sur le bouton replay");
               listOfQuestions.Clear();
               for (int i = 0; i <= numberLine; i++)
               {
                    listOfQuestions.Add(Choice.listTemp[i]);
               }
                ButtonsActions.replayClick = false;
            }

            //Debug.Log("siiiiize list : " + listOfQuestions.Count);
            //Get a line of tabQuizz and split the string to get the question and her responses
            //string[] splitString = listOfQuestions[randomNumber].Split(',');
            //question.text = splitString[0];
            //leftAnswer.text = splitString[1];
            //rightAnswer.text = splitString[2];
            //leftAnswer.text = splitString[1];
            //rightAnswer.text = splitString[2];
            //bottomLeftAnswer.text = splitString[3];
            //bottomRightAnswer.text = splitString[4];
            //response = splitString[5];
            //timeSecond = float.Parse(splitString[6]);
            //point = int.Parse(splitString[7]);
            //DeleteQuestion(listOfQuestions);

            
            question.text = listOfQuestions[randomNumber];
            List<string> responses = webServ.ListOfResponses(question.text);
            leftAnswer.text = responses[0];
            rightAnswer.text = responses[1];
            bottomLeftAnswer.text = responses[2];
            bottomRightAnswer.text = responses[3];
            string r = webServ.GetGoodResponse(question.text);
            response = r;
            int? time = webServ.GetTimerByQuestion(question.text);
            timeSecond = float.Parse(time.ToString());
            int? points = webServ.GetPointByQuestion(question.text);
            point = (int)points;
            DeleteQuestion(listOfQuestions);
        }
        else
        {
            GameObject.Find("Canvas").GetComponent<HideControls>().Hide();
            GameObject.Find("CanvasGameStart").GetComponentsInChildren<Text>()[0].text = "La partie commence dans ";
           
        }
    }

    //if a question is already asked, i delete it of the table
    public void DeleteQuestion(List<string> list)
    {
        //Debug.Log("number line in tabQuizz : " + numberLine);
        //Debug.Log("ligne a supprimer:" + list[randomNumber]);
        list.Remove(list[randomNumber]);

        if (numberLine >= 0)
        {
            numberLine--;
        }
        else
        {
            //Debug.Log("Fin de la partie");
            //Application.LoadLevel("quizz");
        }
    }

    //Method wich take the size of a table and remove one to the size to not be out of range at the start
    public int NumberTableLine(int n)
    {
        return n-1;
    }
}
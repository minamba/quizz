using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private bool bb = false;
    private Text question;
    private Text totQuestion;
    private Text counter;
    private Text score;
    public static Text leftAnswer;
    private Text rightAnswer;
    private Text bottomRightAnswer;
    private Text bottomLeftAnswer;
    public static List<string> listOfQuestions;
    public string response;
    private int randomNumber;
    private static int temprandomNumber;
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
    private static int countDownListOfQuestion;
    private static bool bul = false;
    public static bool endOfGame = false;
    private static bool rd = false;
    private static bool fock = false;
    CallWebService webServ = new CallWebService();
    private static List<string> Listresponses = new List<string>();
    private static List<t_responses> responses = new List<t_responses>();
    private static List<t_questions> questions = new List<t_questions>();
    private static List<t_questions> questionsReplay = new List<t_questions>();
    public static int totalQuestion = 0;
    private bool trackingSave = false;
    public static int numberCurrentQuestion = 0;
    // Use this for initialization
    public void Start()
    {
        sc = 0;
        listOfQuestions = Choice.list;
        //listOfQuestions.Add("EMPTY");
        Responses.pointCount = 0;
        GameObject.Find("AnimationBad").SetActive(false);
        totQuestion = GameObject.Find("Counter_Text").GetComponent<Text>();
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

        responses = webServ.GetResponses();
        questions = webServ.GetQuestionsByCharacterName(characterName);
        questionsReplay = webServ.GetQuestionsByCharacterName(characterName); ;
        numberLine = questions.Count;
        countDownListOfQuestion = numberLine;
        //Debug.Log("List !!!!!!!  : " + numberLine);

        if(ButtonsActions.clickMainMenu == true)
        {
            questions.Clear();
            questions = questionsReplay;
            numberLine = questions.Count;
            //Debug.Log(questions.Count);
        }

        totalQuestion = questions.Count;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score : " + incrementScore;
        sc = incrementScore;
        sc_2 = incrementScore;
    }

    public void RandomQuestion()
    {
        //Debug.Log("JE SUIS LA GENERATION DE QUESTION");
        //new WaitForSeconds((float)1);
        if (TimerSartGame.currCountdownValue < 1)
        {
            //Debug.Log("le compteur du debut est a 0");
            canvasStart.SetActive(false);
            GameObject.Find("Canvas").GetComponent<HideControls>().HideBadGoodResponses();
            GameObject.Find("Canvas").GetComponent<HideControls>().Enable();

            try
            {            
                randomNumber = GenerateRandomNumber();
                Question();
               
            }
            catch (Exception e)
            {
                //Debug.Log("Fin de la partie");
                endOfGame = true;
                TrackingSave();
                //Debug.Log("izzzzi : " +  e.Message + " list count : "+ listOfQuestions.Count + " random : " + randomNumber /*+ " response : "+ responses[0]*/);
            }
        }

        else
        {
            if (bul == false && TimerSartGame.currCountdownValue == 0)
            {

                GameObject.Find("Canvas").GetComponent<HideControls>().Hide();
                GameObject.Find("CanvasGameStart").GetComponentsInChildren<Text>()[0].text = "La partie commence dans ";

                bul = true;
            }

        }
    }

    //if a question is already asked, i delete it of the table
    public void DeleteQuestion(List<t_questions> list)
    {
        //Debug.Log("TAILLE DE LA LISTE:" + list.Count.ToString());
        //new WaitForSeconds((float)0.1);
        try
        {       
            rd = false;
            countDownListOfQuestion = list.Count;
            //Debug.Log("countDownListOfQuestion :" + countDownListOfQuestion.ToString());
        }
        catch (Exception e)
        {
            //Debug.Log(e.Message);
        }

        int n = -Math.Abs(1);


        if (numberLine > n)       
        {      
            try
            {
                //Debug.Log("N2 ! " + numberLine);

                numberLine--;
                //Debug.Log("Je supprime une question ! " + list[randomNumber]);
                list.RemoveAt(randomNumber);
            }
            catch
            {
                //Debug.Log("erreur !");
            }
        }
    }

    //Method wich take the size of a table and remove one to the size to not be out of range at the start
    public int NumberTableLine(int n)
    {
        return n - 1;
    }


    public int GenerateRandomNumber()
    {
        if (rd == false)
        {
            //new WaitForSeconds((float)0.1);
            System.Random rnd = new System.Random();
            int r = UnityEngine.Random.Range(0, questions.Count);
            //Debug.Log("rrrrrrrrrrrrrrrrrrrrrrr : " + r + "      " + questions.Count);
            rd = true;
            return r;
        }
        else
        {
            return 0;
        }
    }


    public void Question()
    {
            if(numberCurrentQuestion <= totalQuestion)
                numberCurrentQuestion++;

            totQuestion.text = numberCurrentQuestion + "/" + totalQuestion;
            string r =null;
            t_questions t = new t_questions();
            t = questions[randomNumber];
            question.text = t.q_question;

            foreach (var j in responses)
            {
                if (t.q_id == j.r_fk_question_id)
                {
                    Listresponses.Add(j.r_response);
                    if(j.r_good_response ==true)
                    {
                        r = j.r_response;
                    }
                }
            }

            leftAnswer.text = Listresponses[0];
            rightAnswer.text = Listresponses[1];
            bottomLeftAnswer.text = Listresponses[2];
            bottomRightAnswer.text = Listresponses[3];
            response = r;
            int? time = webServ.GetTimerByQuestion(question.text.ToString());
            timeSecond = float.Parse(time.ToString());
            Debug.Log("time response :" + timeSecond.ToString());
            int? points = webServ.GetPointByQuestion(question.text.ToString());
            point = (int)points;
            bb = true;
            DeleteQuestion(questions);
            Listresponses.Clear();
    }


    public void TrackingSave()
    {
        if(webServ.GetScoreTracking(Deconnexion.pseudo, characterName, incrementScore,DateTime.Now) == false)
        {
            GameObject.Find("Canvas").GetComponent<SaveDatas>().SaveFileTracking(Deconnexion.pseudo, incrementScore);
        }
    }
}
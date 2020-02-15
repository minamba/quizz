using System;
using System.Collections;
using System.Collections.Generic;
//using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {
    private bool b = false;
    private bool c = false;
    private Image timerBar;
    public float maxTime=0;
    public float timeLeft;
    public bool gameOver = false;
    public static bool clickLastQuestion = false;
    public static bool click = false;
    private GameObject canvasAnim;
    public static int getScSaved;
    public bool dg = false;
    public static GameObject canvasChallenge;
    public static GameObject canvasWinChallenge;
    public static GameObject canvasFailChallenge;
    CallWebService webServ = new CallWebService();
    t_duels duel = new t_duels();
    public static bool cs;

    // Use this for initialization
    public void Start () {
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
        canvasChallenge = GameObject.Find("CanvasChallengeResult");
        canvasChallenge.SetActive(false);
        canvasWinChallenge = GameObject.Find("CanvasWinChallenge");
        canvasWinChallenge.SetActive(false);
        canvasFailChallenge = GameObject.Find("CanvasFailChallenge");
        canvasFailChallenge.SetActive(false);
        //getScSaved = GameObject.Find("Canvas").GetComponent<SaveDatas>().ReturnScore(Game.characterName);
        //Debug.Log("le score enregistré dans le ficheir etait celui la " + getScSaved);
    }

    public void Update () {
        Debug.Log("count : " + Choice.list.Count);
        if (Choice.list.Count == 0 && click == true)
        {
            Debug.Log("JE SUIS SUR LA DERNIERE QUESTION");
            //clickLastQuestion = true;
            if (c == true)
            {
                Debug.Log("demande de challenge : " + ChallengeDemand.challengeActivate);
                Debug.Log("accept challenge : " + ChallengeSniffer.challengeActivate2);
                bool cd = ChallengeDemand.challengeActivate;
                bool cs = ChallengeSniffer.challengeActivate2;

                if (cd == false & cs == false)
                {
                   Debug.Log("jsuis dans le fin de game normaaaaaaaaaal");
                    //await Task.Delay(TimeSpan.FromSeconds(1));
                    GameObject.Find("Canvas").GetComponent<HideControls>().Start();
                    GameObject.Find("Canvas").GetComponent<HideControls>().Hide();
                    Debug.Log("INCREMENT : " + GameObject.Find("Canvas").GetComponent<Game>().incrementScore);
                    if (dg == false)
                    {
                        GameObject.Find("Canvas").GetComponent<SaveDatas>().SaveFile(Deconnexion.pseudo, GameObject.Find("Canvas").GetComponent<Game>().incrementScore);
                        dg = true;
                    }
                    gameOver = true;
                }

                if (ChallengeDemand.challengeActivate == true || ChallengeSniffer.challengeActivate2 == true)
                {
                    Debug.Log("INCREMENT : " + GameObject.Find("Canvas").GetComponent<Game>().incrementScore);

                    if (GameObject.Find("Canvas").GetComponent<Game>().incrementScore>0)
                    {
                        //GameObject.Find("Canvas").GetComponent<ChallengeResult>().Start();
                        Debug.Log("lol");
                        //GameObject.Find("TimeBarImg").SetActive(false);
                        GameObject.Find("Canvas").GetComponent<HideControls>().Start();
                        GameObject.Find("Canvas").GetComponent<HideControls>().Hide();
                        GameObject.Find("Canvas").GetComponent<SaveDatas>().SaveFile(Deconnexion.pseudo, GameObject.Find("Canvas").GetComponent<Game>().incrementScore);
                        canvasChallenge.SetActive(true);
                        GameObject.Find("Canvas").GetComponent<HideControls>().Hide();
                    }
                }
            }
            c = true;
        }



        if (ChallengeDemand.challengeActivate == true)
        {
            duel = webServ.GetDuel(ChallengeDemand.DemandeurCHallenge, ChallengeDemand.candidatChallengeClicked, "al boukhari");
            StartCoroutine(GameObject.Find("Canvas").GetComponent<ChallengeResult>().Update(duel));
        }
        if(ChallengeSniffer.challengeActivate2 == true)
        {
            duel = webServ.GetDuel(ChallengeSniffer.challenger, Deconnexion.pseudo, "al boukhari");
            StartCoroutine(GameObject.Find("Canvas").GetComponent<ChallengeResult>().Update(duel));
        }


        // if the time is out, reload a question and reinitialize the time with timeLeft
        if (b == false && Time.deltaTime == 0)
        {
            try
            {
                ////////Generation d'une nouvelle question////////
                //GameObject.Find("QuestionComponent").SetActive(true);
                GameObject.Find("Canvas").GetComponent<Game>().RandomQuestion();
            }
            catch(Exception e) {
                GameObject.Find("Canvas").GetComponent<SaveDatas>().Start();
                GameObject.Find("Canvas").GetComponent<HideControls>().Hide();
                gameOver = true;
            }


            maxTime = GameObject.Find("Canvas").GetComponent<Game>().timeSecond;                
            timeLeft = maxTime;

            if (GameObject.Find("Canvas").GetComponent<PauseMenu>().showGUI == false) {
              Time.timeScale = 1; //  let the action on the timeBar.fillAmount
            }
            if(GameObject.Find("Canvas").GetComponent<PauseMenu>().showGUI == true)
            {
                Time.timeScale = 0;
            }
   
            if (GameObject.Find("Canvas").GetComponent<GameOver>().showGUI == false)
            {
                Time.timeScale = 1; //  let the action on the timeBar.fillAmount
            }
            if (GameObject.Find("Canvas").GetComponent<GameOver>().showGUI == true)
            {
                Time.timeScale = 0;
            }

            b = true;
        }
        else if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
            Time.timeScale = 1;
            GameObject.Find("Canvas").GetComponent<HideControls>().Enable();
        }
        else
        {
            Time.timeScale = 0;
            b = false;
        }
        click = false;
    }
}
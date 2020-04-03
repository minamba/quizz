using System.Threading;
//using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    private bool b = true;
    private bool c = false;
    private Image timerBar;
    public float maxTime = 0;
    public static float timeLeft;
    public bool gameOver = false;
    public static bool clickLastQuestion = false;
    public static bool click = false;
    private GameObject canvasAnim;
    public static int getScSaved;
    public bool dg = false;
    private static bool launchRandomQuestion = false;
    public static GameObject canvasChallenge;
    public static GameObject canvasWinChallenge;
    public static GameObject canvasFailChallenge;
    private static GameObject RandomnMethod;
    private static GameObject Canvas;
    private static bool trackingDone = false;
    CallWebService webServ = new CallWebService();
    t_duels duel = new t_duels();
    public static bool cs;
    private Thread t1;

    // Use this for initialization
    public void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
        Canvas = GameObject.Find("Canvas");
        canvasChallenge = GameObject.Find("CanvasChallengeResult");
        canvasChallenge.SetActive(false);
        canvasWinChallenge = GameObject.Find("CanvasWinChallenge");
        canvasWinChallenge.SetActive(false);
        canvasFailChallenge = GameObject.Find("CanvasFailChallenge");
        canvasFailChallenge.SetActive(false);
        //getScSaved = GameObject.Find("Canvas").GetComponent<SaveDatas>().ReturnScore(Game.characterName);
        //Debug.Log("le score enregistré dans le ficheir etait celui la " + getScSaved);
    }

    public void Update()
    {
        //Debug.Log("nombre de question dans la liste de questions : " + Game.listOfQuestions.Count);

        if (Game.endOfGame == true)
        {

            new WaitForSeconds((float)0.1);

            GameObject.Find("Canvas").GetComponent<HideControls>().Hide();
            if (dg == false)
            {
                //i save directely in the tracking table              
                GameObject.Find("Canvas").GetComponent<SaveDatas>().SaveFile(Deconnexion.pseudo, GameObject.Find("Canvas").GetComponent<Game>().incrementScore);
                dg = true;
            }
            gameOver = true;

            //Debug.Log("plus de question");

        }
        else
        {
            ////when the user pause the game///////////////////
            //if (GameObject.Find("Canvas").GetComponent<PauseMenu>().showGUI == false)
            //{
            //    Time.timeScale = 1; //  let the action on the timeBar.fillAmount
            //    GameObject.Find("Canvas").GetComponent<HideControls>().Enable();
            //}
            //if (GameObject.Find("Canvas").GetComponent<PauseMenu>().showGUI == true)
            //{
            //    Time.timeScale = 0;
            //}

            //if (GameObject.Find("Canvas").GetComponent<GameOver>().showGUI == false)
            //{
            //    Time.timeScale = 1; //  let the action on the timeBar.fillAmount
            //}
            //if (GameObject.Find("Canvas").GetComponent<GameOver>().showGUI == true)
            //{
            //    Time.timeScale = 0;
            //}

            Time.timeScale = 1;


            if (b == true && Mathf.Round(timeLeft) == 0)
            {
                //Debug.Log("JE SUIS DANS LA GENERATION DE LA QUESTION : " + b);
                Canvas.GetComponent<Game>().RandomQuestion();
                b = false;
                //Debug.Log("je lance une nouvelle question !");
                maxTime = GameObject.Find("Canvas").GetComponent<Game>().timeSecond;
                timeLeft = maxTime;
                timerBar.fillAmount = timeLeft;

            }
            else if (Mathf.Round(timeLeft) > 0)
            {
                Time.timeScale = 1;
                timeLeft -= Time.deltaTime;
                timerBar.fillAmount = timeLeft / maxTime;
                b = false;
            }
            else
            {
                //Debug.Log("" + b);
                Time.timeScale = 0;
                b = true;
            }
        }
    }
}
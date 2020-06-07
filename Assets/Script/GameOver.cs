using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
//using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    private string medal;
    private static bool firstScore = false;
    private static bool silverUp = false;
    private static bool goldUp = false;
    private static bool maxPoint = false;
    public bool showGUI = false;
    public GameObject canvasGameOver;
    public GameObject canvasWin;
    public GameObject canvasFail;
    public GameObject canvasFirstPlay;
    public GameObject canvasZeroPoint;
    public GameObject canvasUpSilver;
    public GameObject canvasUpGold;
    public GameObject happyIcon;
    public GameObject silver;
    public GameObject gold;
    public GameObject bronze;
    public static string nameCharact;
    public static int finalScore;
    public static bool endGame = false;

    // Update is called once per frame
    public void Start()
    {
        firstScore = false;
        canvasZeroPoint = GameObject.Find("CanvasZeroPoint");
        canvasFirstPlay = GameObject.Find("CanvasFirstPlay");
        canvasGameOver = GameObject.Find("CanvasGameOver");
        canvasUpSilver = GameObject.Find("CanvasUpSilver");
        canvasUpGold = GameObject.Find("CanvasUpGold");
        canvasWin = GameObject.Find("CanvasWin");
        canvasFail = GameObject.Find("CanvasFail");
        happyIcon = GameObject.Find("Happy");
        bronze = GameObject.Find("Bronze");
        silver = GameObject.Find("Silver");
        gold = GameObject.Find("Gold");
    }

    public void Update()
    {
        try
        {
            if (GameObject.Find("TimeBarImg").GetComponent<TimerScript>().gameOver == true)
            {              
                GameObject.Find("Canvas").GetComponent<HideControls>().Hide();
                medal = "";
                medal = GameObject.Find("Canvas").GetComponent<SaveDatas>().ReturnMedal();
                //Debug.Log("La medaille d'avant etait => " + Game.medalState +" "+"La medaille de maintenant est => "+medal);
                switch (medal)
                {
                    case "bronze":
                        silver.SetActive(false);
                        gold.SetActive(false);
                        canvasUpSilver.SetActive(false);
                        canvasUpGold.SetActive(false);
                        break;
                    case "silver":
                        bronze.SetActive(false);
                        gold.SetActive(false);
                        if (Game.medalState == "bronze" && medal == "silver")
                        {
                            silverUp = true;
                            canvasUpGold.SetActive(false);
                        }
                        else
                        {
                            silverUp = false;
                            canvasUpSilver.SetActive(false);
                            canvasUpGold.SetActive(false);
                        }
                        break;
                    case "gold":
                        bronze.SetActive(false);
                        silver.SetActive(false);
                        if (Game.medalState == "silver" && medal == "gold" || Game.medalState == "bronze" && medal == "gold")
                        {
                            goldUp = true;
                            canvasUpSilver.SetActive(false);
                        }
                        else
                        {
                            goldUp = false;
                            canvasUpSilver.SetActive(false);
                            canvasUpGold.SetActive(false);
                        }
                        break;
                }

                SaveDatas.deleteData = false;
                Time.timeScale = 0;
                canvasGameOver.SetActive(true);
                finalScore = Game.sc;
                GameObject.Find("CanvasGameOver").GetComponentsInChildren<Text>()[0].text = "Fin de partie, ton score : " + finalScore + "/" + Game.totalQuestion;
                Game.numberCurrentQuestion = 0;

                if (finalScore > 0)
                {
                    if (SaveDatas.win == true)
                    {
                        canvasWin.SetActive(true);
                        if (silverUp == true)
                        {
                            canvasWin.GetComponentsInChildren<Text>()[0].text = "Félicitation, tu as obtenu la medaille d'argent";
                            silverUp = false;
                        }
                        else if (goldUp == true)
                        {
                            canvasWin.GetComponentsInChildren<Text>()[0].text = "Félicitation, tu as obtenu la medaille d'or";
                            goldUp = false;
                        }
                        else
                            if (SaveDatas.fisrtTimePLay == true)
                            canvasWin.GetComponentsInChildren<Text>()[0].text = "Cool, tu viens de faire ton premier score";
                        else
                            canvasWin.GetComponentsInChildren<Text>()[0].text = "Bravo, tu as battu ton propre record !";

                        if (Choice.sizeList == finalScore && goldUp == false)
                        {
                            canvasWin.GetComponentsInChildren<Text>()[0].text = "Ma sha Allah, tu as eu le meilleur score. Bravo !";
                        }

                        canvasFail.SetActive(false);
                        canvasFirstPlay.SetActive(false);
                        canvasZeroPoint.SetActive(false);
                        PauseMenu.pause = false;
                        nameCharact = Game.characterName;
                    }

                    else if (SaveDatas.win == false)
                    {
                        canvasFail.SetActive(true);
                        canvasFail.GetComponentsInChildren<Text>()[0].text = "Je sais que tu peux faire mieux !";
                        canvasWin.SetActive(false);
                        canvasFirstPlay.SetActive(false);
                        canvasZeroPoint.SetActive(false);
                        PauseMenu.pause = false;
                        nameCharact = Game.characterName;
                    }
                }
                else if (finalScore == 0)
                {
                    canvasZeroPoint.SetActive(true);
                    canvasZeroPoint.GetComponentsInChildren<Text>()[0].text = "Essai encore.. ";
                    canvasWin.SetActive(false);
                    canvasFail.SetActive(false);
                    canvasFirstPlay.SetActive(false);
                    PauseMenu.pause = false;
                    nameCharact = Game.characterName;
                    GameObject.Find("Canvas").GetComponent<SaveDatas>().SaveFile(Deconnexion.pseudo, GameObject.Find("Canvas").GetComponent<Game>().incrementScore);
                    finalScore = -1;
                }
                showGUI = true;
                endGame = true;
            }
            else
            {
                canvasGameOver.SetActive(false);
            }
        }
        catch (Exception) { }
    }
}

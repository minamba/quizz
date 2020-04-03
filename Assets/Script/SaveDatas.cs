using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Assets.Script;
using UnityEngine.UI;
using System;
//using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using System.Linq;

public class SaveDatas : MonoBehaviour {
    // write datas in json files
    public GameDatas scoreControl;
    public GameDatas getScore;
    public GameDatas data;
    public GameDatas data_2;
    public GameDatas data_3;
    public GameDatas data_4;
    public GameDatas data_5;
    public GameDatas data_6;
    private GameObject grid;
    private GameObject button;
    public GameObject player;
    public static int getScoreSaved;
    public static bool win = false;
    private string destination;
    private string destinations_2;
    private string destinations_3;
    private string destinations_4;
    private string dest;
    private string loadScore;
    private double bronzeScore;
    private double silverScore;
    private double goldScore;
    private double bronzeMedal;
    private double silverMedal;
    private double goldMedal;
    private string charactSelected;
    public static List<GameObject> scoreIdItem = new List<GameObject>();
    public static string tempCharactSelected= "vide";
    private bool refresh = false;
    public GameObject canvas;
    public static bool deleteData = false;
    public static bool fisrtTimePLay;
    private bool dg = false;
    private bool dg2 = false;
    public static bool stopCHallenge_1 = false;


    public void Start()
    {
        getScoreSaved = 0;
        fisrtTimePLay = false;
        if (Game.characterName == "Aleatoir")
        {
            destination = Application.persistentDataPath + "/" + "RandomCharacter" + ".json";
        }
        else
        {
            destination = Application.persistentDataPath + "/" + Game.characterName + ".json";
        }
        //CreateFiles();
        //ShowDatas();

        try
        {
            RefreshScoreTable();
        }
        catch (Exception)
        {
            return;
        }
    }



    //SAVE SCORE/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void SaveFile(string pseudo, int scoreEnCours)
    {
        CallWebService webServ = new CallWebService();

        if (ChallengeDemand.challengeActivate != true && ChallengeSniffer.challengeActivate2 != true)
        {
            int? controleScore = webServ.GetUserScoreByCharacter(pseudo, Game.characterName);

            try
            {
                if (scoreEnCours > 0)
                {
                    if (controleScore < scoreEnCours)
                    {
                        win = true;
                        GameObject.Find("AudioLevelUp").GetComponent<AudioSource>().Play(); //Play correct sound
                        //Debug.Log("dddddddddddddddddddddddddddddddd : " + scoreControl.Score + " || " + scoreEnCours);
                        Debug.Log("ta battu ton record");
                        if (webServ.ControleScoreExist(pseudo, Game.characterName) == false)
                        {
                            webServ.SaveScore(pseudo, Game.characterName, scoreEnCours);
                            fisrtTimePLay = true;
                        }
                        else if (webServ.ControleScoreExist(pseudo, Game.characterName) == true)
                        {
                            webServ.DeleteScore(pseudo, Game.characterName);
                            webServ.SaveScore(pseudo, Game.characterName, scoreEnCours);
                        }
                    }
                    else if (scoreEnCours == Choice.sizeList)
                    {
                        win = true;
                    }
                    else
                    {
                        win = false;
                        GameObject.Find("AudioLevelFail").GetComponent<AudioSource>().Play();// play level fail sond
                        /*Debug.Log("ta pas battu ton record");*/
                    }
                }
                else if (scoreEnCours == 0)
                {
                    if (webServ.GetUserScoreByCharacter(pseudo, Game.characterName) == -1)
                        webServ.SaveScore(pseudo, Game.characterName, scoreEnCours);
                    stopCHallenge_1 = true;
                }
            }
            catch (Exception e)
            {
                //Debug.Log(e.Message);
            }
        }
        else if(ChallengeDemand.challengeActivate == true)
        {
            if (dg == false)
            {
                if (ChallengeDemand.DemandeurCHallenge != null)
                {
                    //Debug.Log("demandeur de challengeeeeeeeeeeeeeeeeeeeeeeé : "+ scoreEnCours);
                    webServ.RegisterDuelUpDate(ChallengeDemand.DemandeurCHallenge, ChallengeDemand.candidatChallengeClicked,DropDown.dropDownSelected,scoreEnCours,pseudo);
                    //ChallengeDemand.challengeActivate = false;
                }
                dg = true;
            }
        }
        else if (ChallengeSniffer.challengeActivate2 == true)
        {
            if (dg2 == false)
            {
                //if (ChallengeSniffer.challenger != null)
                //{
                    //Debug.Log("CELUI QUI A ACCEPTE LE CHALLENGE");
                    webServ.RegisterDuelUpDate(ChallengeSniffer.challenger, pseudo, ChallengeSniffer.character, scoreEnCours, pseudo);
                    //ChallengeSniffer.challengeActivate2 = false;
                //}
                dg2 = true;
            }

        }
    }

    //SCORE TRACKING/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //SAVE SCORE/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void SaveFileTracking(string pseudo, int scoreEnCours)
    {
        CallWebService webServ = new CallWebService();
            try
            {
                webServ.SaveScoreTracking(pseudo, Game.characterName, scoreEnCours);            
            }
            catch (Exception e)
            {
                //Debug.Log(e.Message);
            }
       
    }


    //REFRESH THE GENERAL TABLE SCORE WHEN WE CHANGE THE CHARACTER///////////////////////////////////////////////////////////////////////////////
    public void RefreshScoreTable()
    {
        try
        {
            CallWebService cw = new CallWebService();
            grid = GameObject.Find("GridWithOurElements");
            button = GameObject.Find("Bukharii");

            if (DropDown.dropDownSelected != null)
            {
                //je detruis les objects crée a chaque selection de personnage
                if (scoreIdItem.Count != 0)
                {
                    for (int o = 0; o < scoreIdItem.Count; o++)
                    {
                        Destroy(scoreIdItem[o]);
                    }
                }
                List<t_scores> scoresList = cw.ScoreUserByCharacter(DropDown.dropDownSelected);
                int? totalPoint = cw.TotalPointByCharacter(DropDown.dropDownSelected);

                bronzeMedal = 0.5 * (double)totalPoint;
                silverMedal = 0.8 * (double)totalPoint;
                goldMedal = (double)totalPoint;

                for (int i = 0; i <= scoresList.Count; i++)
                {
                    int? score = scoresList[i].s_score;
                    if (score < 0)
                        score = 0;

                    player = Instantiate(button);// instantiate permet de copier un gameobject ! ici je copy le bouton Bukhari
                    //player.GetComponentsInChildren<Canvas>()[2].enabled = false; //obligé de dupliquer les 3 lignes de dessous ici sinon j'ai un bug d'affichage
                    //player.GetComponentsInChildren<Canvas>()[1].enabled = false;
                    //player.GetComponentsInChildren<Canvas>()[0].enabled = false;
                    int? uid = scoresList[i].s_fk_user_id;
                    player.GetComponentsInChildren<Text>()[0].text = cw.UserPseudonym((int)uid);
                  
                    //Debug.Log("score : " + score);
                    player.GetComponentsInChildren<Text>()[1].text = score.ToString() + "/" + totalPoint;


                    if (score > 0 && score <= bronzeMedal || score <= 0)
                    {
                        //Debug.Log("medaille de bronze");
                        player.GetComponentsInChildren<RawImage>()[2].enabled = true;
                        player.GetComponentsInChildren<RawImage>()[1].enabled = false;
                        player.GetComponentsInChildren<RawImage>()[0].enabled = false;
                    }
                    else if (score > bronzeMedal && score <= silverMedal)
                    {
                        //Debug.Log("medaille de argent");
                        player.GetComponentsInChildren<RawImage>()[2].enabled = false;
                        player.GetComponentsInChildren<RawImage>()[1].enabled = true;
                        player.GetComponentsInChildren<RawImage>()[0].enabled = false;
                    }
                    else
                    {
                        //Debug.Log("medaille de or");
                        player.GetComponentsInChildren<RawImage>()[2].enabled = false;
                        player.GetComponentsInChildren<RawImage>()[1].enabled = false;
                        player.GetComponentsInChildren<RawImage>()[0].enabled = true;
                    }
                    player.transform.parent = grid.transform;
                    scoreIdItem.Add(player); //ajout des objects fraichement crée dans un tableau
                }
            }
        }
        catch(Exception e)
        {
            //Debug.Log(e.Message);
            return;
        }
    }


    //REtURN THE MEDAL AT THE END OF A PARTY///////////////////////////////////////////////////////////////////////////////
    public string ReturnMedal()
    {
        string medal;
        CallWebService webServ = new CallWebService();

        webServ.ListOfQuestionsByCharacter(Game.characterName);

        bronzeScore = 0.5 * webServ.CountQuestionsByCharacter(Game.characterName);
        silverScore = 0.8 * webServ.CountQuestionsByCharacter(Game.characterName);
        goldScore = webServ.CountQuestionsByCharacter(Game.characterName);


        try
        {
            int? scoreR = webServ.GetUserScoreByCharacter(Deconnexion.pseudo, Game.characterName);

            if (scoreR > 0 && scoreR <= bronzeScore || scoreR <= 0)
            {
                medal = "bronze";
            }
            else if (scoreR > bronzeScore && scoreR <= silverScore)
            {
                medal = "silver";
            }
            else
            {
                medal = "gold";
            }

            return medal;
        }
        catch (Exception e)
        {
            //Debug.Log(e.Message);
            return e.Message;
        }
    }


    //REINITIALISATION DES SCORES//////////////////////////////////////////////////////////////////////////////////////////////////
    public void ReinitializeScore()
    {
        StartCoroutine(LaunchReinitializeScore());
    }


    public IEnumerator LaunchReinitializeScore()
    {
        yield return new WaitForSeconds((float)0.5);
        CallWebService cw = new CallWebService();
        for (int i = 1; i <= cw.CharactersList().Count; i++)
        {
            cw.DeleteScore(Deconnexion.pseudo, cw.CharactersList()[i]);
        }
    }











    //////////////////////////////////////////////////////////////DATA MANAGEMENEMT WITH JSON FILE (OLD)///////////////////////////////////////////////////////////////////////////

    //public void SaveFile(int scoreEnCours)
    //{

    //    if (Game.characterName == "Aleatoir")
    //    {
    //        data = new GameDatas("RandomCharacter", scoreEnCours);
    //    }
    //    else
    //    {
    //        data = new GameDatas(Game.characterName, scoreEnCours);
    //    }

    //    StreamWriter sw1;
    //    //Debug.Log("delete data : " + deleteData);
    //    if (deleteData == false)
    //    {

    //        try
    //        {
    //            string loadedDatas = File.ReadAllText(destination);
    //            data_4 = JsonUtility.FromJson<GameDatas>(loadedDatas);
    //            string jsonDataString = JsonUtility.ToJson(data, true);
    //            scoreControl.Score = data_4.Score;
    //            if (!File.Exists(destination))
    //            {
    //                sw1 = System.IO.File.CreateText(destination);
    //                sw1.Close();
    //            }

    //            else
    //            {
    //                scoreControl.Score = data_4.Score;
    //                getScoreSaved = scoreControl.Score;
    //                //Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA : " + scoreControl.Score + "|||||||||||||||||" + scoreEnCours);
    //                if (scoreEnCours > 0)
    //                {
    //                    //Debug.Log("Score enregistré dans le fichier : " + scoreControl.Score);
    //                    if (scoreControl.Score < scoreEnCours)
    //                    {
    //                        win = true;
    //                        //Debug.Log("dddddddddddddddddddddddddddddddd : " + scoreControl.Score + " || " + scoreEnCours);
    //                        //Debug.Log("ta battu ton record");                            
    //                        sw1 = new StreamWriter(destination);
    //                        sw1.WriteLine(jsonDataString);
    //                        sw1.Close();
    //                        scoreControl.Score = 0;
    //                    }
    //                    else if (scoreEnCours == Choice.sizeList)
    //                    {
    //                        win = true;
    //                        scoreControl.Score = 0;
    //                    }
    //                    else
    //                    {
    //                        win = false;
    //                        //Debug.Log("ta pas battu ton record");                         
    //                    }
    //                }
    //                else if (scoreEnCours == 0)
    //                {
    //                    sw1 = new StreamWriter(destination);
    //                    sw1.WriteLine(jsonDataString);
    //                    sw1.Close();
    //                    scoreControl.Score = 0;
    //                }
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            Debug.Log(e.Message);
    //        }
    //    }
    //}


    //SAVE DATAS WITH DATABASE

    //REFRESH THE GENERAL TABLE SCORE WHEN WE CHANGE THE CHARACTER///////////////////////////////////////////////////////////////////////////////

    //SAVE SCORE//////////////////////////////////////////////////////////////////////////////////////////////////////////////////




    //LOAD FILE AND SHOW IT IN SCORE TABLE
    //    public void ShowDatas()
    //    {
    //        Questions q = new Questions();
    //        int count = q.SizeQuestionsTable(q.NameOFCharacters());
    //        List<string> lst = new List<string>();

    //        for (int i = 0; i < count; i++)
    //        {
    //            /////////////////////////////////////////////GET DATA FROM PATH WITH UNITY EDITOR OR ANDROID!! DECOMENTER LA PARTIE ANDROID AINSI QUE LE IF UNITY_EDITOR SI JE VEUX EXPORTER SUR TELEPHONE///////////////////////////////////////
    //#if UNITY_EDITOR
    //            destinations_2 = Application.persistentDataPath + "/" + q.NameOFCharacters()[i] + ".json";
    //#elif UNITY_ANDROID
    //            destinations_2 = Application.persistentDataPath + "/" + q.NameOFCharacters()[i] + ".json";
    //            StartCoroutine(GetDataInAndroid(destinations_2));
    //#endif
    //            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //            if (!File.Exists(destinations_2))
    //            {
    //                File.Create(destinations_2);
    //            }

    //            try
    //            {
    //                loadScore = File.ReadAllText(destinations_2);
    //                data_2 = JsonUtility.FromJson<GameDatas>(loadScore);
    //            }
    //            catch (Exception e)
    //            {
    //                Debug.Log(e.Message);
    //            }

    //            switch (q.NameOFCharacters()[i])
    //            {
    //                case "Bukhari":
    //                    lst =  q.Bukhari();
    //                    break;

    //                case "OmarAlMoukhtar":
    //                    lst = q.OmarAlMoukhtar();
    //                    break;
    //                case "IbnKhaldoun":
    //                    lst = q.IbnKhaldoun();
    //                    break;

    //                case "RandomCharacter":
    //                    lst = q.RandomCharacter();
    //                    break; 

    //                default:
    //                    lst = q.RandomCharacter();
    //                    break;
    //            }

    //            try
    //            {

    //                //Debug.Log("DATA : " + data_2.Score);
    //                ///////Je determine le grade des medailles//////
    //                bronzeScore = 0.5 * q.SizeQuestionsTable(lst);
    //                silverScore = 0.8 * q.SizeQuestionsTable(lst);
    //                goldScore = q.SizeQuestionsTable(lst);
    //                ShowMedal(data_2.Score, q.NameOFCharacters()[i]);
    //                if (data_2.Score == -1)
    //                {
    //                    GameObject.Find(q.NameOFCharacters()[i]).GetComponentsInChildren<Text>()[1].text = 0 + "/" + q.SizeQuestionsTable(lst) + "";
    //                }
    //                else {
    //                    GameObject.Find(q.NameOFCharacters()[i]).GetComponentsInChildren<Text>()[1].text = data_2.Score.ToString() + "/" + q.SizeQuestionsTable(lst) + "";
    //                }
    //            }
    //            catch(Exception e)
    //            {
    //                return;           
    //            }
    //        }

    //        RefreshScoreTable();
    //    }

    //JE RAFRAIVCHI LE TABLEAU A CHAQUE FOIS Q'UN PERSONNAGE EST SELECTIONNE//////////////////////////////////////////////////////////////////////////////////////////////////////



    ////TO LOAD FILE ON ANDROID
    //IEnumerator GetDataInAndroid(string url)
    //{
    //    WWW www = new WWW(url);
    //    yield return www;
    //    try
    //    {
    //        if (www.text != null)
    //        {
    //            string dataAsJson = www.text;
    //            GameDatas loadedData = JsonUtility.FromJson<GameDatas>(dataAsJson);
    //        }
    //    }
    //    catch (Exception e)
    //    {
    //        GameObject.Find("Chemin").GetComponentsInChildren<Text>()[0].text = e.Message;
    //    }     
    //}



    //public void ShowMedal(int score, string nameCharacter)
    //{
    //    Canvas[] canvasObjects = GetComponentsInChildren<Canvas>();
    //        switch (nameCharacter)
    //        {
    //            case "Bukhari":

    //                if (score > 0 && score <= bronzeScore || score <= 0)
    //                {
    //                    //Debug.Log("medaille de bronze");
    //                    canvasObjects[1].enabled = false;
    //                    canvasObjects[2].enabled = false;
    //                }
    //                else if (score > bronzeScore && score <= silverScore)
    //                {
    //                    //Debug.Log("medaille de argent");
    //                    canvasObjects[1].enabled = false;
    //                    canvasObjects[3].enabled = false;
    //                }
    //                else
    //                {
    //                    //Debug.Log("medaille de or");
    //                    canvasObjects[2].enabled = false;
    //                    canvasObjects[3].enabled = false;
    //                }
    //                    break;

    //        case "OmarAlMoukhtar":

    //                if (score > 0 && score <= bronzeScore || score <= 0)
    //                {
    //                    //Debug.Log("medaille de bronze");
    //                    canvasObjects[4].enabled = false;
    //                    canvasObjects[5].enabled = false;
    //                }
    //                else if (score > bronzeScore && score <= silverScore)
    //                {
    //                    //Debug.Log("medaille de argent");
    //                    canvasObjects[4].enabled = false;
    //                    canvasObjects[6].enabled = false;
    //                }
    //                else
    //                {
    //                    //Debug.Log("medaille de or");
    //                    canvasObjects[5].enabled = false;
    //                    canvasObjects[6].enabled = false;
    //                }

    //                    break;
    //        case "IbnKhaldoun":

    //                if (score > 0 && score <= bronzeScore || score <= 0)
    //                {
    //                    //Debug.Log("medaille de bronze");
    //                    canvasObjects[7].enabled = false;
    //                    canvasObjects[8].enabled = false;
    //                }
    //                else if (score > bronzeScore && score <= silverScore)
    //                {
    //                     //Debug.Log("medaille de argent");
    //                    canvasObjects[7].enabled = false;
    //                    canvasObjects[9].enabled = false;
    //                }
    //                else
    //                {
    //                     //Debug.Log("medaille de or");
    //                    canvasObjects[8].enabled = false;
    //                    canvasObjects[9].enabled = false;
    //                }

    //                    break;

    //        case "RandomCharacter":

    //                if (score > 0 && score <= bronzeScore || score <= 0)
    //                {
    //                    //Debug.Log("medaille de bronze");
    //                    canvasObjects[10].enabled = false;
    //                    canvasObjects[11].enabled = false;
    //                }
    //                else if (score > bronzeScore && score <= silverScore)
    //                {
    //                    //Debug.Log("medaille de argent");
    //                    canvasObjects[10].enabled = false;
    //                    canvasObjects[12].enabled = false;
    //                }
    //                else
    //                {
    //                    //Debug.Log("medaille de or");
    //                    canvasObjects[11].enabled = false;
    //                    canvasObjects[12].enabled = false;
    //                }
    //                    break;
    //        default:
    //                    break;                  
    //        }
    //}


    //public string ReturnMedal()
    //{
    //    string load;
    //    string location;
    //    string m;
    //    string medal;
    //    GameDatas d;
    //    string nc;
    //    List<string> l;
    //    Questions q = new Questions();


    //    if (Game.characterName == "Aleatoir")
    //    {
    //        location = Application.persistentDataPath + "/" + "RandomCharacter" + ".json";
    //        nc = "RandomCharacter";
    //    }
    //    else
    //    {
    //        location = Application.persistentDataPath + "/" + Game.characterName + ".json";
    //        nc = Game.characterName;
    //    }


    //    switch (Game.characterName)
    //    {
    //        case "Bukhari":
    //            l = q.Bukhari();
    //            break;

    //        case "OmarAlMoukhtar":
    //            l = q.OmarAlMoukhtar();
    //            break;
    //        case "IbnKhaldoun":
    //            l = q.IbnKhaldoun();
    //            break;

    //        case "RandomCharacter":
    //            l = q.RandomCharacter();
    //            break;

    //        default:
    //            l = q.RandomCharacter();
    //            break;
    //    }


    //    bronzeScore = 0.5 * q.SizeQuestionsTable(l);
    //    silverScore = 0.8 * q.SizeQuestionsTable(l);
    //    goldScore = q.SizeQuestionsTable(l);


    //    try
    //    {

    //        load = File.ReadAllText(location);        
    //        d = JsonUtility.FromJson<GameDatas>(load);
    //        int scoreR = d.Score;
    //        switch (d.CharacterName)
    //        {
    //            case "Bukhari":

    //                if (scoreR > 0 && scoreR <= bronzeScore ||  scoreR <= 0)
    //                {
    //                    medal = "bronze";
    //                }
    //                else if (scoreR > bronzeScore && scoreR <= silverScore)
    //                {
    //                    medal = "silver";
    //                }
    //                else
    //                {
    //                    medal = "gold";
    //                }
    //                return medal;

    //            case "OmarAlMoukhtar":

    //                if (scoreR > 0 && scoreR <= bronzeScore || scoreR <= 0)
    //                {
    //                    medal = "bronze";
    //                }
    //                else if (scoreR > bronzeScore && scoreR <= silverScore)
    //                {
    //                    medal = "silver";
    //                }
    //                else
    //                {
    //                    medal = "gold";
    //                }

    //                return medal;
    //            case "IbnKhaldoun":

    //                if (scoreR > 0 && scoreR <= bronzeScore || scoreR <= 0)
    //                {
    //                    medal = "bronze";
    //                }
    //                else if (scoreR > bronzeScore && scoreR <= silverScore)
    //                {
    //                    medal = "silver";
    //                }
    //                else
    //                {
    //                    medal = "gold";
    //                }

    //                return medal;

    //            case "RandomCharacter":

    //                if (scoreR > 0 && scoreR <= bronzeScore || scoreR <= 0)
    //                {
    //                    medal = "bronze";
    //                }
    //                else if (scoreR > bronzeScore && scoreR <= silverScore)
    //                {
    //                    medal = "silver";
    //                }
    //                else
    //                {
    //                    medal = "gold";
    //                }
    //                return medal;
    //            default:
    //                return null;
    //        }
    //    }
    //    catch (Exception e)
    //    {
    //        Debug.Log(e.Message);
    //        return null;
    //    }
    //}



    //public void DeleteFile()
    //{
    //    deleteData = true;
    //    Questions q = new Questions();
    //    int count = q.SizeQuestionsTable(q.NameOFCharacters());

    //    try
    //    {
    //        //Debug.Log("zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz : " + count);
    //        for (int i = 0; i < count; i++)
    //        {
    //            destinations_3 = Application.persistentDataPath + "/" + q.NameOFCharacters()[i] + ".json";
    //            File.Delete(destinations_3);
    //            //Debug.Log("ggggggggggggggggggggggggggggggggggggggggggggg : " + q.NameOFCharacters()[i]);
    //            data_3 = new GameDatas(q.NameOFCharacters()[i], -1);
    //            string jsonDataString = JsonUtility.ToJson(data_3, true);
    //            StreamWriter sw = System.IO.File.CreateText(destinations_3);
    //            sw.WriteLine(jsonDataString);
    //            sw.Close();
    //        }
    //        //Debug.Log("Je remets les scores à zero");

    //        deleteData = false;
    //    }
    //    catch(Exception e)
    //    {
    //        Debug.Log(e.Message);
    //    }
    //}





    //public void CreateFiles()
    //{
    //    Questions q = new Questions();
    //    int count = q.SizeQuestionsTable(q.NameOFCharacters());
    //    GameDatas d;
    //    StreamWriter swDC;
    //    try
    //    {
    //        //Debug.Log("zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz : " + count);
    //        for (int i = 0; i < count; i++)
    //        {
    //            destinations_4 = Application.persistentDataPath + "/" + q.NameOFCharacters()[i] + ".json";

    //            if (!File.Exists(destinations_4))
    //            {
    //                swDC = System.IO.File.CreateText(destinations_4);
    //                swDC.Close();
    //                d = new GameDatas(q.NameOFCharacters()[i], -1);
    //                string jnDataString = JsonUtility.ToJson(d, true);
    //                //File.Delete(destinations_4);
    //                swDC = new StreamWriter(destinations_4);
    //                swDC.WriteLine(jnDataString);
    //                swDC.Close();
    //            }          
    //        }
    //    }
    //    catch (Exception e)
    //    {
    //        Debug.Log(e.Message);
    //    }
    //}


    //    public int ReturnScore(string characterName)
    //    {

    //        string load;


    //        /////////////////////////////////////////////GET DATA FROM PATH WITH UNITY EDITOR OR ANDROID///////////////////////////////////////
    //#if UNITY_EDITOR

    //        if (Game.characterName == "Aleatoir")
    //        {
    //            dest = Application.persistentDataPath + "/" + "RandomCharacter" + ".json";
    //        }
    //        else
    //        {
    //            dest = Application.persistentDataPath + "/" + characterName + ".json";
    //        }

    //#elif UNITY_ANDROID
    //        if (Game.characterName == "Aleatoir")
    //        {
    //            dest = Application.persistentDataPath + "/" + "RandomCharacter" + ".json";
    //        }
    //        else
    //        {
    //            dest = Application.persistentDataPath + "/" + characterName + ".json";
    //        }
    //        StartCoroutine(GetDataInAndroid(dest));
    //#endif
    //        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //        try
    //        {
    //            load = File.ReadAllText(dest);
    //            data_6 = JsonUtility.FromJson<GameDatas>(load);
    //            //Debug.Log("jsuis dans lemethode est le resultat est : " + data_6.Score);
    //            return data_6.Score;
    //        }
    //        catch (Exception e)
    //        {
    //            //Debug.Log("zoba : " + e.Message);
    //            return 0;
    //        }
    //    }
}

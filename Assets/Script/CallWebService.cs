using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Networking;

public class CallWebService : MonoBehaviour
{
    WebService1 webService = new WebService1();





    // Use this for initialization
    void Start()
    {
        StartCoroutine(CharactersListtt());
        StartCoroutine(LevelListtt());
    }

    //LIST OF CHARACTERS
    public IEnumerator CharactersListtt()
    {
        WWW www = new WWW("http://www.ousraty.fr/WebService1.asmx/GetCharacters");

        yield return www;

        Debug.Log(www.text.Length);

    }


    //LIST OF LEVELS
    public IEnumerator LevelListtt()
    {
        WWW www = new WWW("http://www.ousraty.fr/WebService1.asmx/GetLevels");

        yield return www;

        Debug.Log(www.text.Length);

    }


    ////LIST OF CHARACTERS
    //public IEnumerator CharactersListtt()
    //{
    //    WWW www = new WWW("http://192.168.0.41/WebService1.asmx?GetCharacters");

    //    yield return www;

    //    Debug.Log(www.text.Length);

    //}


    ////LIST OF LEVELS
    //public IEnumerator LevelListtt()
    //{
    //    WWW www = new WWW("http://192.168.0.41/WebService1.asmx?GetLevels");

    //    yield return www;

    //    Debug.Log(www.text.Length);
    //}


    //LIST OF CHARACTERS
    public List<string> CharactersList()
    {
        t_characters[] characters = webService.GetCharacters();
        List<string> charactersNames = new List<string>();
        charactersNames.Add("Selectionnez un personnage");
        foreach (var c in characters)
        {
            charactersNames.Add(c.c_name);
        }
        return charactersNames;
    }


    //LIST OF CHARACTERS
    public List<t_characters> CharactersListObject()
    {
        t_characters[] characters = webService.GetCharacters();

        List<t_characters> l = new List<t_characters>();


        foreach(var i  in characters)
        {
            l.Add(i);
        }


        return l;
    }



    //LIST OF ONLINE USER
    public List<t_users> OnlineUserList()
    {
        t_users[] OnlineUser = webService.GetUsersOnline();
        List<t_users> UO = new List<t_users>();

        foreach (var U in OnlineUser)
        {
            UO.Add(U);
        }
        return UO;
    }


    //LIST OF USERS SCORE BY CHARACTER
    public List<t_scores> ScoreUserByCharacter(string name)
    {
        t_scores[] scores = webService.GetScoreByCharacterByName(name);
        List<t_scores> scoreByCharact = new List<t_scores>();

        foreach (var s in scores)
        {
            scoreByCharact.Add(s);
        }
        return scoreByCharact;
    }


    //GET USER PSEUDONYM BY USER ID 
    public string UserPseudonym(int id)
    {
        return webService.GetUserPseudoById(id);
    }


    //GET USER PSEUDONYM BY USER ID 
    public t_users GetUserByPseudo(string pseudo)
    {
        return webService.GetUserByPseudo(pseudo);
    }


    //GET TOTAL POINT OF QUESTIONS BY CHARACTERS
    public int? TotalPointByCharacter(string name)
    {
        int? points = webService.GetTotalPointByCharacter(name);
        return points;
    }


    //USER CONNECTION
    public bool UserConnection(string pseudo, string pwd)
    {
        Debug.Log(webService.UserConnection(pseudo, pwd));
        return webService.UserConnection(pseudo, pwd);
    }


    //USER REGISTER
    public bool UserRegister(string firstName, string lastName, string pseudonym, string pwd, string pwd2, string sexe, int status, string level, string mail)
    {
        //Debug.Log(webService.UserRegister(firstName, lastName, pseudonym, pwd, pwd2,b));
        return webService.UserRegister(firstName, lastName, pseudonym, pwd, pwd2, sexe, status, level, mail);
    }

    //LIST OF QUESTION BY CHARACTER
    public List<string> ListOfQuestionsByCharacter(string name)
    {
        t_questions[] question = webService.ListOfQuestionsByCharacter(name);
        List<string> questionsByCharact = new List<string>();

        foreach (var o in question)
        {
            questionsByCharact.Add(o.q_question);
        }

        return questionsByCharact;
    }

    //GET GOOD RESPONSE
    public string GetGoodResponse(string question)
    {
        using (webService)
        {
            return webService.GetGoodResponseBYQUestion(question);
        }
    }


    //COUNT QUESTIONS BY CHARACTER
    public int CountQuestionsByCharacter(string name)
    {
        return webService.CountQuestions(name);
    }

    //LIST OF RESPONSES
    public List<string> ListOfResponses(string question)
    {
        using(webService)
        {
            t_responses[] responses = webService.ListOfResponsesByQuestion(question);
            List<string> resp = new List<string>();

            foreach (var o in responses)
            {
                resp.Add(o.r_response);
            }

            return resp;
        }
    }

    //GET GOOD RESPONSE
    public string GoodResponse(string question)
    {
        return webService.GetGoodResponseBYQUestion(question);
    }

    //GET POINT
    public int? GetPointByQuestion(string question)
    {
        return webService.GetPointByQuestion(question);
    }

    //GET TIMER 
    public int? GetTimerByQuestion(string question)
    {
        return webService.GeTimerByQuestion(question);
    }

    //SAVE SCORE
    public void SaveScore(string userPseudo, string characterName, int score)
    {
        webService.SaveScore(userPseudo, characterName, score);
    }

    //SAVE SCORE TRACKING
    public void SaveScoreTracking(string userPseudo, string characterName, int score)
    {
        webService.SaveScoreTracking(userPseudo, characterName, score);
    }

    // GET USER SCORE BY CHARACTER
    public int? GetUserScoreByCharacter(string userPseudo, string characterName)
    {
        return webService.GetUserScoreByCharacter(userPseudo, characterName);
    }

    // CONTROLE EXIST SCORE
    public bool ControleScoreExist(string userPseudo, string characterName)
    {
        return webService.ControleScoreExist(userPseudo, characterName);
    }


    //DELETE ROW IN SCORE
    public void DeleteScore(string userPseudo, string characterName)
    {
        webService.DeleteScore(userPseudo, characterName);
    }



    //ALERT CHALLENGER
    public bool RegisterAlertDuel(string userPseudo, string candidatPseudo, string characterName)
    {
        return webService.RegisterAlertDuel(userPseudo, candidatPseudo, characterName);
    }

    //CHALLENGE SNIFFER 
    public t_alert_duel ChallengeSniffer(string userPseudo)
    {
        return webService.ChallengeSniffer(userPseudo);
    }


    //GET CHARACTER NAME BY ID 
    public t_characters GetCharacterNameById(int id)
    {
        return webService.GetCharacterNameById(id);
    }


    //GET CHALLENGE RESPONSE
    public bool RegisterAlertDuelUpDate(string userPseudo, string candidatPseudo, string characterName, bool response)
    {
        return webService.RegisterAlertDuelUpDate(userPseudo, candidatPseudo, characterName, response);
    }


    // CHALLENGE DEMANDE
    public t_alert_duel ChallengeDemand(string userPseudo)
    {
        return webService.ChallengeDemand(userPseudo);
    }


    //GET ALERT DUEL
    public t_alert_duel GetAlertDuel(string userPseudo, string candidatPseudo, string characterName)
    {
        return webService.GetAlertDuel(userPseudo, candidatPseudo, characterName);
    }


    // DELETE ALERT
    public void DeleteAlertDuel(string userPseudo, string candidatPseudo, string characterName)
    {
        webService.DeleteAlertDuel(userPseudo, candidatPseudo, characterName);
    }



    // DUEL REGISTER
    public bool RegisterDuel(string userPseudo, string candidatPseudo, string characterName)
    {
        return webService.RegisterDuel(userPseudo, candidatPseudo, characterName);
    }

    //UPDATE DUEL REGISTER UPDATE
    public void RegisterDuelUpDate(string userPseudo, string candidatPseudo, string characterName, int score, string currentPLayer)
    {
        webService.RegisterDuelUpDate(userPseudo, candidatPseudo, characterName, score, currentPLayer);
    }


    //GET DUEL
    public t_duels GetDuel(string userPseudo, string candidatPseudo, string characterName)
    {
        return webService.GetDuel(userPseudo, candidatPseudo, characterName);
    }

    // DELETE DUEL
    public void DeleteDuel(string userPseudo, string candidatPseudo, string characterName)
    {
        webService.DeleteDuel(userPseudo, candidatPseudo, characterName);
    }

    // GET USER STATUS
    public int? GetUserStatus(string userPseudo)
    {
        return webService.GetUserStatus(userPseudo);
    }

    // UPDATE USER STATUS
    public bool UserUpdateStatus(string userPseudo, int status)
    {
        return webService.UserUpdateStatus(userPseudo, status);
    }


    // GET DUEL CHARACTER ID
    public t_duels GetDuelCharacterId(string userPseudo, string candidatPseudo)
    {
        return webService.GetDuelCharacterId(userPseudo, candidatPseudo);
    }


    // GET LEVELS
    public List<t_levels> GetLevels()
    {
        using (webService)
        {
            t_levels[] levels = webService.GetLevels();
            List<t_levels> l = new List<t_levels>();
            foreach (var lv in levels)
            {
                l.Add(lv);
            }

            return l;
        }
    }


    public List<t_users> GetUsers()
    {
        t_users[] users = webService.GetUsers();
        List<t_users> u = new List<t_users>();

        foreach (var c in users)
        {
            u.Add(c);
        }
        return u;
    }


    //GET LEVEL BY NAME 
    public t_levels GetLevelByName(string name)
    {
        return webService.GetLevelByName(name);
    }


    //GET LEVEL BY ID
    public t_levels GetLevelById(int id)
    {
        return webService.GetLevelById(id);
    }


    //SEND MAIL
    public string SendMail(string mailFrom, string mailTo,string title, string message)
    {
        return webService.SendEmail(mailFrom, mailTo, title, message);
    }

    //GET USER BY EMAIL
    public t_users GetUserByMail(string mail)
    {
        return webService.GetUserByMail(mail);
    }

    //GET QUESTIONS LIST BY CHARACTER NAME
    public List<t_questions> GetQuestionsByCharacterName(string name)
    {
        using (webService)
        {
            List<t_questions> q = new List<t_questions>();
            t_questions[] questions = webService.GetQuestionsByCharacterName(name);

            foreach (var i in questions)
            {
                q.Add(i);
            }

            return q;
        }
    }


    //GET LIST OF REPONSES
    public List<t_responses> GetResponses()
    {
        using (webService)
        {
            List<t_responses> rs = new List<t_responses>();
            t_responses[] responses = webService.GetResponse();


            foreach (var i in responses)
            {
                rs.Add(i);
            }

            return rs;
        }
    }


    //GET SCORE TRACKING
    public bool GetScoreTracking(string pseudo, string characterName,int score, DateTime d)
    {
        using (webService)
        {
            bool b = webService.GetScoreTrackingExist(pseudo, characterName, score, d);
            return b;
        }
    }
}

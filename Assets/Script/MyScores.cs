﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyScores : MonoBehaviour {
    public GameObject grid;
    public GameObject button;
    private double bronzeMedal;
    private double silverMedal;
    private double goldMedal;
    public GameObject player;
    private static string pseudo = Deconnexion.pseudo;
    // Use this for initialization
    void Start () {
        ShowMyScores();
    }

    public void ShowMyScores()
    {
        try
        {
            CallWebService cw = new CallWebService();
            grid = GameObject.Find("GridWithOurScoresElements");
            button = GameObject.Find("Bukhari");
            int? score;
            List<string> CharacterList = new List<string>();
            List<t_characters> lc = new List<t_characters>();
            lc = cw.CharactersListObject();

            t_users u = cw.GetUserByPseudo(pseudo);

             
              
            foreach (var o in lc)
            {
                if(o.c_fk_level_id == u.u_fk_level_id)
                {
                    CharacterList.Add(o.c_name);
                }        
            }


            for (int i = 0; i <= CharacterList.Count; i++)
            {

                score = cw.GetUserScoreByCharacter(Deconnexion.pseudo, CharacterList[i]);
                if (score < 0)
                    score = 0;
                int? totalPoint = cw.TotalPointByCharacter(CharacterList[i]);

                bronzeMedal = 0.5 * (double)totalPoint;
                silverMedal = 0.8 * (double)totalPoint;
                goldMedal = (double)totalPoint;

                player = Instantiate(button);// instantiate permet de copier un gameobject ! ici je copy le bouton Bukhari
                player.GetComponentsInChildren<RawImage>()[2].enabled = false; //obligé de dupliquer les 3 lignes de dessous ici sinon j'ai un bug d'affichage
                player.GetComponentsInChildren<RawImage>()[1].enabled = false;
                player.GetComponentsInChildren<RawImage>()[0].enabled = false;

                int? uid = cw.GetUserByPseudo(Deconnexion.pseudo).u_id;
                player.GetComponentsInChildren<Text>()[0].text = CharacterList[i];
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
                //player.SetActive(true);
                player.transform.parent = grid.transform;
            }
        }
        catch(Exception e)
        {
            //Debug.Log(e.Message);     
        }
    }

}

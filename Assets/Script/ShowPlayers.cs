using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowPlayers : MonoBehaviour {
    private static bool b = false;
    private GameObject grid;
    private GameObject button;
    public GameObject player;
    private static string currentUser;
    private static List<t_users> users = new List<t_users>();
    public static List<GameObject> playerItem = new List<GameObject>();
    CallWebService cw = new CallWebService();

    // Use this for initialization
    void Start () {
        currentUser = Deconnexion.pseudo;
        b = false;
        ShowUsers();
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(b);
        if (b == false)
        {
            StartCoroutine(ReloadListPlayer());
            ShowUsers();
            b = true;
        }
    }

    //LIST OF ONLINE USERS///////////////////////////////////////////////////////////////////////////////////////////////////
    public void ShowUsers()
    {
        try
        {      
            grid = GameObject.Find("GridWithOurUsersElements");
            button = GameObject.Find("Bukhari");

            //je detruis les objects crée a chaque rafraichissement de la liste
            if (playerItem.Count != 0)
            {
                for (int o = 0; o < playerItem.Count; o++)
                {
                    Destroy(playerItem[o]);
                }
            }

            //List<t_users> users = cw.GetUsers();

            for (int i = 0; i < users.Count; i++)
            {

                if (users[i].u_pseudonym.Trim() != currentUser)
                {

                    player = Instantiate(button);// instantiate permet de copier un gameobject ! ici je copy le bouton Bukhari
                    player.GetComponentsInChildren<Canvas>()[2].enabled = false; //obligé de dupliquer les 3 lignes de dessous ici sinon j'ai un bug d'affichage
                    player.GetComponentsInChildren<Canvas>()[1].enabled = false;
                    player.GetComponentsInChildren<Canvas>()[0].enabled = false;
                    int? uid = users[i].u_id;
                    player.GetComponentsInChildren<Text>()[0].text = cw.UserPseudonym((int)uid);

                    int? status = users[i].u_status;
                    string s;
                    //Debug.Log(status);

                    if (status == 1)
                    {
                        s = "En ligne";
                    }
                    else if (status == 2)
                    {
                        s = "Occupé";
                        player.GetComponentsInChildren<Button>()[0].enabled = false;
                    }
                    else
                    {
                        s = "Hors ligne";
                    }

                    player.GetComponentsInChildren<Text>()[1].text = s;

                    if (s == "En ligne")
                        player.GetComponentsInChildren<Text>()[1].color = Color.green;
                    else if (s == "Occupé")
                        player.GetComponentsInChildren<Text>()[1].color = new Color(1.0f, 0.65f, 0.0f);
                    else
                        player.GetComponentsInChildren<Text>()[1].color = Color.grey;

                    player.GetComponentsInChildren<Text>()[3].text = users[i].u_pseudonym;

                    if (status == 1)
                    {
                        //Debug.Log("medaille de bronze");
                        player.GetComponentsInChildren<Canvas>()[0].enabled = true;
                        player.GetComponentsInChildren<Canvas>()[1].enabled = false;
                        player.GetComponentsInChildren<Canvas>()[2].enabled = false;
                    }
                    else if (status == 2)
                    {
                        //Debug.Log("medaille de argent");
                        player.GetComponentsInChildren<Canvas>()[2].enabled = false;
                        player.GetComponentsInChildren<Canvas>()[1].enabled = true;
                        player.GetComponentsInChildren<Canvas>()[0].enabled = false;
                    }
                    else
                    {
                        //Debug.Log("medaille de or");
                        player.GetComponentsInChildren<Canvas>()[0].enabled = false;
                        player.GetComponentsInChildren<Canvas>()[0].enabled = false;
                        player.GetComponentsInChildren<Canvas>()[2].enabled = true;
                    }
                    player.transform.parent = grid.transform;
                    playerItem.Add(player); //ajout des objects fraichement crée dans un tableau

                }
            }
        }
        catch (Exception e)
        {
            //Debug.Log(e.Message);
        }
    }



    public IEnumerator ReloadListPlayer()
    {
        yield return new WaitForSeconds(2);
        users = cw.GetUsers();
        b = false;
    }
}

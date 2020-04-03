using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLevels : MonoBehaviour {

    // Use this for initialization
    public static GameObject cpButton;
    public static GameObject ceButton;
    public static GameObject cmButton;
    private string pseudo = Deconnexion.pseudo;
    CallWebService ws = new CallWebService();

    void Start () {
        cpButton = GameObject.Find("CP");
        ceButton = GameObject.Find("CE");
        cmButton = GameObject.Find("CM");

        LevelAcces(pseudo);
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void LevelAcces(string pseudo)
    {

        t_users user = ws.GetUserByPseudo(pseudo);

        int lid = int.Parse(user.u_fk_level_id.ToString());

        var level = ws.GetLevelById(lid);


        switch(level.l_name)
        {
            case "CP":
                ceButton.SetActive(false);
                cmButton.SetActive(false);
                break;
            case "CE":
                cpButton.SetActive(false);
                cmButton.SetActive(false);
                break;
            case "CM":
                cpButton.SetActive(false);
                ceButton.SetActive(false);
                break;
     
            default:
                cpButton.SetActive(false);
                ceButton.SetActive(false);
                cmButton.SetActive(false);

                break;
        }

    }


}

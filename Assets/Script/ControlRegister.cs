using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlRegister : MonoBehaviour {

    CallWebService webServ = new CallWebService();
    public GameObject canvasFormR;
    // Use this for initialization
    void Start () {
        canvasFormR = GameObject.Find("CanvasErrorFormRegister");
        canvasFormR.SetActive(false);
    }

    // Update is called once per frame


    public void CallUserRegister()
    {
        StartCoroutine(UserRegister());
    }

    //USER REGISTER
    public IEnumerator UserRegister()
    {

        t_users u = null;
        bool b = false;
        string lastName = GameObject.Find("lastName").GetComponentsInChildren<Text>()[1].text.ToLower();
        string firstName = GameObject.Find("firstName").GetComponentsInChildren<Text>()[1].text.ToLower();
        string pseudonym = GameObject.Find("pseudonym").GetComponentsInChildren<Text>()[1].text.ToLower();
        string pwd = GameObject.Find("password").GetComponentsInChildren<InputField>()[0].text;
        string pwd2 = GameObject.Find("password2").GetComponentsInChildren<InputField>()[0].text;
        //string mail = GameObject.Find("mail").GetComponentsInChildren<Text>()[1].text;
        string sexe = DropForm.dropDownSelectedSexe;
        string level = DropForm.dropDownSelectedLevel;
        int status = 1;

        if (webServ.UserRegister(firstName, lastName, pseudonym, pwd, pwd2, sexe, status, level, "") == true)
        {
            canvasFormR.SetActive(true);
            GameObject.Find("CanvasErrorFormRegister").GetComponentsInChildren<Text>()[0].color = Color.green;
            GameObject.Find("CanvasErrorFormRegister").GetComponentsInChildren<Text>()[0].text = "Infos";
            GameObject.Find("CanvasErrorFormRegister").GetComponentsInChildren<Text>()[1].text = "Votre inscription a été effectué !";
            GameObject.Find("Ok").SetActive(false);
            yield return new WaitForSeconds(2);
            Application.LoadLevel("Connexion");
        }
        else
        {
            //Debug.Log(level);

            canvasFormR.SetActive(true);


            if (lastName == "")
            {
                GameObject.Find("CanvasErrorFormRegister").GetComponentsInChildren<Text>()[1].text = "Le nom ne doit pas être vide !";
            }

            if (firstName == "")
            {
                GameObject.Find("CanvasErrorFormRegister").GetComponentsInChildren<Text>()[1].text = "Le prénom ne doit pas être vide !";
            }

            if (pseudonym == "")
            {
                GameObject.Find("CanvasErrorFormRegister").GetComponentsInChildren<Text>()[1].text = "Le pseudonym ne doit pas être vide !";
            }
            else
            {
                try
                {
                    u = webServ.GetUserByPseudo(pseudonym);

                    if (u != null)
                    {
                        b = true;
                    }
                }
                catch
                {
                    b = false;
                }


                if (b == true)
                {
                    GameObject.Find("CanvasErrorFormRegister").GetComponentsInChildren<Text>()[1].text = "Ce pseudonym est deja pris !";
                }
                else
                {
                    canvasFormR.SetActive(false);
                    //GameObject.Find("CanvasErrorFormRegister").GetComponentsInChildren<Text>()[0].color = Color.green;
                    //GameObject.Find("CanvasErrorFormRegister").GetComponentsInChildren<Text>()[0].text = "Infos";
                    //GameObject.Find("CanvasErrorFormRegister").GetComponentsInChildren<Text>()[1].text = "Pseudonym valide !";
                }
            }

            canvasFormR.SetActive(true);
            if (sexe == null)
            {

                GameObject.Find("CanvasErrorFormRegister").GetComponentsInChildren<Text>()[1].text = "Selectionnez votre sexe !";
            }

            if (level == null)
            {
                GameObject.Find("CanvasErrorFormRegister").GetComponentsInChildren<Text>()[1].text = "Selectionnez votre niveau !";
            }


            if (pwd != "" && pwd2 != "")
            {
                if (pwd != pwd2)
                {
                    GameObject.Find("CanvasErrorFormRegister").GetComponentsInChildren<Text>()[1].text = "Les mots de passe ne correspondent pas !";
                }
            }
            else
            {
                GameObject.Find("CanvasErrorFormRegister").GetComponentsInChildren<Text>()[1].text = "Les mots de passe ne doivent pas être vide !";
            }

            //canvasForm.GetComponentsInChildren<Text>()[1].text = "Veuillez remplir tous les champs correctement !";
        }
    }

}

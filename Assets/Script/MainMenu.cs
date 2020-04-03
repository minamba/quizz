using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    CallWebService cwb = new CallWebService();

    // Start the game
    private void Start()
    {
        Time.timeScale = 1;
    }

    public void StartGame() {
       StartCoroutine(LaunchStartGame());
	}

    public void StartOption()
    {
        StartCoroutine(LaunchOptionGame());
    }

    public void QuitOption()
    {
        StartCoroutine(LaunchQuitGame());
    }


    public IEnumerator LaunchStartGame()
    {
        yield return new WaitForSeconds((float)0.2);
        Application.LoadLevel("Levels");
    }
	
	//Quit the game
	public IEnumerator LaunchQuitGame() {
        cwb.UserUpdateStatus(Deconnexion.pseudo, 0);
        yield return new WaitForSeconds((float)0.2);
        Application.Quit();
		
	}

    public IEnumerator LaunchOptionGame()
    {
        yield return new WaitForSeconds((float)0.2);
        Application.LoadLevel("Options");
    }

    public void FormPage()
    {
        Application.LoadLevel("Form");
    }


    public void LostPassPage()
    {
        Application.LoadLevel("LostPass");
    }


    //TODO mettre en place le controle du duel, en cas ou l'application a été quitté brutalement pendant le duel
    //public void DeleteDuelIfProblem()
    //{
    //    if (ChallengeDemand.challengeActivate == true)
    //    {
    //        ChallengeDemand.challengeActivate = false;
    //        cwb.DeleteDuel(ChallengeDemand.DemandeurCHallenge, ChallengeDemand.candidatChallengeClicked, "al boukhari"); // il faut que je fasse une boucle sur les perso pour voir si il y a pas un duel qui traine
    //    }
    //}
}

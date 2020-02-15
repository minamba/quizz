using System;
using System.Collections;
using System.Collections.Generic;
//using System.Threading.Tasks; FRAMEWROK 4.6
using UnityEngine;

public class HideControls : MonoBehaviour
{

    public GameObject BulleTalkHome;
    public GameObject BulleTalkCharactereChoice;
    public GameObject LeftBad;
    public GameObject RightBad;
    public GameObject BottomLeftBad;
    public GameObject BottomRightBad;
    public GameObject LeftGood;
    public GameObject RightGood;
    public GameObject BottomLeftGood;
    public GameObject BottomRightGood;
    public GameObject canvasQuestionAnswer;

    // Use this for initialization
    public void Start()
    {
        canvasQuestionAnswer = GameObject.Find("CanvasQuestionAnswer");
        BulleTalkHome = GameObject.Find("Bulle");
        BulleTalkCharactereChoice = GameObject.Find("BulleCharacter");
        LeftBad = GameObject.Find("LeftBad");
        RightBad = GameObject.Find("RightBad");
        BottomLeftBad = GameObject.Find("BottomLeftBad");
        BottomRightBad = GameObject.Find("BottomRightBad");
        LeftGood = GameObject.Find("LeftGood");
        RightGood = GameObject.Find("RightGood");
        BottomLeftGood = GameObject.Find("BottomLeftGood");
        BottomRightGood = GameObject.Find("BottomRightGood");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Hide()
    {
        try
        {
            canvasQuestionAnswer.SetActive(false);
        }
        catch (Exception) { }
    }

    public void Enable()
    {
        canvasQuestionAnswer.SetActive(true);
    }

    public void HideBadGoodResponses()
    {
        LeftBad.SetActive(false);
        RightBad.SetActive(false);
        BottomLeftBad.SetActive(false);
        BottomRightBad.SetActive(false);

        LeftGood.SetActive(false);
        RightGood.SetActive(false);
        BottomLeftGood.SetActive(false);
        BottomRightGood.SetActive(false);
    }



    public IEnumerator ShowBullTalkHome()
    {
        BulleTalkHome.SetActive(true);

        yield return new WaitForSeconds(2);
        BulleTalkHome.SetActive(false);
    }

    public IEnumerator ShowBullTalkCharacterChoice()
    {
        Debug.Log("jai cliqué");
        BulleTalkCharactereChoice.SetActive(true);

        yield return new WaitForSeconds(2);
        BulleTalkCharactereChoice.SetActive(false);
    }



    //FRAMEWORK 4.6////////////////////////////////////////////////////////////////////////////////
    //public async void ShowBullTalkHome()
    //{
    //    BulleTalkHome.SetActive(true);

    //    await Task.Delay(System.TimeSpan.FromSeconds(2));
    //    BulleTalkHome.SetActive(false);
    //}

    //public async void ShowBullTalkCharacterChoice()
    //{
    //    Debug.Log("jai cliqué");
    //    BulleTalkCharactereChoice.SetActive(true);

    //    await Task.Delay(System.TimeSpan.FromSeconds(2));
    //    BulleTalkCharactereChoice.SetActive(false);
    //}
    //FRAMEWORK 4.6 end////////////////////////////////////////////////////////////////////////////////
}


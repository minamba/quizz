using System;
using System.Collections;
using System.Collections.Generic;
//using System.Threading.Tasks; framework 4.6
using UnityEngine;
using UnityEngine.UI;

public class GoodBadResponses : MonoBehaviour {
    public static float ctdownValue;
    public GameObject canvasGood;
    public GameObject canvasBad;

    // Use this for initialization
    public void Start()
    {
        //StartCoroutine(GoodAnimation());
        //StartCoroutine(BadAnimation());  

        canvasGood = GameObject.Find("AnimationGood");
        canvasBad = GameObject.Find("AnimationBad");
    }

    public void AnimationGood()
    {
      GoodAnimation();
    }

    public void AnimationBad()
    {
      BadAnimation();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Responses.showGoodAnimation == true)
        {
            //Debug.Log("l'animation est activé, je la desactive");
            Responses.showGoodAnimation = false;
            canvasGood.SetActive(false);
        }
        else if (Responses.showBadAnimation == true)
        {
            //Debug.Log("l'animation est activé, je la desactive");
            Responses.showBadAnimation = false;
            canvasBad.SetActive(false);
        }
    }

    public IEnumerator GoodAnimation()
    {
        //Debug.Log("Bonne reponse j'affiche l'animation Good");      
        yield return new WaitForSeconds((float)0.1);
        if (canvasGood != null)
        {
          
            canvasGood.SetActive(true);
        }
    }

    public IEnumerator BadAnimation()
    {
        //Debug.Log("Mauvaise reponse, j'affiche l'animation Bad");
        yield return new WaitForSeconds((float)0.1);

        if (canvasBad != null)
        {
           
            canvasBad.SetActive(true);
        }
    }


    //FRAMEWROK 4.6/////////////////////////////////////////////////////////////////////////////////////////////
    // public async void GoodAnimation()
    //{
    //    //Debug.Log("Bonne reponse j'affiche l'animation Good");      
    //    await Task.Delay(TimeSpan.FromSeconds(0.1));
    //    if (canvasGood != null)
    //    {
    //        canvasGood.SetActive(true);
    //    }
    //}

    //public async void BadAnimation()
    //{
    //    //Debug.Log("Mauvaise reponse, j'affiche l'animation Bad");
    //    await Task.Delay(TimeSpan.FromSeconds(0.1));

    //    if (canvasBad != null)
    //    {
    //        canvasBad.SetActive(true);
    //    }
    //}
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
}

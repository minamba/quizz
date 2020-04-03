using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSartGame : MonoBehaviour
{
    public static int currCountdownValue;
    public GameObject CanvasHand1;
    public GameObject CanvasHand2;
    public GameObject CanvasHand3;
    // Use this for initialization
    public void Start()
    {
        CanvasHand1 = GameObject.Find("CanvasHand1");
        CanvasHand2 = GameObject.Find("CanvasHand2");
        CanvasHand3 = GameObject.Find("CanvasHand3");
        StartCoroutine(StartCountdown());
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(currCountdownValue);
    }


    public IEnumerator StartCountdown(int countdownValue = 3)
    {
        GameObject.Find("AudioCompteur").GetComponent<AudioSource>().Play();
        currCountdownValue = countdownValue;
        while (currCountdownValue >= 0)
        {

            switch (currCountdownValue)
            {
                case 3:
                    CanvasHand1.SetActive(false);
                    CanvasHand2.SetActive(false);
                    break;

                case 2:
                    CanvasHand1.SetActive(false);
                    CanvasHand3.SetActive(false);
                    CanvasHand2.SetActive(true);
                    break;
                case 1:
                    CanvasHand2.SetActive(false);
                    CanvasHand3.SetActive(false);
                    CanvasHand1.SetActive(true);
                    break;

                case 0:
                    CanvasHand2.SetActive(false);
                    CanvasHand3.SetActive(false);
                    CanvasHand1.SetActive(false);
                    break;
            }
            //Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;

            //if (currCountdownValue == 0)
            //Debug.Log("ddd" + currCountdownValue);
        }

    }
}

using Assets.Script;
using System.Collections;
using System.Collections.Generic;
//using System.Threading.Tasks; framework 4.6
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Responses : MonoBehaviour
{
    private GameObject canvasGood;
    private GameObject canvasBad;
    private GameObject showBadColor;
    private GameObject showGoodColor;
    private static int sizeTableAnwers;
    public static int pointCount = 0;
    public static bool showGoodAnimation = false;
    public static bool showBadAnimation = false;
    CallWebService ws = new CallWebService();
    public void Start()
    {
        canvasGood = GameObject.Find("AnimationGood");
        canvasBad = GameObject.Find("AnimationBad");
    }

    public IEnumerator  OnMouseDown(){
        Questions q = new Questions();
        sizeTableAnwers = q.SizeQuestionsTable(q.ListOfAnswers());

        if (GameObject.Find("Canvas").GetComponent<Game>().response == transform.GetChild(2).GetComponent<Text>().text)
        {
            GameObject.Find("AudioCorrect").GetComponent<AudioSource>().Play(); //Play correct sound
            //Debug.Log("gagné");
            showGoodAnimation = true;
            if (showGoodAnimation == true)
            {         
                //canvasGood.SetActive(true);
                showBadColor = this.gameObject.transform.GetChild(1).gameObject;
                showBadColor.SetActive(true);
                StartCoroutine(canvasGood.GetComponent<GoodBadResponses>().GoodAnimation());
                //await Task.Delay(System.TimeSpan.FromSeconds(1)); framew<ork 4.6
                yield return new WaitForSeconds(1);
                showBadColor.SetActive(false);
                TimerScript.click = true;
            }
            GameObject.Find("Canvas").GetComponent<Game>().incrementScore += 1;
            pointCount += Game.point;
        }
        else
        {
            GameObject.Find("AudioFail").GetComponent<AudioSource>().Play();
            //Debug.Log("perdu");
            showBadAnimation = true;
            if (showBadAnimation == true)
            {
                //Debug.Log(sizeTableAnwers);
                for (int i = 0; i < sizeTableAnwers; i++)
                {
                    if (GameObject.Find(q.ListOfAnswers()[i]).GetComponentsInChildren<Text>()[0].text == GameObject.Find("Canvas").GetComponent<Game>().response)
                    {
                       t_users u = ws.GetUserByPseudo(Deconnexion.pseudo);

                        if (u.u_fk_level_id == 1)
                        {
                            //Debug.Log(q.ListOfAnswers()[i]);
                            showBadColor = GameObject.Find(q.ListOfAnswers()[i]);
                            showBadColor = showBadColor.transform.GetChild(1).gameObject;
                            showBadColor.SetActive(true);
                        }
                    }
                }
                showBadColor = this.gameObject.transform.GetChild(0).gameObject;
                showBadColor.SetActive(true);
                StartCoroutine(canvasBad.GetComponent<GoodBadResponses>().BadAnimation());
                //await Task.Delay(System.TimeSpan.FromSeconds(1)); framework 4.6
                yield return new WaitForSeconds(1);
                showBadColor.SetActive(false);
                TimerScript.click = true;

            }
        }
        //Je lance une nouvelle question que la reponse soit bonne ou pas et je relance le timer
        if (Game.endOfGame != true)
        {
            //await Task.Delay(System.TimeSpan.FromSeconds(0.1)); framework 4.6
            yield return new WaitForSeconds((float)0.1);
            GameObject.Find("Canvas").GetComponent<Game>().RandomQuestion();
            GameObject.Find("TimeBarImg").GetComponent<TimerScript>().maxTime = GameObject.Find("Canvas").GetComponent<Game>().timeSecond; ;
            TimerScript.timeLeft = GameObject.Find("TimeBarImg").GetComponent<TimerScript>().maxTime;
        }
    }
}

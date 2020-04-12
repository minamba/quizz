using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {
    public GameObject buttonSound;
    public GameObject buttonMute;
    //public  AudioSource aud;
    public static bool muted = false;
    static DontDestroy instance = null;
    // Use this for initialization

    void Start()
    {
        //aud = GetComponent<AudioSource>();
        //aud.mute = false;
    }
    //   void Awake () {

    //       GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
    //       if (objs.Length > 1)
    //           Destroy(this.gameObject);
    //       DontDestroyOnLoad(this.gameObject);
    //}


    void Awake()
    {

        //GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        //if (objs.Length > 1)
        //    Destroy(this.gameObject);
        //    DontDestroyOnLoad(this.gameObject);


        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject); 
        }
    }



    public void Mute()
    {
        if(muted == false)
        {
            muted = true;
        }
        else
        {
            muted = false;
        }

        //if(aud.mute ==  false)
        //{
        //    aud.mute = true;
        //    buttonSound.SetActive(false);
        //    buttonMute.SetActive(true);
        //}
        //else
        //{
        //    aud.mute = false;
        //    buttonSound.SetActive(true);
        //    buttonMute.SetActive(false);
        //}

        //aud.mute = !aud.mute;
         //GameObject.Find("Audio Source").SetActive(false);

        //AudioListener.pause = !AudioListener.pause;
    }

}

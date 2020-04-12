using Assets.Script;
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



    public static void Mute()
    {
        if (SoundScript.smuted == true)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }

}

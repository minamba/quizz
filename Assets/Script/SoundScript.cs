using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script
{
    public class SoundScript : MonoBehaviour
    {
        public GameObject buttonSound;
        public GameObject buttonMute;
        public static bool smuted;
        private DontDestroy destroy;
        private static UserStatus datas1;
        private static string destination;

        void Start()
        {
            destroy = GameObject.FindObjectOfType<DontDestroy>();
            buttonSound = GameObject.Find("ButtonListen");
            buttonMute = GameObject.Find("ButtonMute");
            destination = Application.persistentDataPath + "/user.json";
            string loadedDatas = File.ReadAllText(destination);
            datas1 = JsonUtility.FromJson<UserStatus>(loadedDatas);


            if (datas1.SoundPref == false)
            {
                buttonMute.SetActive(true);
                buttonSound.SetActive(false);
                smuted = true;
            }
            else
            {
                buttonMute.SetActive(false);
                buttonSound.SetActive(true);
                smuted = false;
            }

            PauseSound();
        }


        public void PauseSound()
        {
            DontDestroy.Mute();
        }


            public void Mute()
            {

            string load = File.ReadAllText(destination);
            //Debug.Log(load)
;             var datas2 = JsonUtility.FromJson<UserStatus>(load);
            StreamWriter sw1;

            if (datas2.SoundPref == false)
            {
                string json = JsonUtility.ToJson(datas2, true);
                var da = new UserStatus(datas2.UserPseudo, datas2.Status, datas2.Sexe, datas2.Level, true);
                string jnDataString = JsonUtility.ToJson(da, true);
                sw1 = new StreamWriter(destination);
                sw1.WriteLine(jnDataString);
                sw1.Close();
                buttonMute.SetActive(false);
                buttonSound.SetActive(true);
                smuted = false;
            }
            else
            {
                string json = JsonUtility.ToJson(datas2, true);
                var da = new UserStatus(datas2.UserPseudo, datas2.Status, datas2.Sexe, datas2.Level, false);
                string jnDataString = JsonUtility.ToJson(da, true);
                sw1 = new StreamWriter(destination);
                sw1.WriteLine(jnDataString);
                sw1.Close();
                buttonMute.SetActive(true);
                buttonSound.SetActive(false);
                smuted = true;
            }

            PauseSound();
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSky : MonoBehaviour {
    public Material omarAlMoukhtarSky;
    public Material boukhariSky;
    public Material ibnKhaldounSky;
    public Material randomSky;

    void Start()
    {
        string character = Game.characterName;
        switch (character)
        {
            case "Bukhari":
                RenderSettings.skybox = randomSky;
                break;

            case "OmarAlMoukhtar":
                RenderSettings.skybox = omarAlMoukhtarSky;
                break;
            case "IbnKhaldoun":
                RenderSettings.skybox = randomSky;
                break;

            case "RandomCharacter":
                RenderSettings.skybox = randomSky;
                break;

            default:
                RenderSettings.skybox = randomSky;
                break;
        }

    }

}

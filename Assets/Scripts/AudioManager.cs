using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    FMOD.Studio.EventInstance music;
    int musicParam = 0;
    void Start()
    {
        music = FMODUnity.RuntimeManager.CreateInstance("event:/Music");
        music.start();
    }


    public void nextSection()
    {
        musicParam = musicParam +1;
    }

   public void SwitchSection2()
    {
        music.setParameterByName("Lives",musicParam);
    }
    public void SwitchSection3()
    {
        music.setParameterByName("Lives", musicParam);
    }
    public void SwitchSection4()
    {
        music.setParameterByName("Lives", musicParam);
    }

    public void MusicEnd()
    {
        music.setParameterByName("Lives", musicParam);
    }
}

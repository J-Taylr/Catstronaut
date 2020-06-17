using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    FMOD.Studio.EventInstance music;
    float musicParam = 0;
    void Start()
    {
        
    }


    

   public void SwitchSection2()
    {
        music.setParameterByName("Lives", 1);
    }
    public void SwitchSection3()
    {
        music.setParameterByName("Lives", 2);
    }
    public void SwitchSection4()
    {
        music.setParameterByName("Lives", 3);
    }

    public void MusicEnd()
    {
        music.setParameterByName("Lives", 4);
    }
}

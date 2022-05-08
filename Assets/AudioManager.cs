using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource Backgroundmusic;
    public AudioClip Calm;
    public AudioClip DubStep;
    private int lastScore;
    private static readonly string FirstPlay = "FirstPlay";
    private int firstPlayInt;
    public Slider backgroundSlider;
    private float backgroundFloat;

    // Start is called before the first frame update
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if(firstPlayInt == 0)
        {

        }
        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {


        //Debug.Log(lastScore);
        if (PlayerPrefs.GetInt("Score") != lastScore)
        {
            BackgroundMusic();
        }
        lastScore = PlayerPrefs.GetInt("Score");
    }
    public void BackgroundMusic()
    {
        AudioClip audioClip;


        if (PlayerPrefs.GetInt("Score") < 1000)
        {
            if (Backgroundmusic.clip != Calm)
            {
                audioClip = Calm;
                Backgroundmusic.clip = Calm;
                Backgroundmusic.Play();
            }

        }
        else
        {
            if(Backgroundmusic.clip != DubStep)
            {
                Backgroundmusic.Stop();
                audioClip = DubStep;
                Backgroundmusic.clip = DubStep;
                Backgroundmusic.Play();
            }
          
        }
    }

}

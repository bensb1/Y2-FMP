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
    private static readonly string BackgroundPref = "BackgroundPref";
    private int firstPlayInt;
    public Slider backgroundSlider;
    private float backgroundFloat;

    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if(firstPlayInt == 0)
        {
            backgroundFloat = 0.125f;
            backgroundSlider.value = backgroundFloat;
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
           backgroundFloat =  PlayerPrefs.GetFloat(BackgroundPref);
            backgroundSlider.value = backgroundFloat;
        }
    }
    public void SaveSound()
    {
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
    }
    private void OnApplicationFocus(bool InFocus)
    {
        if(!InFocus)
        {
            SaveSound();
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
    public void UpdateSound()
    {
        Backgroundmusic.volume = backgroundSlider.value;


    }

}

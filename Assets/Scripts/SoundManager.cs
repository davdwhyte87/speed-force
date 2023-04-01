using UnityEngine;
using UnityEngine.Audio;
using System;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;

    public static SoundManager instance;

    public bool isVibrating;

    void Awake(){
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        instance = this;
    }

    void Start(){
        Play("BackgroundMusic");
    }

    void Update(){
        CheckSound();
        CheckVibration();
    }

    void CheckSound(){
        if(PlayerPrefs.GetInt("Sound", 1) == 0){
            AudioListener.volume = 0f;
        }
        else{
            AudioListener.volume = 1f;
        }
    }

    void CheckVibration(){
        if(PlayerPrefs.GetInt("Vibration", 1) == 0){
            isVibrating = false;
        }
        else{
            isVibrating = true;
        }
    }

 

    public void Play(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null){
            return;
        }

        s.source.Play();
    }
}

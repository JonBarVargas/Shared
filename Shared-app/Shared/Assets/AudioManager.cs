using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using System;



public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    //singleton
    public static AudioManager instance;
    Text storyTitle;
    Text storyNarrator;

    //// Start is called before the first frame update
    //void Start()
    //{
    
    //}

    //This is for notes: this method is to start audio at boot up

    void Awake()
    {
         if (instance == null)
            instance = this;
         else
            {
            Destroy(gameObject);
             return;
             }
        
        DontDestroyOnLoad(gameObject);

        storyTitle = GameObject.Find ("Canvas/StoryTitle").GetComponent<Text>();
        storyNarrator = GameObject.Find("Canvas/StoryNarrator").GetComponent<Text>();

        foreach (Sound s in sounds)
              {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
              }
     }



    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        if (s.played)
        {
            s.source.Play();
        }
        
        showTitle(name);

    }

    public void showTitle(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        storyTitle.text = s.name;
        storyNarrator.text = s.narrator;

    }
}

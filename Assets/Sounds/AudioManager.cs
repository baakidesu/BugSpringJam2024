using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour


{

    public Sound[] sounds;
    public bool loop;
    // Start is called before the first frame update
    void Awake()
    {foreach(Sound s in sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            
        }
        
    }

     void Start()
    {
        Debug.Log("start calisti ");
        Play("Theme");
    }
    // Update is called once per frame
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Ses " + name + " bulunamadý!");
            return;
        }

        s.source.Play();
    }
}

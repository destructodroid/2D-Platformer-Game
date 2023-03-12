using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource SoundEffect;
    public AudioSource SoundMusic;
    private static SoundManager instance;
    public bool IsMute = false;
    public float Volume = 1f;
    public static SoundManager Instance
    {
        get { return instance; }
    }
    public SoundType[] sounds;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public enum Sounds
    {
        ButtonClick,
        Playermove,
        Music,
        PlayerDeath,
        EnemyDeath
    }
    [Serializable]
    public class SoundType
    {
        public Sounds soundType;
        public AudioClip soundClip;
    }
    public void PlayMusic(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            SoundMusic.clip = clip;
            SoundMusic.Play();
        }
        else
        {
            Debug.Log("Sound not found for " + sound);
        }
    }

    public void Play(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            SoundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("Sound not found for " + sound);
        }
    }
    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(sounds, item => item.soundType == sound);
        if (item!= null)
        {
            return item.soundClip;
        }
        return null;
    }
    public void Mute(bool status)
    {
        IsMute = status;
    }

    public void SetVolume(float volume)
    {
        SoundMusic.volume = volume;
    }

    private void Start()
    {
        SetVolume(0.4f);
        PlayMusic(Sounds.Music);
    }
    void Update()
    {
        
    }
}

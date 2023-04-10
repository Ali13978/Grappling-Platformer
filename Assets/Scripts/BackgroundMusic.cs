using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    #region Singleton
    public static BackgroundMusic instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] AudioClip mainMenuMusicClip;
    [SerializeField] AudioClip inGameMusicClip;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        LoadMainMenuMusicClip();
    }
    public void LoadMainMenuMusicClip()
    {
        audioSource.clip = mainMenuMusicClip;
        audioSource.Play();
    }

    public void LoadinGameMusic()
    {
        audioSource.clip = inGameMusicClip; 
        audioSource.Play();
    }

}

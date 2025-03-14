using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;

    [Header("Stats")]
    [SerializeField] AudioSource clickedPop;
    [SerializeField] AudioSource clickedButton;
    [SerializeField] AudioSource winGame;
    [SerializeField] AudioSource oops;

    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider music;
    [SerializeField] Slider sfx;

    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        music.onValueChanged.AddListener(SetMusic);
        sfx.onValueChanged.AddListener(SetSFX);

        music.value = PlayerPrefs.GetFloat(NameTag.MIXER_MUSIC, .5f);
        sfx.value = PlayerPrefs.GetFloat(NameTag.MIXER_SFX, .5f);
    }

    private void SetSFX(float arg0)
    {
        mixer.SetFloat(NameTag.MIXER_SFX, Mathf.Log10(arg0) * 20);
    }

    private void SetMusic(float arg0)
    {
        mixer.SetFloat(NameTag.MIXER_MUSIC, Mathf.Log10(arg0) * 20);
    }

    public void WinGame()
    {
        winGame.PlayOneShot(clips[2]);
    }

    public void ClickedPop()
    {
        clickedPop.PlayOneShot(clips[0]);
    }

    public void ClickedButton()
    {
        clickedButton.PlayOneShot(clips[1]);
    }

    public void Oops()
    {
        oops.PlayOneShot(clips[3]);
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat(NameTag.MIXER_MUSIC, music.value);
        PlayerPrefs.SetFloat(NameTag.MIXER_SFX, sfx.value);
    }
}

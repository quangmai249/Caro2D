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

    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider music;
    [SerializeField] Slider sfx;

    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(instance);
    }
    private void Start()
    {
        music.onValueChanged.AddListener(SetMusic);
        sfx.onValueChanged.AddListener(SetSFX);
    }

    private void SetSFX(float arg0)
    {
        mixer.SetFloat(NameTag.MIXER_SFX, Mathf.Log10(arg0) * 20);
    }

    private void SetMusic(float arg0)
    {
        mixer.SetFloat(NameTag.MIXER_MUSIC, Mathf.Log10(arg0) * 20);
    }

    public void ClickedPop()
    {
        clickedPop.PlayOneShot(clips[0]);
    }

    public void ClickedButton()
    {
        clickedButton.PlayOneShot(clips[1]);
    }
}

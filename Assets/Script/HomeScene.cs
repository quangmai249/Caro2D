using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeScene : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    [SerializeField] GameObject panelSelect;
    private void Awake()
    {
        MethodSetting.GetItem(NameTag.BTN_PLAY, this.buttons).onClick.AddListener(ButtonPlay);
        MethodSetting.GetItem(NameTag.BTN_3X3, this.buttons).onClick.AddListener(Button3x3);
        MethodSetting.GetItem(NameTag.BTN_5X5, this.buttons).onClick.AddListener(Button5x5);
        MethodSetting.GetItem(NameTag.BTN_3X3_BOT, this.buttons).onClick.AddListener(Button3x3BOT);
        MethodSetting.GetItem(NameTag.BTN_5X5_BOT, this.buttons).onClick.AddListener(Button5x5BOT);
    }
    private void Start()
    {
        panelSelect.SetActive(false);

        ButtonManager.instance.SetButtonQuitInGame(false);
        CanvasManager.instance.PanelPause(false);
        CanvasManager.instance.PanelSetting(false);
        CanvasManager.instance.PanelUser(false);

        Background.instance.SetBG(Vector3.zero, Vector3.one, 1f);
    }

    private void ButtonPlay()
    {
        AudioManager.instance.ClickedButton();
        panelSelect.SetActive(true);
    }
    public void Button3x3()
    {
        AudioManager.instance.ClickedButton();
        SceneManager.LoadScene(NameTag.GAMEPLAY3X3_SCENE);
    }
    public void Button5x5()
    {
        AudioManager.instance.ClickedButton();

        SceneManager.LoadScene(NameTag.GAMEPLAY5X5_SCENE);
    }
    public void Button3x3BOT()
    {
        AudioManager.instance.ClickedButton();
        SceneManager.LoadScene(NameTag.GAMEPLAY3X3BOT_SCENE);
    }
    public void Button5x5BOT()
    {
        AudioManager.instance.ClickedButton();
        SceneManager.LoadScene(NameTag.GAMEPLAY5X5BOT_SCENE);
    }
}

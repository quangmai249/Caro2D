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

    private void Start()
    {
        panelSelect.SetActive(false);

        buttons[0].onClick.AddListener(ButtonPlay);
        buttons[1].onClick.AddListener(Button3x3);
        buttons[2].onClick.AddListener(Button5x5);

        ButtonManager.instance.SetButtonInGame(false);
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
}

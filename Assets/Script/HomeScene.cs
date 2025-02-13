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
    void Start()
    {
        panelSelect.SetActive(false);
        buttons[0].onClick.AddListener(ButtonPlay);
        buttons[1].onClick.AddListener(Button3x3);
        buttons[2].onClick.AddListener(Button5x5);
    }

    private void ButtonPlay()
    {
        AudioManager.instance.ClickedButton();
        panelSelect.SetActive(true);
    }
    public void Button3x3()
    {
        AudioManager.instance.ClickedButton();
        SceneManager.LoadScene(NameTag.GAMEPLAY_SCENE);
    }
    public void Button5x5()
    {
        AudioManager.instance.ClickedButton();
        SceneManager.LoadScene(NameTag.GAMEPLAY_SCENE);
    }
}

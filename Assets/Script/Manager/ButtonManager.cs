using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] Button[] buttons;

    public static ButtonManager instance;
    private Button btnPause, btnResume, btnSetting, btnRestart, btnSaveSetting, btnQuit;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

        this.SetDefaultButton();
    }

    private void Start()
    {
        this.btnPause.onClick.AddListener(ButtonPause);
        this.btnResume.onClick.AddListener(ButtonResume);
        this.btnSetting.onClick.AddListener(ButtonSetting);
        this.btnRestart.onClick.AddListener(ButtonRestart);
        this.btnSaveSetting.onClick.AddListener(ButtonSaveSetting);
        this.btnQuit.onClick.AddListener(ButtonQuit);
    }

    private void SetDefaultButton()
    {
        this.btnPause = MethodSetting.GetItem(NameTag.BTN_PAUSE, this.buttons);
        this.btnResume = MethodSetting.GetItem(NameTag.BTN_RESUME, this.buttons);
        this.btnSetting = MethodSetting.GetItem(NameTag.BTN_SETTING, this.buttons);
        this.btnRestart = MethodSetting.GetItem(NameTag.BTN_RESTART, this.buttons);
        this.btnSaveSetting = MethodSetting.GetItem(NameTag.BTN_SAVE_SETTING, this.buttons);
        this.btnQuit = MethodSetting.GetItem(NameTag.BTN_QUIT, this.buttons);
    }

    private void ButtonQuit()
    {
        foreach (var temp in GameObject.FindGameObjectsWithTag(NameTag.NODE))
            NodeManager.instance.Enqueue(temp);

        this.btnPause.gameObject.SetActive(true);

        AudioManager.instance.ClickedButton();
        CanvasManager.instance.PanelPause(false);
        SceneManager.LoadScene(NameTag.HOME_SCENE);
        GameManager.instance.IsPause = false;
    }

    private void ButtonRestart()
    {
        foreach (var temp in GameObject.FindGameObjectsWithTag(NameTag.NODE))
            NodeManager.instance.Enqueue(temp);

        this.btnPause.gameObject.SetActive(true);

        AudioManager.instance.ClickedButton();
        CanvasManager.instance.PanelPause(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.instance.IsPause = false;
    }

    private void ButtonResume()
    {
        this.btnPause.gameObject.SetActive(true);
        AudioManager.instance.ClickedButton();
        CanvasManager.instance.PanelPause(false);
        GameManager.instance.IsPause = false;
    }

    private void ButtonPause()
    {
        this.btnPause.gameObject.SetActive(false);
        AudioManager.instance.ClickedButton();
        CanvasManager.instance.PanelPause(true);
        GameManager.instance.IsPause = true;
    }

    private void ButtonSetting()
    {
        AudioManager.instance.ClickedButton();
        CanvasManager.instance.PanelSetting(true);
    }

    private void ButtonSaveSetting()
    {
        AudioManager.instance.ClickedButton();
        AudioManager.instance.SaveVolume();
        CanvasManager.instance.PanelSetting(false);
    }

    public void SetButtonInGame(bool isActive)
    {
        this.btnRestart.gameObject.SetActive(isActive);
        this.btnQuit.gameObject.SetActive(isActive);
    }
}

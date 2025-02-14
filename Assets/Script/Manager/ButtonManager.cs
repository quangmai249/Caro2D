using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] Button[] buttons;

    public static ButtonManager instance;
    private Button btnPause, btnResume, btnSetting, btnRestart, btnSaveSetting;
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
        this.btnPause = buttons[0];
        this.btnResume = buttons[1];
        this.btnSetting = buttons[2];
        this.btnRestart = buttons[3];
        this.btnSaveSetting = buttons[4];

        this.btnPause.onClick.AddListener(ButtonPause);
        this.btnResume.onClick.AddListener(ButtonResume);
        this.btnSetting.onClick.AddListener(ButtonSetting);
        this.btnRestart.onClick.AddListener(ButtonRestart);
        this.btnSaveSetting.onClick.AddListener(ButtonSaveSetting);
    }

    private void ButtonRestart()
    {
        foreach (var temp in GameObject.FindGameObjectsWithTag(NameTag.NODE))
            NodeManager.instance.Enqueue(temp);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ButtonResume()
    {
        this.btnPause.gameObject.SetActive(true);
        CanvasManager.instance.PanelPause(false);
        GameManager.instance.IsPause = false;
    }

    private void ButtonPause()
    {
        this.btnPause.gameObject.SetActive(false);
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
}

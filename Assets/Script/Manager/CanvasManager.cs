using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject[] panels;
    [SerializeField] TextMeshProUGUI[] texts;

    public static CanvasManager instance;
    private GameObject panelPause, panelSetting, panelUser;
    private TextMeshProUGUI textNotify;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
        this.SetDefaultStats();
    }

    private void SetDefaultStats()
    {
        this.textNotify = MethodSetting.GetItem(NameTag.TEXT_NOTIFY, this.texts);
        this.textNotify.text = string.Empty;

        this.panelPause = MethodSetting.GetItem(NameTag.PANEL_PAUSE, this.panels);
        this.panelSetting = MethodSetting.GetItem(NameTag.PANEL_SETTING, this.panels);
        this.panelUser = MethodSetting.GetItem(NameTag.PANEL_USER, this.panels);
    }

    public void PanelPause(bool isActive)
    {
        this.panelPause.SetActive(isActive);
    }
    public void PanelSetting(bool isActive)
    {
        this.panelSetting.SetActive(isActive);
    }
    public void PanelUser(bool isActive)
    {
        this.panelUser.SetActive(isActive);
    }
    public string TextNotify
    {
        get => this.textNotify.text;
        set => this.textNotify.text = value;
    }
}

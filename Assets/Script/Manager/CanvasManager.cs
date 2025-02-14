using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject[] panels;
    public static CanvasManager instance;
    private GameObject panelPause, panelSetting;
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
        this.panelPause = panels[0];
        this.panelSetting = panels[1];
    }
    public void PanelPause(bool isActive)
    {
        this.panelPause.SetActive(isActive);
    }
    public void PanelSetting(bool isActive)
    {
        this.panelSetting.SetActive(isActive);
    }
}

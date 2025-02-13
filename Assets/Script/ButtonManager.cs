using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] Button[] buttons;

    public static ButtonManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        buttons[0].onClick.AddListener(ButtonSetting);
        buttons[1].onClick.AddListener(ButtonSaveSetting);
    }

    private void ButtonSetting()
    {
        AudioManager.instance.ClickedButton();
        buttons[0].gameObject.SetActive(!buttons[0].gameObject.activeSelf);
        GameObject.FindGameObjectWithTag(NameTag.CANVAS_MANAGER).GetComponent<CanvasManager>().GetPanel(0).SetActive(true);
    }

    private void ButtonSaveSetting()
    {
        AudioManager.instance.ClickedButton();
        buttons[0].gameObject.SetActive(!buttons[0].gameObject.activeSelf);
        GameObject.FindGameObjectWithTag(NameTag.CANVAS_MANAGER).GetComponent<CanvasManager>().GetPanel(0).SetActive(false);
    }
}

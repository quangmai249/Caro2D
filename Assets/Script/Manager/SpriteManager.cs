using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteManager : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] GameObject[] images;

    public static SpriteManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    public void SetSpriteTurnUser(int turn)
    {
        if (turn == 0)
        {
            MethodSetting.GetItem(NameTag.O_USER_IMG, this.images).GetComponent<Image>().color = Color.blue;
            MethodSetting.GetItem(NameTag.X_USER_IMG, this.images).GetComponent<Image>().color = Color.clear;
        }
        else
        {
            MethodSetting.GetItem(NameTag.X_USER_IMG, this.images).GetComponent<Image>().color = Color.red;
            MethodSetting.GetItem(NameTag.O_USER_IMG, this.images).GetComponent<Image>().color = Color.clear;
        }
    }

    public Sprite GetSpriteLetterByName(string name)
    {
        return MethodSetting.GetItem(name, this.sprites);
    }

    public Sprite GetSpriteLetterByStatus(int status)
    {
        return status == 0
            ? MethodSetting.GetItem(NameTag.O_LETTER_SPRITE, this.sprites)
            : MethodSetting.GetItem(NameTag.X_LETTER_SPRITE, this.sprites);
    }
}

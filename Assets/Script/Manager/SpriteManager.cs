using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;

    public static SpriteManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
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

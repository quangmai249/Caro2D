using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public static Background instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    public void SetBG(Vector3 pos, Vector3 scale, float timeDelay)
    {
        DOTween.KillAll();
        Background.instance.transform.position = pos;
        Background.instance.transform.DOScale(scale, timeDelay);
    }
}
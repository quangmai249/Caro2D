using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private int status = -1;
    private void OnMouseDown()
    {
        if (GameManager.instance.IsPause)
            return;

        if (this.status != -1)
        {
            AudioManager.instance.Oops();
            return;
        }

        this.SetNode();
        this.CheckIsWinGame();
    }

    private void SetNode()
    {
        this.status = GameObject.FindGameObjectWithTag(NameTag.GAMEPLAY).GetComponent<GamePlayScene>().Turn;

        this.GetComponent<SpriteRenderer>().sprite = SpriteManager.instance.GetSpriteLetterByStatus(this.status);

        GameObject.FindGameObjectWithTag(NameTag.GAMEPLAY).GetComponent<GamePlayScene>().Turn = this.status == 0 ? 1 : 0;

        AudioManager.instance.ClickedPop();
        GamePlay.moveCount++;
    }

    private void CheckIsWinGame()
    {
        if (GamePlay.IsDraw())
            Debug.Log("Draw!");
    }

    public int Status
    {
        get => this.status;
        set => this.status = value;
    }
}

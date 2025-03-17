using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private int status = -1;
    private GamePlayScene gamePlayScene;
    private void Start()
    {
        gamePlayScene = GameObject.FindGameObjectWithTag(NameTag.GAMEPLAY).GetComponent<GamePlayScene>();
    }
    private void OnMouseDown()
    {
        if (GameManager.instance.IsPause || GameManager.instance.IsWin)
            return;

        if (this.status != -1)
        {
            AudioManager.instance.Oops();
            return;
        }

        if (!gamePlayScene.IsBOT)
        {
            gamePlayScene.LsNode.Add(this.gameObject);
            this.SetNode();
            this.CheckIsWinGame();
            return;
        }
    }

    private void SetNode()
    {
        this.status = GameObject.FindGameObjectWithTag(NameTag.GAMEPLAY).GetComponent<GamePlayScene>().Turn;

        this.GetComponent<SpriteRenderer>().sprite = SpriteManager.instance.GetSpriteLetterByStatus(this.status);

        AudioManager.instance.ClickedPop();

        GamePlay.moveCount++;
    }

    private void CheckIsWinGame()
    {
        if (GamePlay.IsWin(this.gameObject, gamePlayScene.LsNode))
        {
            GameManager.instance.IsWin = true;
            ButtonManager.instance.SetButtonRestartInGame(true);
            CanvasManager.instance.TextNotify = this.status == 0 ? "O win game!" : "X win game!";

            GameObject.FindGameObjectWithTag(NameTag.GAMEPLAY).GetComponent<GamePlayScene>().SetLineWinGame(GamePlay.LsNodeWin);

            foreach (GameObject item in GameObject.FindGameObjectsWithTag(NameTag.NODE))
                if (item.GetComponent<Node>().Status == -1)
                    item.gameObject.transform.localScale = item.gameObject.transform.localScale * 0.5f;

            return;
        }

        if (GamePlay.IsDraw(GameObject.FindGameObjectWithTag(NameTag.GAMEPLAY).GetComponent<GamePlayScene>().NumNode))
        {
            CanvasManager.instance.TextNotify = "Draw!";
            return;
        }

        GameObject.FindGameObjectWithTag(NameTag.GAMEPLAY).GetComponent<GamePlayScene>().Turn = this.status == 0 ? 1 : 0;
    }

    public int Status
    {
        get => this.status;
        set => this.status = value;
    }
}

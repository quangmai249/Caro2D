using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayScene : MonoBehaviour
{
    [SerializeField] int numNode = 3;
    [SerializeField] int turn = 0;
    private GameObject node;
    private void Awake()
    {
        GamePlay.moveCount = 0;
        this.turn = Random.Range(0, 2);
    }
    private void Start()
    {
        ButtonManager.instance.SetButtonInGame(true);

        for (int i = 0; i < numNode; i++)
        {
            for (int j = 0; j < numNode; j++)
            {
                node = NodeManager.instance.Dequeue();
                node.transform.position = new Vector3(i, j, 0) * GameManager.instance.Distance;
                node.gameObject.SetActive(true);
            }
        }

        GameObject.FindGameObjectWithTag(NameTag.MAIN_CAMERA).transform.position
            = new Vector3(CenterValue, CenterValue, GameObject.FindGameObjectWithTag(NameTag.MAIN_CAMERA).transform.position.z);

        CanvasManager.instance.PanelUser(true);

        SpriteManager.instance.SetSpriteTurnUser(this.turn);
        CanvasManager.instance.TextNotify = this.turn == 0 ? "O move first" : "X move first";
    }

    public int Turn
    {
        get => this.turn;
        set
        {
            this.turn = value;
            SpriteManager.instance.SetSpriteTurnUser(value);
            CanvasManager.instance.TextNotify = this.turn == 0 ? "O turn" : "X turn";
        }
    }

    private float CenterValue
    {
        get => ((numNode - 1) * GameManager.instance.Distance) / 2;
    }

    public int NumNode
    {
        get => this.numNode;
    }
}

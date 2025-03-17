using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GamePlayScene : MonoBehaviour
{
    [SerializeField] int numNode = 3;
    [SerializeField] int numNodeWin = 3;
    [SerializeField] int turn = 0;

    [SerializeField] bool isBOT = false;
    [SerializeField] List<GameObject> lsNode;
    private GameObject node;
    private void Awake()
    {
        GamePlay.moveCount = 0;
        GamePlay.numNodeWin = this.numNodeWin;
        GameManager.instance.IsWin = false;

        if (GameManager.instance.Line == null)
            GameManager.instance.Line = Instantiate(GameManager.instance.LineRenderer);
        GameManager.instance.Line.positionCount = 0;

        this.turn = Random.Range(0, 2);
        Background.instance.SetBG(new Vector3(numNode / 2, numNode / 2, 0) * GameManager.instance.Distance, new Vector3(numNode, numNode, 0), this.numNodeWin);

        string notification = GameObject.FindGameObjectWithTag(NameTag.GAMEPLAY).GetComponent<GamePlayScene>().IsBOT
            == false ? "This is not game using bot" : "This is game using bot";

        Debug.Log(notification);
    }
    private void Start()
    {
        ButtonManager.instance.SetButtonQuitInGame(true);
        ButtonManager.instance.SetButtonRestartInGame(false);

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

    public void SetLineWinGame(List<GameObject> ls)
    {
        GameManager.instance.Line.positionCount = 2;
        GameManager.instance.Line.SetPosition(0, this.GetFirstNodeToDrawLine(ls).transform.position);
        GameManager.instance.Line.SetPosition(1, this.GetSecondNodeToDrawLine(ls).transform.position);
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

    private GameObject GetSecondNodeToDrawLine(List<GameObject> ls)
    {
        GameObject res;

        //vertical
        if (ls[0].transform.position.x == ls[1].transform.position.x)
        {
            res = ls[0];

            foreach (GameObject item in ls)
            {
                if (res.transform.position.y > item.transform.position.y)
                    res = item;
            }

            return res;
        }

        //horizontal
        res = ls[0];
        foreach (GameObject item in ls)
        {
            if (res.transform.position.x > item.transform.position.x)
                res = item;
        }
        return res;
    }

    private GameObject GetFirstNodeToDrawLine(List<GameObject> ls)
    {
        GameObject res;

        //vertical
        if (ls[0].transform.position.x == ls[1].transform.position.x)
        {
            res = ls[0];

            foreach (GameObject item in ls)
            {
                if (res.transform.position.y < item.transform.position.y)
                    res = item;
            }

            return res;
        }

        //horizontal
        res = ls[0];
        foreach (GameObject item in ls)
        {
            if (res.transform.position.x < item.transform.position.x)
                res = item;
        }
        return res;
    }

    private float CenterValue
    {
        get => ((numNode - 1) * GameManager.instance.Distance) / 2;
    }

    public bool IsBOT
    {
        get => this.isBOT;
        set => this.isBOT = value;
    }

    public int NumNode
    {
        get => this.numNode;
        set => this.numNode = value;
    }

    public int NumNodeWin
    {
        get => this.numNodeWin;
        set => this.numNodeWin = value;
    }

    public List<GameObject> LsNode
    {
        get => this.lsNode;
        set => this.lsNode = value;
    }
}

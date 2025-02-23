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

        turn = Random.Range(0, 2);
        Debug.Log(turn);
    }
    private void Start()
    {
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
    }

    public int Turn
    {
        get => this.turn;
        set => this.turn = value;
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

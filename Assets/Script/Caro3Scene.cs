using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caro3Scene : MonoBehaviour
{
    private int numNode = 3;
    private GameObject node;
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

    private void Update()
    {

    }

    private float CenterValue
    {
        get => ((numNode - 1) * GameManager.instance.Distance) / 2;
    }
}

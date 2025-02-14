using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (GameManager.instance.IsPause)
            return;

        AudioManager.instance.ClickedPop();
        GamePlay.moveCount++;
        NodeManager.instance.Enqueue(this.gameObject);
    }
    private void OnDisable()
    {
    }
}

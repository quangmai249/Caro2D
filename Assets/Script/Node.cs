using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private void OnMouseDown()
    {
        AudioManager.instance.ClickedPop();
    }
}

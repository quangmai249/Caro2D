using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePlay
{
    public static int moveCount = 0;
    public static bool IsDraw(int numNode)
    {
        return moveCount >= numNode * numNode;
    }
}

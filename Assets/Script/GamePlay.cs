using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePlay
{
    public static int moveCount;
    public static int numNodeWin;
    public static bool IsDraw()
    {
        return moveCount >= Mathf.Pow(GameObject.FindGameObjectWithTag(NameTag.GAMEPLAY).GetComponent<GamePlayScene>().NumNode, 2);
    }

    public static bool CheckWin(int x, int y, int player)
    {
        return CheckDirection(x, y, player, 1, 0) ||  // Horizontal
               CheckDirection(x, y, player, 0, 1) ||  // Vertical
               CheckDirection(x, y, player, 1, 1) ||  // Diagonal (\)
               CheckDirection(x, y, player, 1, -1);   // Diagonal (/)
    }

    private static bool CheckDirection(int x, int y, int player, int dx, int dy)
    {
        int count = 1;

        // Check forward direction
        count += CountInDirection(x, y, player, dx, dy);
        // Check backward direction
        count += CountInDirection(x, y, player, -dx, -dy);

        return count >= 5;
    }

    private static int CountInDirection(int x, int y, int player, int dx, int dy)
    {
        int count = 0;
        int i = 1;

        int[,] board = new int[
        GameObject.FindGameObjectWithTag(NameTag.GAMEPLAY).GetComponent<GamePlayScene>().NumNode,
        GameObject.FindGameObjectWithTag(NameTag.GAMEPLAY).GetComponent<GamePlayScene>().NumNode];

        while (true)
        {
            int nx = x + i * dx;
            int ny = y + i * dy;

            if (nx < 0 ||
                ny < 0 ||
                nx >= GameObject.FindGameObjectWithTag(NameTag.GAMEPLAY).GetComponent<GamePlayScene>().NumNode ||
                ny >= GameObject.FindGameObjectWithTag(NameTag.GAMEPLAY).GetComponent<GamePlayScene>().NumNode ||
                board[nx, ny] != player)
            {
                break;
            }

            count++;
            i++;
        }
        return count;
    }
}

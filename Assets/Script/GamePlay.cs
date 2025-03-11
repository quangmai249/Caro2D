using System;
using System.Collections.Generic;
using UnityEngine;

public static class GamePlay
{
    public static int moveCount;
    public static int numNodeWin;
    private static List<GameObject> lsNodeWin;
    public static bool IsDraw(int numNode)
    {
        return moveCount >= Mathf.Pow(numNode, 2);
    }

    public static bool IsWin(GameObject go, List<GameObject> lsNode)
    {
        if (CheckHorizontal(go, lsNode) || CheckVertical(go, lsNode) || CheckDiagonal_I_III(go, lsNode) || CheckDiagonal_II_IV(go, lsNode))
            return true;

        return false;
    }

    public static bool IsNullGO(Vector2 vec, float d)
    {
        return false;
    }

    public static Collider2D IsgRayCastHit2DFrom(Vector2 origin, int n)
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(new Vector2(origin.x + GameManager.instance.Distance * n, origin.y), origin);

        if (hit.collider == null)
            return null;

        return hit.collider;
    }

    public static List<GameObject> LsNodeWin
    {
        get => lsNodeWin;
    }

    private static bool CheckDiagonal_I_III(GameObject go, List<GameObject> lsNode)
    {
        int count = 0;
        bool check = false;
        lsNodeWin = new List<GameObject>();

        //x > 0 and y > 0
        for (int i = 0; i < numNodeWin; i++)
        {
            foreach (GameObject item in lsNode)
            {
                if (go.transform.position + new Vector3(i * GameManager.instance.Distance, i * GameManager.instance.Distance, 0) == item.transform.position)
                {
                    if (go.GetComponent<Node>().Status == item.GetComponent<Node>().Status)
                    {
                        count++;
                        check = true;
                        lsNodeWin.Add(item);
                    }
                    break;
                }
            }

            if (check == false)
                break;

            check = false;
        }

        //x < 0 and y < 0
        for (int i = 1; i < numNodeWin; i++)
        {
            foreach (GameObject item in lsNode)
            {
                if (go.transform.position + new Vector3(-i * GameManager.instance.Distance, -i * GameManager.instance.Distance, 0) == item.transform.position)
                {
                    if (go.GetComponent<Node>().Status == item.GetComponent<Node>().Status)
                    {
                        count++;
                        check = true;
                        lsNodeWin.Add(item);
                    }
                    break;
                }
            }

            if (check == false)
                break;

            check = false;
        }

        //Debug.Log(go.GetComponent<Node>().Status + " - diagonal I and III - count is " + count + " at " + DateTime.Now);

        if (count >= numNodeWin)
            return true;

        return false;
    }

    private static bool CheckDiagonal_II_IV(GameObject go, List<GameObject> lsNode)
    {
        int count = 0;
        bool check = false;
        lsNodeWin = new List<GameObject>();

        //x < 0 and y > 0
        for (int i = 0; i < numNodeWin; i++)
        {
            foreach (GameObject item in lsNode)
            {
                if (go.transform.position + new Vector3(-i * GameManager.instance.Distance, i * GameManager.instance.Distance, 0) == item.transform.position)
                {
                    if (go.GetComponent<Node>().Status == item.GetComponent<Node>().Status)
                    {
                        count++;
                        check = true;
                        lsNodeWin.Add(item);
                    }
                    break;
                }
            }

            if (check == false)
                break;

            check = false;
        }

        //x > 0 and y < 0
        for (int i = 1; i < numNodeWin; i++)
        {
            foreach (GameObject item in lsNode)
            {
                if (go.transform.position + new Vector3(i * GameManager.instance.Distance, -i * GameManager.instance.Distance, 0) == item.transform.position)
                {
                    if (go.GetComponent<Node>().Status == item.GetComponent<Node>().Status)
                    {
                        count++;
                        check = true;
                        lsNodeWin.Add(item);
                    }
                    break;
                }
            }

            if (check == false)
                break;

            check = false;
        }

        //Debug.Log(go.GetComponent<Node>().Status + " - diagonal II and IV - count is " + count + " at " + DateTime.Now);

        if (count >= numNodeWin)
            return true;

        return false;
    }

    private static bool CheckVertical(GameObject go, List<GameObject> lsNode)
    {
        int count = 0;
        bool check = false;
        lsNodeWin = new List<GameObject>();

        //up side
        for (int i = 0; i < numNodeWin; i++)
        {
            foreach (GameObject item in lsNode)
            {
                if (go.transform.position + new Vector3(0, i * GameManager.instance.Distance, 0) == item.transform.position)
                {
                    if (go.GetComponent<Node>().Status == item.GetComponent<Node>().Status)
                    {
                        count++;
                        check = true;
                        lsNodeWin.Add(item);
                    }
                    break;
                }
            }

            if (check == false)
                break;

            check = false;
        }

        //down side
        for (int i = 1; i < numNodeWin; i++)
        {
            foreach (GameObject item in lsNode)
            {
                if (go.transform.position + new Vector3(0, -i * GameManager.instance.Distance, 0) == item.transform.position)
                {
                    if (go.GetComponent<Node>().Status == item.GetComponent<Node>().Status)
                    {
                        count++;
                        check = true;
                        lsNodeWin.Add(item);
                    }
                    break;
                }
            }

            if (check == false)
                break;

            check = false;
        }

        //Debug.Log(go.GetComponent<Node>().Status + " - vertical - count is " + count + " at " + DateTime.Now);

        if (count >= numNodeWin)
            return true;

        return false;
    }

    private static bool CheckHorizontal(GameObject go, List<GameObject> lsNode)
    {
        int count = 0;
        bool check = false;
        lsNodeWin = new List<GameObject>();

        //right side
        for (int i = 0; i < numNodeWin; i++)
        {
            foreach (GameObject item in lsNode)
            {
                if (go.transform.position + new Vector3(i * GameManager.instance.Distance, 0, 0) == item.transform.position)
                {
                    if (go.GetComponent<Node>().Status == item.GetComponent<Node>().Status)
                    {
                        count++;
                        check = true;
                        lsNodeWin.Add(item);
                    }
                    break;
                }
            }

            if (check == false)
                break;

            check = false;
        }

        //left side
        for (int i = 1; i < numNodeWin; i++)
        {
            foreach (GameObject item in lsNode)
            {
                if (go.transform.position + new Vector3(-i * GameManager.instance.Distance, 0, 0) == item.transform.position)
                {
                    if (go.GetComponent<Node>().Status == item.GetComponent<Node>().Status)
                    {
                        count++;
                        check = true;
                        lsNodeWin.Add(item);
                    }
                    break;
                }
            }

            if (check == false)
                break;

            check = false;
        }

        //Debug.Log(go.GetComponent<Node>().Status + " - horizontal - count is " + count + " at " + DateTime.Now);

        if (count >= numNodeWin)
            return true;

        return false;
    }
}

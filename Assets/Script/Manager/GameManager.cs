using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int row;
    [SerializeField] float distance;

    [SerializeField] bool isPause;
    [SerializeField] bool isWin;

    [SerializeField] LineRenderer lineRenderer;

    public static GameManager instance;
    private LineRenderer line;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

        isPause = false;
    }

    public bool IsPause
    {
        get => this.isPause;
        set => this.isPause = value;
    }

    public bool IsWin
    {
        get => this.isWin;
        set => this.isWin = value;
    }

    public int Row
    {
        get => this.row;
        set => this.row = value;
    }

    public float Distance
    {
        get => this.distance;
    }

    public LineRenderer Line
    {
        get => this.line;
        set => this.line = value;
    }

    public LineRenderer LineRenderer
    {
        get => this.lineRenderer;
    }
}

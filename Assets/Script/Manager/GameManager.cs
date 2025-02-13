using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int row;
    [SerializeField] int numWinGame;
    [SerializeField] float distance;

    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(instance);
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
}

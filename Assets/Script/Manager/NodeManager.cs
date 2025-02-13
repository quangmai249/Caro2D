using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    [SerializeField] GameObject _node;

    private Queue<GameObject> queue = new Queue<GameObject>();
    public static NodeManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        GameObject go;
        for (int i = 0; i < GameManager.instance.Row; i++)
        {
            for (int j = 0; j < GameManager.instance.Row; j++)
            {
                go = Instantiate(_node);
                go.transform.parent = transform;
                go.SetActive(false);
                queue.Enqueue(go);
            }
        }
    }

    public GameObject Dequeue()
    {
        return queue.Dequeue();
    }
}

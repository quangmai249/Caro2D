using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    [SerializeField] GameObject _node;

    private GameObject go;
    private Queue<GameObject> queue = new Queue<GameObject>();
    public static NodeManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        for (int i = 0; i < GameManager.instance.Row; i++)
            for (int j = 0; j < GameManager.instance.Row; j++)
                queue.Enqueue(this.CreateNode());
    }

    public GameObject CreateNode()
    {
        go = Instantiate(_node);
        go.transform.parent = transform;
        go.SetActive(false);
        return go;
    }

    public void Enqueue(GameObject go)
    {
        if (go.activeSelf)
            go.SetActive(false);
        queue.Enqueue(go);
    }

    public GameObject Dequeue()
    {
        if (queue.Count == 0)
            queue.Enqueue(this.CreateNode());

        return queue.Dequeue();
    }

    public int CountQueue
    {
        get { return queue.Count; }
    }
}

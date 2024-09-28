using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    private readonly Func<GameObject> _preloadFunc;
    private readonly Queue<GameObject> _pool = new();

    public Pool(Func<GameObject> preloadFunc, int preloadNumber)
    {
        _preloadFunc = preloadFunc;

        for (int i = 0; i < preloadNumber; i++)
        {
            Return(preloadFunc());
        }
    }

    public GameObject Get()
    {
        GameObject item = _pool.Count > 0 ? _pool.Dequeue() : _preloadFunc();
        item.SetActive(true);

        return item;
    }

    public void Return(GameObject item)
    {
        item.SetActive(false);
        _pool.Enqueue(item);
    }

}

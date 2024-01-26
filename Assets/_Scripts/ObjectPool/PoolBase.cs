using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolBase<T>
{
    private readonly Func<T> _preloadFunc;
    private readonly Action<T> _getAction;
    private readonly Action<T> _returnAction;

    private Queue<T> _pool;

    public PoolBase(Func<T> preloadFunc, Action<T> getAction, Action<T> returnAction, int preloadCount)
    {
        _preloadFunc = preloadFunc;
        _getAction = getAction;
        _returnAction = returnAction;

        _pool = new Queue<T>();

        if (preloadFunc == null)
        {
            Debug.LogError("Preload function is null");
            return;
        }

        RebootObjects(preloadFunc, preloadCount);
    }

    public T Get()
    {
        T item = _pool.Count > 0 ? _pool.Dequeue() : _preloadFunc();
        _getAction(item);

        return item;
    }

    public void Return(T item)
    {
        _returnAction(item);
        _pool.Enqueue(item);
    }

    protected void RebootObjects(Func<T> preloadFunc, int preloadCount)
    {
        for (int i = 0; i < preloadCount; i++)
        {
            Return(preloadFunc());
        }
    }
}
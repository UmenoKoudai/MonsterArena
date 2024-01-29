using System;
using System.Collections;
using System.Collections.Generic;

public class PriorityQueue<TKey, TValue> where TValue : IComparable<TValue>
{
    private readonly List<TKey> _list;
    private readonly TValue _priority;

    public void Enqueue(TKey queue, TValue value)
    {

    }

    public TKey Dequeue()
    {
        TKey key = _list[0];
        _list.RemoveAt(0);
        return key;
    }

    //public static bool operator >(int a, int b)
    //{
    //    return a.CompareTo(b) > 0;
    //}

    //public static bool operator <(int a, int b)
    //{
    //    return a.CompareTo(b) < 0;
    //}
}

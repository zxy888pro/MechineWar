using UnityEngine;
using System.Collections;

public class Runnable
{
    public int priority = 0;
    public virtual IEnumerator OnExcute()
    {
        yield break;
    }

    public static bool Compare(HeapNode<Runnable> A, HeapNode<Runnable> B)
    {
        return A.Value.priority > A.Value.priority;
    }
}


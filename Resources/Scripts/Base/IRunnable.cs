using UnityEngine;
using System.Collections;

public class IRunnable
{
    public int priority = 0;
    public virtual IEnumerator OnExcute()
    {
        yield break;
    }

    public static bool Compare(HeapNode<IRunnable> A, HeapNode<IRunnable> B)
    {
        return A.Value.priority > A.Value.priority;
    }
}


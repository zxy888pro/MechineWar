using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 协程池
/// 必须依赖一个Monobehavior对象
/// </summary>
public class CoroutinePoolExecutor
{
    //核心协程数量
    public int corePoolSize = 1;
    //最大协程数量
    public int maxPoolSize = 1;
    //非核心协程在销毁前等待新任务的时间(如果allowCoreCoroutineTimeOut=true，对核心协程也一样)
    public float keepAliveTime = 1.0f;
    //核心协程是否会在没有新的任务时销毁，默认核心协程会一直在运行
    public bool allowCoreCoroutineTimeOut = false;
    //协程执行的宿主，需要独享(不再执行其他的协程任务），因为ShutDown的时候会关闭上面所以执行的协程
    public MonoBehaviour attachedMono;

    private PriorityQueue<IRunnable> m_AsyncOperationQueue;
    private int m_StartedCoroutineCount;    //  默认启动的数量
    private int m_IdleCoroutineCount;
    private WaitForSeconds m_WaitForNewTask;
    private Dictionary<int, IEnumerator> m_StartedCoroutines; //hashcode-coroutine
    private int m_LastCoroutineKey;

    private const float CheckNewTaskInterval = 0.1f;

    public CoroutinePoolExecutor(MonoBehaviour attachedMono)
    {
        this.attachedMono = attachedMono;
        m_AsyncOperationQueue = new PriorityQueue<IRunnable>(IRunnable.Compare);
        m_StartedCoroutineCount = 0;
        m_IdleCoroutineCount = 0;
        m_StartedCoroutines = new Dictionary<int, IEnumerator>();
        m_WaitForNewTask = new WaitForSeconds(CheckNewTaskInterval);
    }

    //预先启动一个核心协程
    public void PrestartCoreCoroutine()
    {
        if (m_StartedCoroutineCount == 0)
        {
            StartNewCoroutine(true);
        }
    }

    //预先启动所有的核心协程
    public void PrestartAllCoreCoroutines()
    {
        if (m_StartedCoroutineCount == 0)
        {
            for (int i = 0; i < corePoolSize; i++)
            {
                StartNewCoroutine(true);
            }
        }
    }

    //加入新的异步操作任务
    public void ExcuteOperation(IRunnable runnable)
    {
        m_AsyncOperationQueue.Enqueue(runnable);
        if (m_IdleCoroutineCount < m_AsyncOperationQueue.Count && m_StartedCoroutineCount < maxPoolSize)
        {
            StartNewCoroutine(m_StartedCoroutineCount < corePoolSize);
        }
    }

    //移除异步操作任务，只有未开始执行的任务才能被移除
    public void RemoveAsyncOperation(IRunnable runnable)
    {
        m_AsyncOperationQueue.Remove(runnable);
    }

    //关闭所有的协程
    public void ShutDown()
    {
        foreach (var item in m_StartedCoroutines)
        {
            attachedMono.StopCoroutine(item.Value);
        }
        m_StartedCoroutines.Clear();
    }

    //开启一个新协程
    private void StartNewCoroutine(bool coreCoroutine)
    {
        //创建一个任务
        IEnumerator coroutine = ExecuteTasks(coreCoroutine);
        m_LastCoroutineKey = coroutine.GetHashCode();
        m_StartedCoroutines.Add(m_LastCoroutineKey, coroutine);
        attachedMono.StartCoroutine(coroutine);
    }

    private IEnumerator ExecuteTasks(bool coreCoroutine)
    {
        //Debug.Log("CoroutinePool:Start a new coroutine. Core:" + coreCoroutine);
        m_StartedCoroutineCount++;
        int key = m_LastCoroutineKey;
        float startTime = Time.time;
        IRunnable tmpAsyncRunnable;

        float lastExcuteTaskTime = 0;
        bool idle = false;
        do
        {
            if (m_AsyncOperationQueue.Count > 0)
            {
                if (idle)
                {
                    m_IdleCoroutineCount--;
                    idle = false;
                }
                tmpAsyncRunnable = m_AsyncOperationQueue.Dequeue();
                yield return tmpAsyncRunnable.OnExcute();  //直接调用IRunnable的协程函数
                lastExcuteTaskTime = Time.time;
                yield return null;
            }
            else
            {
                if (!idle)
                {
                    idle = true;
                    m_IdleCoroutineCount++;
                }
                yield return m_WaitForNewTask;
            }
        } while ((coreCoroutine && !allowCoreCoroutineTimeOut) || Time.time - lastExcuteTaskTime <= keepAliveTime);

        //Debug.Log("coroutine stoped..core:" + coreCoroutine);
        //只有闲置才可能退出
        m_IdleCoroutineCount--;
        m_StartedCoroutineCount--;
        m_StartedCoroutines.Remove(key);
    }
     
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public enum MessageID
{
    UIMessage_UpadateProgress
}

public class Message
{
    public MessageID msgID;
    public object Sender;
    public object Param;
}

public class MessageHandlerCollection
{
    private List<MessageHandler> m_handlerList;
    public int count { get { return m_handlerList.Count; } }

    public MessageHandlerCollection()
    {
        m_handlerList = new List<MessageHandler>();
    }

    public void AddHandler(MessageHandler handler)
    {
        if (m_handlerList.Contains(handler))
        {
            m_handlerList.Add(handler);
        }
    }

    public void RemoveHandler(MessageHandler handler)
    {
        m_handlerList.Remove(handler);
    }

    public void DispatchMessage(object sender, object param)
    {
        for (int i = 0, count = this.m_handlerList.Count; i < count; i++)
        {
            this.m_handlerList[i].Invoke(sender, param);
        }
    }

    public void Dispose()
    {
        m_handlerList.Clear();
        m_handlerList = null;
    }

}

public delegate void MessageHandler(object pSender, object pParam);

public class MessageDispatcher : IGameSystem
{

    static readonly object mutex = new object();


    protected Dictionary<MessageID, MessageHandlerCollection> m_handlerDict;
    protected Queue<Message> m_messageQueue;

    public override void Initialize()
    {
        base.Initialize();
        m_handlerDict = new Dictionary<MessageID, MessageHandlerCollection>();
        m_messageQueue = new Queue<Message>();
    }

    public override void Release()
    {
        base.Release();
        m_messageQueue.Clear();
        m_messageQueue = null;

        foreach (var v in m_handlerDict)
        {
            v.Value.Dispose();
        }
        m_handlerDict.Clear();
        m_handlerDict = null;

    }

    public override void Update()
    {
        base.Update();

        if (m_messageQueue == null || m_messageQueue.Count == 0)
            return;
        lock(mutex)
        {
            var msg = m_messageQueue.Dequeue();
            m_handlerDict[msg.msgID].DispatchMessage(msg.Sender, msg.Param);
        }
        
    }

    public void AddHandler(MessageID msgId, MessageHandler handler)
    {
        if (handler == null)
            return;

        if (m_handlerDict.ContainsKey(msgId))
        {
            m_handlerDict[msgId].AddHandler(handler);
        }
        else
        {
            MessageHandlerCollection mhc = new MessageHandlerCollection();
            mhc.AddHandler(handler);
            m_handlerDict.Add(msgId, mhc);
        }
    }

    public void RemoveHandler(MessageID msgId, MessageHandler handler)
    {
        if (handler == null)
            return;
        if (m_handlerDict.ContainsKey(msgId))
        {
            m_handlerDict[msgId].RemoveHandler(handler);
            if (m_handlerDict[msgId].count == 0)
            {
                m_handlerDict.Remove(msgId);
            }
        }

    }

    public void DispatchMessage(MessageID msgId, object sender, object param)
    {
        lock(mutex)
        {
            if (!m_handlerDict.ContainsKey(msgId))
                return;
            Message msg = new Message();
            msg.Param = param;
            msg.Sender = sender;
            msg.msgID = msgId;

            m_messageQueue.Enqueue(msg);
        }
        
    }


}

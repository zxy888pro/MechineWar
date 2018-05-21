using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class GameEvtArg : EventArgs
{
    byte[] m_data = null;

    public DataBuffer databuf
    {
        get { return new DataBuffer(m_data); }
    }

    public GameEvtArg()
        : base()
    {

    }
    public GameEvtArg(byte[] data)
    {
        m_data = data;
    }

    public GameEvtArg(DataBuffer buf)
        : base()
    {
        if (buf != null)
        {
            m_data = buf.Array;
        }
    }

}

public delegate void GameEventHandler(object sender, EventArgs arg);

public class GameEventContext
{

    Dictionary<GameEventType, GameEventHandler> m_handlerDict;

    public GameEventContext()
    {
        m_handlerDict = new Dictionary<GameEventType, GameEventHandler>();
    }

    public void FireEvent(object sender, GameEventType type, EventArgs arg)
    {
        if (GameEventManager.instance.EventReceivers == null)
            return;
        if (GameEventManager.instance.EventReceivers.ContainsKey(type))
        {
            HashSet<GameEventContext> set = GameEventManager.instance.EventReceivers[type];
            foreach (GameEventContext context in set)
            {
                if (context != null)
                {
                    context.OnEvent(sender, type, arg);
                }
            }
        }

    }

    public void Bind(GameEventType type, GameEventHandler handler)
    {
        if (m_handlerDict.ContainsKey(type) && m_handlerDict[type] != null)
        {
            m_handlerDict[type] += handler;
        }
        else
        {
            m_handlerDict[type] = handler;
        }

    }

    public void UnBind(GameEventType type, GameEventHandler handler)
    {
        if (m_handlerDict.ContainsKey(type) && m_handlerDict[type] != null)
        {
            m_handlerDict[type] -= handler;
        }


    }

    public void OnEvent(object sender, GameEventType type, EventArgs arg)
    {
        if (m_handlerDict.ContainsKey(type) && m_handlerDict[type] != null)
        {
            m_handlerDict[type](sender, arg);
        }
    }


}


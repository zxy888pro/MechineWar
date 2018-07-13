using UnityEngine;
using System.Collections;
using System;

public class IGameSystem
{
    protected GameEventContext mEvtCtx;

    public IGameSystem()
    {
        mEvtCtx = new GameEventContext();
    }

    public void NotifyEvent(object sender, GameEventType type, GameEvtArg arg)
    {
        mEvtCtx.FireEvent(sender, type, arg);
    }

    public virtual void Initialize() { }
    public virtual void Update() { }
    public virtual void Release() { }

}
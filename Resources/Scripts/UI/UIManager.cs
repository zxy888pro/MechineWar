using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System;

public class UIManager : IGameSystem
{


    public override void Initialize()
    {
        base.Initialize();
        GlobalClient.Instance.eventManager.AddEventReceiver(GameEventType.GameEventType_HideWindow, mEvtCtx, OnHideWindow);
        GlobalClient.Instance.eventManager.AddEventReceiver(GameEventType.GameEventType_HideWindow, mEvtCtx, OnShowWindow);
    }

    void OnHideWindow(object sender, EventArgs arg)
    {

    }

    void OnShowWindow(object sender, EventArgs arg)
    {

    }

    public override void Release()
    {
        base.Release();
        GlobalClient.Instance.eventManager.RemoveEventReceiver(GameEventType.GameEventType_HideWindow, mEvtCtx, OnHideWindow);
        GlobalClient.Instance.eventManager.RemoveEventReceiver(GameEventType.GameEventType_HideWindow, mEvtCtx, OnShowWindow);
    }

    public override void Update()
    {
        base.Update();
    }

    public void RegisterWindow()
    {

    }

    public void UnRegisterWindow()
    {

    }
     
}

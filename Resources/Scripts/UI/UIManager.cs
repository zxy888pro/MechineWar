using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System;

public class UIManager : IGameSystem
{
    public GameObject root;

    public override void Initialize()
    {
        base.Initialize();
         
    }

    public void DestroyWindow(BaseWindow window)
    {

    }

    

    public override void Release()
    {
        base.Release();
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

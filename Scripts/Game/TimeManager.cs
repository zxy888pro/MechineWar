using UnityEngine;
using System.Collections;

public class TimeManager : IGameSystem
{
    private long m_curTicks = 0;


    public long GetCurrentTicks()
    {
        return System.Environment.TickCount;
    }

    public long GetDeltaTicks()
    {
        return GetCurrentTicks() - m_curTicks;
    }

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void Release()
    {
        base.Release();
    }

    public override void Update()
    {
        base.Update();
        m_curTicks = GetCurrentTicks();
    }
    
}

using UnityEngine;
using System.Collections;
using System;


public class GameStateController : IGameSystem
{
    //以分钟为单位
    //准备时间
    public float readyTime = 0.1f;
    //一局时间
    public float gameTime = 20f;

    private GameEventContext m_evtCtx;
    private GameBaseState m_curState;
    private IEnumerator mCoroutine;


    public static GameStateController instance = null;

    public GameStateController()
    {
        instance = this;

    }

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void Update()
    {
        base.Update();
        UpdateGameState();
    }

    public override void Release()
    {
        base.Release();
    }

    /// <summary>
    /// 服务器事件
    /// </summary>
    public void RegisterServerEvt()
    {


    }

    public void UnRegisterServerEvt()
    {

    }


    /// <summary>
    /// 客户端事件
    /// </summary>
    public void RegisterClientEvt()
    {

    }

    public void UnRegisterClientEvt()
    {


    }
    /// <summary>
    /// 获取当前状态已进行时间
    /// </summary>
    /// <returns></returns>
    public float GetElapseTime()
    {
        if (m_curState != null)
        {
            float time = m_curState.ElapseTime / 1000;
            return time;
        }
        return 0f;
    }

    public long GetElapseTicks()
    {
        if (m_curState != null)
        {
            return m_curState.ElapseTime;
        }
        return 0;
    }

    public EGAME_STATE_TYPE CurGameStateType
    {
        get
        {
            if (m_curState != null)
                return m_curState.GameState;
            return EGAME_STATE_TYPE.EGAME_STATE_MENU;
        }
    }

    public GameBaseState CurGameState
    {
        get
        {
            return m_curState;
        }
    }


    public void SwitchGameState(EGAME_STATE_TYPE type)
    {
        if (m_curState == null)
            return;
        m_curState.OnStateEnd();
        if (m_curState.GameState != type)
        {
            m_curState.OnStateEnd();
            switch (type)
            {
                case EGAME_STATE_TYPE.EGAME_STATE_BASE:
                    {
                        m_curState = new GameBaseState();
                    }
                    break;
            }
        }

    }






    public void UpdateGameState()
    {
        if (m_curState == null)
        {
            return;
        }
        if (m_curState.IsRunning == false)
        {
            m_curState.OnStateBegin();
            
        }
        m_curState.OnStateUpdate();
    }


}
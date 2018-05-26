using UnityEngine;
using System.Collections;

public enum EGAME_STATE_TYPE
{
    EGAME_STATE_MENU, //主菜單
    EGAME_STATE_GAME, //游戲
    EGAME_STATE_BASE

}

public class GameBaseState : IInputMessageHandler
{

    protected EGAME_STATE_TYPE m_estateType;
    protected bool m_bIsRunning = false;
    protected GameEventContext m_evtCtx;

    //游戏时间
    public long m_gameStateTick = 6000;
    protected long m_elapseTick = 0;
    protected long m_lastTick = 0;

    

    public long ElapseTime
    {
        get
        {
            return m_elapseTick;
        }
        set
        {
            m_elapseTick = value;
        }
    }

    public long GameStateTime
    {
        get
        {
            return m_gameStateTick;
        }
        set
        {
            m_gameStateTick = value;
        }
    }

    public bool IsRunning
    {
        get
        {
            return m_bIsRunning;
        }
    }

    public EGAME_STATE_TYPE GameState
    {
        get
        {
            return m_estateType;
        }
    }


    public GameBaseState()
    {
        m_estateType = EGAME_STATE_TYPE.EGAME_STATE_BASE;
        m_evtCtx = new GameEventContext();
    }

    public virtual void OnStateBegin()
    {
        m_elapseTick = 0;
        m_lastTick = GlobalClient.Instance.GetCurrentTicks();
        m_bIsRunning = true;
    }

    public virtual void OnStateEnd()
    {

    }

    public virtual void OnStateUpdate()
    {
        if (m_bIsRunning)
        {
            if (m_elapseTick < m_gameStateTick)
            {
                long deltaTick = GlobalClient.Instance.GetCurrentTicks() - m_lastTick;
                m_elapseTick += deltaTick;
                m_lastTick = GlobalClient.Instance.GetCurrentTicks();

            }
            else
            {

            }
        }
       

    }

    

    public virtual void OnStateDestory()
    {

    }

    public virtual void OnMouseMessage(MouseMessage msg)
    {

    }


    public virtual void OnKeyMessage(KeyBoardMessage msg)
    {

    }


    public virtual void OnJoyStickMessage(JoyStickMessage msg)
    {

    }
}

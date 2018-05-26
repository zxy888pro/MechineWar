using UnityEngine;
using System.Collections;




public class CameraMode
{
    protected Transform m_transform;
    protected ECameraModeType m_type;
    protected GameEventContext m_EvtCtx;

    public ECameraModeType type
    {
        get
        {
            return m_type;
        }
    }

    public CameraMode()
    {
        m_type = ECameraModeType.DefaultCamera;
        m_EvtCtx = new GameEventContext();
    }



    public virtual void RegisterEvt()
    {

    }

    public virtual void UnRegisterEvt()
    {

    }

    public virtual void Init()
    {

    }
    public Transform transform
    {
        get
        {
            return m_transform;
        }
        set
        {
            m_transform = value;
        }
    }

    public virtual void Update()
    {

    }

    public virtual void OnSwitchMode()
    {

    }
    //出來鼠標消息
    public virtual void OnMouseMessage(MouseMessage  msg)
    {

    }
    //處理鍵盤消息
    public virtual void OnKeyBoardMessage(KeyBoardMessage msg)
    {

    }
    //處理操縱杆消息
    public virtual void OnJoyStickMessage(JoyStickMessage msg)
    {

    }
}

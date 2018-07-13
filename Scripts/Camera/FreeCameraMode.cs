using UnityEngine;
using System.Collections;
using System;

public class FreedomCameraMode : CameraMode
{
    protected float m_xSpeed;
    protected float m_ySpeed;
    protected float m_minVerticalAngle;
    protected float m_maxVerticalAngle;
    protected float m_MoveSpeed;
    protected bool  m_bEnabled;

    public float xSpeed { get { return m_xSpeed; } set { m_xSpeed = value; } }
    public float ySpeed { get { return m_ySpeed; } set { m_ySpeed = value; } }
    public float minVerticalAngle { get { return m_minVerticalAngle; } set { m_minVerticalAngle = value; } }
    public float maxVerticalAngle { get { return maxVerticalAngle; } set { maxVerticalAngle = value; } }
    public float moveSpeed { get { return m_MoveSpeed; } set { m_MoveSpeed = value; } }


    private float m_x;
    private float m_y;
    private bool m_bMoveForward = false;
    private bool m_bMoveBack = false;
    private bool m_bMoveLeft = false;
    private bool m_bMoveRight = false;


    public FreedomCameraMode()
    {
        m_type = ECameraModeType.FreedomCamera;
        m_xSpeed = 300;
        m_ySpeed = 300;
        m_MoveSpeed = 20;
        m_minVerticalAngle = -90;
        m_maxVerticalAngle = 90;
        m_bEnabled = true;

    }

    public void SetEnabled(bool bEnable)
    {
        m_bEnabled = bEnable;
    }

    public override void Init()
    {
        base.Init();
        RegisterEvt();
    }

    public override void Update()
    {
        base.Update();
        if (m_bMoveForward)
        {
            transform.position = transform.position + transform.forward * m_MoveSpeed * 0.01f;
        }
        if (m_bMoveBack)
        {
            transform.position = transform.position - transform.forward * m_MoveSpeed * 0.01f;
        }
        if (m_bMoveLeft)
        {
            transform.position = transform.position - transform.right * m_MoveSpeed * 0.01f;
        }
        if (m_bMoveRight)
        {
            transform.position = transform.position + transform.right * m_MoveSpeed * 0.01f;
        }
        
    }

    public override void OnSwitchMode()
    {
        base.OnSwitchMode();
    }

    public override void OnMouseMessage(MouseMessage msg)
    {
        if (m_bEnabled == false)
            return;
        switch(msg.type)
        {
            case InputMsgType.InputMsgType_MouseMove:
                {
                    float deltaX = msg.dx;
                    float deltaY = msg.dy;

                    m_x += deltaX * m_xSpeed * 0.02f;
                    m_y -= deltaY * m_ySpeed * 0.02f;
                    m_y = MathHelper.ClampAngle(m_y, m_minVerticalAngle, m_maxVerticalAngle);

                    //根据顺序绕Z,X,Y旋转角度生成一个四元数
                    Quaternion rot = Quaternion.Euler(new Vector3(m_y, m_x, 0));
                    transform.rotation = rot;
                }
                break;
            case InputMsgType.InputMsgType_RButtonDown:
                {

                }
                break;
            case InputMsgType.InputMsgType_RButtonUp:
                {

                }
                break;
            default:
                break;
        }
    }

    public override void OnKeyBoardMessage(KeyBoardMessage msg)
    {
        switch (msg.type)
        {
            case InputMsgType.InputMsgType_KeyDown:
                {
                    switch(msg.kcode)
                    {
                        case KeyCode.W:
                            m_bMoveForward = true;
                            break;
                        case KeyCode.S:
                            m_bMoveBack = true;
                            break;
                        case KeyCode.A:
                            m_bMoveLeft = true;
                            break;
                        case KeyCode.D:
                            m_bMoveRight = true;
                            break;
                        default:
                            break;
                    }
                }
                break;
            case InputMsgType.InputMsgType_KeyUp:
               {
                   switch (msg.kcode)
                   {
                       case KeyCode.W:
                           m_bMoveForward = false;
                           break;
                       case KeyCode.S:
                           m_bMoveBack = false;
                           break;
                       case KeyCode.A:
                           m_bMoveLeft = false;
                           break;
                       case KeyCode.D:
                           m_bMoveRight = false;
                           break;
                       default:
                           break;
                   }
               }
                break;
            default:
                break;
        }

    }
}

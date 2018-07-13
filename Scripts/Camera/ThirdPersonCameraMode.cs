using UnityEngine;
using System.Collections;
using System;

public class ThirdPersonCameraMode : CameraMode
{

    protected Transform m_lookAt;

    protected float m_xSpeed;
    protected float m_ySpeed;
    protected float m_targetDistance;
    protected float m_targetHeight;
    protected float m_minVerticalAngle;
    protected float m_maxVerticalAngle;

    public float xSpeed { get { return m_xSpeed; } set { m_xSpeed = value; } }
    public float ySpeed { get { return m_ySpeed; } set { m_ySpeed = value; } }
    public float minVerticalAngle { get { return m_minVerticalAngle; } set { m_minVerticalAngle = value; } }
    public float maxVerticalAngle { get { return m_maxVerticalAngle; } set { m_maxVerticalAngle = value; } }

    public Transform lookAt { get { return m_lookAt; } set { m_lookAt = value; } }

    

    private float m_x;
    private float m_y;
    private RaycastHit m_hit;
    private bool m_bEnabled;
    private bool m_bRotate;

    public ThirdPersonCameraMode()
    {
        m_type = ECameraModeType.ThirdPersonCamera;
        m_xSpeed = 300;
        m_ySpeed = 300;
        m_targetDistance = 4;
        m_targetHeight = 1;
        m_minVerticalAngle = -90;
        m_maxVerticalAngle = 90;
        m_bRotate = false;

    }

    public void SetEnabled(bool bEnable)
    {
        m_bEnabled = bEnable;
    }
    
    public void ActivateRotation(bool bEnable)
    {
        m_bRotate = bEnable;
    }
  
    public override void Init()
    {

        if (m_lookAt == null)
            return;
        transform.LookAt(m_lookAt.transform);
        Vector3 dir = transform.position - m_lookAt.position;
        dir.Normalize();
        transform.position = m_lookAt.position + dir * m_targetDistance;
        transform.position = new Vector3(transform.position.x, m_lookAt.transform.position.y + m_targetHeight, transform.position.x);
        m_bEnabled = true;
        RegisterEvt();
    }


    public override void RegisterEvt()
    {
        

    }

    public override void UnRegisterEvt()
    {
    }

    


    public override void Update()
    {
        if (m_lookAt == null)
        {
            return;
        }
        if(m_bEnabled && m_bRotate)
        {
            //设置相机于观察目标的位置
            Vector3 position = m_lookAt.position - (transform.rotation * Vector3.forward * m_targetDistance + new Vector3(0.0f, -m_targetHeight, 0.0f));
            transform.position = position;

            m_lookAt.transform.rotation = Quaternion.Euler(0, m_x, 0);
        }
        
    }


    public override void OnMouseMessage(MouseMessage msg)
    {
        if (m_bEnabled == false)
            return;
        switch (msg.type)
        {
            case InputMsgType.InputMsgType_MouseMove:
                {
                    if(m_bRotate == true)
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
                   
                }
                break;
            case InputMsgType.InputMsgType_RButtonDown:
                {
                    m_bRotate = true;
                }
                break;
            case InputMsgType.InputMsgType_RButtonUp:
                {
                    m_bRotate = false;
                }
                break;
            default:
                break;
        }
    }

    public override void OnSwitchMode()
    {
        UnRegisterEvt();
    }

}

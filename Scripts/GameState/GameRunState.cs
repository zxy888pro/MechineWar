using UnityEngine;
using System.Collections;

public class GameRunState : GameBaseState
{

    public GameRunState()
    {
        m_estateType = EGAME_STATE_TYPE.EGAME_STATE_GAME;

    }

    public override void OnStateBegin()
    {
        base.OnStateBegin();
        GlobalClient.Instance.cameraController.SwitchCameraMode(ECameraModeType.FreedomCamera);
    }

    public override void OnStateUpdate()
    {
        base.OnStateUpdate();
    }

    public override void OnStateEnd()
    {
        base.OnStateEnd();
         
    }

    public override void OnStateDestory()
    {
        base.OnStateDestory();
    }

    public override void OnMouseMessage(MouseMessage msg)
    {
        base.OnMouseMessage(msg);
        GlobalClient.Instance.cameraController.cameraMode.OnMouseMessage(msg);
        
    }

    public override void OnJoyStickMessage(JoyStickMessage msg)
    {
        base.OnJoyStickMessage(msg);
    }

    public override void OnKeyMessage(KeyBoardMessage msg)
    {
        base.OnKeyMessage(msg);
        GlobalClient.Instance.cameraController.cameraMode.OnKeyBoardMessage(msg);
    }
    
}

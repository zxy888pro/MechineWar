using UnityEngine;
using System.Collections;



public enum InputMsgType
{
    // 鼠标
    InputMsgType_MouseMove = 0,
    InputMsgType_MouseWheel,
    InputMsgType_LButtonDown,
    InputMsgType_LButtonUp,
    InputMsgType_RButtonDown,
    InputMsgType_RButtonUp,

    // 键盘
    InputMsgType_KeyDown,
    InputMsgType_KeyUp,
    InputMsgType_Char,

    //操縱杆
    InputMsgType_JoystickAxis,
    InputMsgType_JoystickButtonDown,
    InputMsgType_JoystickButtonUp,

    InputMsgType_MaxCount,
 
}

/// 输入消息
public class InputMessage
{
    public InputMsgType type;
};

public enum MouseButton
{
    MouseButtonLeft,
    MouseButtonRight,
    MouseButtonNone = 6,
};

public enum JoyStickButton
{
    JoyStickBottonA,
    JoyStickBottonB,
    JoyStickBottonX,
    JoyStickBottonY
}

/// <summary>
/// 鼠標信息
/// </summary>
public class MouseMessage : InputMessage
{
    public float x, y;
    public float dx, dy;
    public MouseButton button; //鼠標鍵
    public float wheelChange;

}

/// <summary>
/// 鍵盤消息
/// </summary>
public class KeyBoardMessage : InputMessage
{
    public KeyCode kcode;
}

/// <summary>
/// 操縱桿消息
/// </summary>
public class JoyStickMessage : InputMessage
{
    public short horizontal, vertical;
    public JoyStickButton button;
}

/// <summary>
/// 輸入消息處理
/// </summary>
public interface IInputMessageHandler
{
     void OnMouseMessage(MouseMessage msg);


     void OnKeyMessage(KeyBoardMessage msg);


     void OnJoyStickMessage(JoyStickMessage msg);
    
    
}

using UnityEngine;
using System.Collections;

/// <summary>
/// 接收輸入,分發輸入消息
/// </summary>
public class InputMessageDispatcher : MonoBehaviour
{

    void Awake()
    {
        GameObject.DontDestroyOnLoad(this);

    }
    // Use this for initialization
    void Start()
    {

    }

    void ProcessMouse(IInputMessageHandler handler)
    {
        if (handler == null)
            return;
        MouseMessage mouseMsg = new MouseMessage();
        float deltaX = Input.GetAxis("Mouse X");
        float deltaY = Input.GetAxis("Mouse Y");
        float deltaW = Input.GetAxis("Mouse ScrollWheel");

        mouseMsg.dx = deltaX;
        mouseMsg.dy = deltaY;
        mouseMsg.x = Input.mousePosition.x;
        mouseMsg.y = Input.mousePosition.y;

        //先處理鼠標移動事件
        mouseMsg.type = InputMsgType.InputMsgType_MouseMove;
        handler.OnMouseMessage(mouseMsg);
        //再處理滾輪
        mouseMsg.wheelChange = deltaW;
        mouseMsg.type = InputMsgType.InputMsgType_MouseWheel;
        handler.OnMouseMessage(mouseMsg);
        //再處理按鍵
        if (Input.GetMouseButtonUp(0))
        {
            mouseMsg.type = InputMsgType.InputMsgType_LButtonUp;
            mouseMsg.button = MouseButton.MouseButtonLeft;
            handler.OnMouseMessage(mouseMsg);
        }
        if (Input.GetMouseButtonUp(1))
        {
            mouseMsg.type = InputMsgType.InputMsgType_RButtonUp;
            mouseMsg.button = MouseButton.MouseButtonRight;
            handler.OnMouseMessage(mouseMsg);
        }
        if (Input.GetMouseButtonDown(0))
        {
            mouseMsg.type = InputMsgType.InputMsgType_LButtonDown;
            mouseMsg.button = MouseButton.MouseButtonLeft;
            handler.OnMouseMessage(mouseMsg);
        }
        if (Input.GetMouseButtonDown(1))
        {
            mouseMsg.type = InputMsgType.InputMsgType_RButtonDown;
            mouseMsg.button = MouseButton.MouseButtonRight;
            handler.OnMouseMessage(mouseMsg);
        }
    }

    void ProcessKeyBoard(IInputMessageHandler handler)
    {
        if (handler == null)
            return;
        KeyCode code = KeyCode.None;
        KeyBoardMessage keyboardMsg = new KeyBoardMessage();
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            code = KeyCode.W;
            keyboardMsg.kcode = code;
            keyboardMsg.type = InputMsgType.InputMsgType_KeyDown;
            handler.OnKeyMessage(keyboardMsg);
            
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            code = KeyCode.S;
            keyboardMsg.kcode = code;
            keyboardMsg.type = InputMsgType.InputMsgType_KeyDown;
            handler.OnKeyMessage(keyboardMsg);
           
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            code = KeyCode.A;
            keyboardMsg.kcode = code;
            keyboardMsg.type = InputMsgType.InputMsgType_KeyDown;
            handler.OnKeyMessage(keyboardMsg);
            
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            code = KeyCode.D;
            keyboardMsg.kcode = code;
            keyboardMsg.type = InputMsgType.InputMsgType_KeyDown;
            handler.OnKeyMessage(keyboardMsg);
            
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            code = KeyCode.W;
            keyboardMsg.kcode = code;
            keyboardMsg.type = InputMsgType.InputMsgType_KeyUp;
            handler.OnKeyMessage(keyboardMsg);
            
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            code = KeyCode.S;
            keyboardMsg.kcode = code;
            keyboardMsg.type = InputMsgType.InputMsgType_KeyUp;
            handler.OnKeyMessage(keyboardMsg);
            
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            code = KeyCode.A;
            keyboardMsg.kcode = code;
            keyboardMsg.type = InputMsgType.InputMsgType_KeyUp;
            handler.OnKeyMessage(keyboardMsg);
            
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            code = KeyCode.D;
            keyboardMsg.kcode = code;
            keyboardMsg.type = InputMsgType.InputMsgType_KeyUp;
            handler.OnKeyMessage(keyboardMsg);
        }
    }

    void ProcessJoystick(IInputMessageHandler handler)
    {

    }

    // Update is called once per frame
    void Update()
    {
        IInputMessageHandler handler = GlobalClient.Instance.GetInputMessageHandler();
        if (handler == null)
            return;
        ///處理鼠標事件
        ProcessMouse(handler);
        ///處理鍵盤事件
        ProcessKeyBoard(handler);
        ///處理操縱杆事件
        ProcessJoystick(handler);
              
    }
}

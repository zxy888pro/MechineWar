using UnityEngine;
using System.Collections;

/// <summary>
/// 接收輸入
/// </summary>
public class GameInputHandler : MonoBehaviour
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

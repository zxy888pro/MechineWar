using UnityEngine;
using System.Collections;

public enum GameEventType
{
    //重新开始
    EVT_GAME_RESTART,
    //初始化
    EVT_GAME_INIT,
    //游戏状态切换
    EVT_GAME_SWITCH,

    //鼠标移动
    EVT_INPUT_MOUSE_MOVE,
    //鼠标键按下
    EVT_INPUT_MOUSE_BUTTON_DOWN,
    //鼠标键弹起 
    EVT_INPUT_MOUSE_BUTTON_UP,
    //操作杆方向改变
    EVT_INPUT_JOYSTICK_DIR_CHANGED,
    //操作按钮输入
    EVT_INPUT_JOYSTICK_BUTTON_DOWN,
    //键盘按键按下
    EVT_INPUT_KEYBOARD_KEY_DOWN,
    //键盘按键弹起
    EVT_INPUT_KEYBOARD_KEY_UP,
    //游戏状态到时
    EVT_ON_GAME_STATE_TIMEOUT,

    //单位事件
    EVT_REMOVE_ENTITY
}
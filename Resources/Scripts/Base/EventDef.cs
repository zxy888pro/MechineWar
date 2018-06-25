using UnityEngine;
using System.Collections;

public enum GameEventType
{
    //重新开始
    GameEventType_GameRestart,
    //初始化
    GameEventType_GameInit,
    //游戏状态切换
    GameEventType_GameStateSwitch,

    //单位事件
    GameEventType_RemoveEntity,
    //游戏状态到时
    GameEventType_OnGameStateTimeOut,


    //UI事件
    //關閉窗口
    GameEventType_HideWindow,
    //顯示窗口
    GameEventType_ShowWindow,
    //销毁窗口
    GameEventType_DestroyWindow
    
}
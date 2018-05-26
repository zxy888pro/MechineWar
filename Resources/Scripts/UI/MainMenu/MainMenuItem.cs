using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MainMenuItem : BaseWindow, IPointerClickHandler {

    public Text itemName;

    public MainMenuItemType type;

    void Awake()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData)
    {
        switch(type)
        {
            case MainMenuItemType.MainMenuItemType_StartGame:
                {
                    DataBuffer buf = new DataBuffer();
                    buf.WriteShort((short)EGAME_STATE_TYPE.EGAME_STATE_GAME);
                    GameEvtArg arg = new GameEvtArg(buf);
                    NotifyEvent(this, GameEventType.GameEventType_GameStateSwitch, arg);
                }
                break;
        }

    }
      
    

	 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MainMenuItem : BaseWindow {

    public Text itemName;
    public Image itemImage;
    public MainMenuItemType type;
    public float fFadeTime = 1.0f;
    public float fAlpha0 = 0.0f;
    public float fAlpha1 = 1.0f;
    public float fCurAlpha = 0;

    void Awake()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {

    }


    public override void OnPointerClick(PointerEventData eventData)
    {
        switch (type)
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

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        itemImage.color = Color.white;
       
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        itemImage.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }
	 
}

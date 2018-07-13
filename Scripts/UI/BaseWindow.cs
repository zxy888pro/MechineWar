using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;


public enum WindowOperationEventType
{
    WindowEventType_OnClick,
    WindowEventType_OnEnter,
    WindowEventType_OnExit,
    WindowEventType_OnDown,
    WindowEventType_OnUp
}

[Serializable]
public class WindowEventData
{
    public int eventType;
    public float mouseX;
    public float mouseY;
    public long objectID;
}


public class BaseWindow : BaseObject,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler,IPointerUpHandler
{
    protected RectTransform m_rt;
    protected bool m_bVisable;

    public RectTransform rectTransform
    {
        get { return m_rt; }
    }

    public virtual void Show()
    {
        m_bVisable = true;
        m_rt.localScale = Vector3.one;
        NotifyEvent(this, GameEventType.GameEventType_ShowWindow, new GameEvtArg());
    }
    
    public virtual void Hide()
    {
        m_bVisable = false;
        m_rt.localScale = Vector3.zero;
        NotifyEvent(this, GameEventType.GameEventType_HideWindow, new GameEvtArg());
    }

    public virtual void Destroy()
    {
        NotifyEvent(this, GameEventType.GameEventType_HideWindow, new GameEvtArg());
        GlobalClient.Instance.uiManager.DestroyWindow(this);
    }

    public virtual bool IsShow()
    {
        return m_bVisable;
    }

    void Awake()
    {
        m_rt = gameObject.GetComponent<RectTransform>();
        m_bVisable = true;
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
         
        
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        //当鼠标光标移入该对象时触发
    }


    public virtual void OnPointerExit(PointerEventData eventData)
    {
        //当鼠标光标移出该对象时触发
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {

    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {

    }

    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

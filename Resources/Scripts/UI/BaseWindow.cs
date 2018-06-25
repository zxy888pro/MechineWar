using UnityEngine;
using System.Collections;

public class BaseWindow : BaseObject
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

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

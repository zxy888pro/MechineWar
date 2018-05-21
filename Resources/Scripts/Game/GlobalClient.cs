using UnityEngine;
using System.Collections;

public class GlobalClient
{

    public static GlobalClient Instance;

    protected GameEventManager m_gameEventManager;
    protected GameStateController m_gameStateController;
    public GameEventManager eventManager { get { return m_gameEventManager; } }
    public GameStateController gameStateController { get { return m_gameStateController; } }
   



    public GlobalClient()
    {
        Instance = this;
    }

    public void Initialze()
    {
        m_gameEventManager = new GameEventManager();
        m_gameStateController = new GameStateController();
    }

    public long GetCurrentTicks()
    {
        return System.Environment.TickCount;
    }

   
    public void Update()
    {
         
        
    }


}

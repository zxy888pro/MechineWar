using UnityEngine;
using System.Collections;

public class GlobalClient
{

    public static GlobalClient Instance;

    protected GameEventManager m_gameEventManager;
    protected GameStateController m_gameStateController;
    protected CameraController m_cameraController;
    public GameEventManager eventManager { get { return m_gameEventManager; } }
    public GameStateController gameStateController { get { return m_gameStateController; } }

    public CameraController cameraController { get { return m_cameraController; } }
   



    public GlobalClient()
    {
        Instance = this;
    }

    public void Initialze()
    {
        m_gameEventManager = new GameEventManager();
        m_gameStateController = new GameStateController();
        m_cameraController = new CameraController();
    }

    public long GetCurrentTicks()
    {
        return System.Environment.TickCount;
    }

    public IInputMessageHandler GetInputMessageHandler()
    {
        if (m_gameStateController == null)
            return null;
        return m_gameStateController.CurGameState;
    }
   
    public void Update()
    {
         
        
    }


}

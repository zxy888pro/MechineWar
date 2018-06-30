using UnityEngine;
using System.Collections;

public class GlobalClient
{

    public static GlobalClient Instance;

    protected GameEventManager m_gameEventManager;
    protected GameStateController m_gameStateController;
    protected CameraController m_cameraController;
    protected ResourceManager m_resourceManager;
    protected SceneManager m_sceneManager;
    protected ObjectPoolManager m_objectPoolManager;
    protected UIManager m_uiManager;
    protected MessageDispatcher m_messageDispatcher;

    public GameEventManager eventManager { get { return m_gameEventManager; } }
    public GameStateController gameStateController { get { return m_gameStateController; } }
    public CameraController cameraController { get { return m_cameraController; } }
    public UIManager uiManager { get { return m_uiManager; } }
    public SceneManager sceneManager { get { return m_sceneManager; } }
    public ResourceManager resourceManager { get { return m_resourceManager; } }
    public ObjectPoolManager objectPoolManager { get { return m_objectPoolManager; } }
    public MessageDispatcher messageDispatcher { get { return m_messageDispatcher; } }
   



    public GlobalClient()
    {
        Instance = this;
    }

    public void Initialze()
    {
        m_gameEventManager = new GameEventManager();
        m_messageDispatcher = new MessageDispatcher();
        m_resourceManager = new ResourceManager();
        m_sceneManager = new SceneManager();
        m_objectPoolManager = new ObjectPoolManager();
        m_gameStateController = new GameStateController();
        m_cameraController = new CameraController();
        m_uiManager = new UIManager();

        

        m_gameEventManager.Initialize();
        m_messageDispatcher.Initialize();
        m_resourceManager.Initialize();
        m_sceneManager.Initialize();
        m_objectPoolManager.Initialize();
        m_cameraController.Initialize();
        m_gameStateController.Initialize();
        m_uiManager.Initialize();



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

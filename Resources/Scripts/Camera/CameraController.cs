using UnityEngine;
using System.Collections;

public enum ECameraModeType
{
    ThirdPersonCamera,
    FreedomCamera,
    DefaultCamera
}

/// <summary>
/// 相机控制器
/// </summary>
public class CameraController : IGameSystem
{
    CameraMode mCamMode;

    /// <summary>
    /// 相機對象
    /// </summary>
    Transform mCamTrans;

    public void SetCurrentCamera(Camera cam)
    {
        if(cam != null)
        {
            mCamTrans = cam.transform;
        }
    }

    public Camera GetCurrentCamera()
    {
        return mCamTrans.gameObject.GetComponent<Camera>();
    }

    public CameraMode cameraMode
    {
        get
        {
            return mCamMode;
        }
    }

    public void SwitchCameraMode(ECameraModeType type)
    {
        if (mCamMode != null)
            mCamMode.OnSwitchMode();
        switch (type)
        {
            case ECameraModeType.DefaultCamera:
                {
                    mCamMode = new CameraMode();
                }
                break;
            case ECameraModeType.ThirdPersonCamera:
                {
                   mCamMode = new ThirdPersonCameraMode();
                }
                break;
            case ECameraModeType.FreedomCamera:
                {
                    mCamMode = new FreedomCameraMode();
                }
                break;
        }
        if (mCamMode != null)
        {
            mCamMode.transform = mCamTrans;
            mCamMode.Init();
        }

    }

    public static CameraController instance;


    public override void Initialize()
    {
        base.Initialize();
        instance = this;
        //默認主相機
        mCamTrans = Camera.main.transform;
        //SwitchCameraMode(ECameraModeType.ThirdPersonCamera);
        SwitchCameraMode(ECameraModeType.FreedomCamera);
    }

    

    public override void Release()
    {
        base.Release();
    }


    // Update is called once per frame
    public override void Update()
    {
        if (mCamMode != null)
        {
            mCamMode.Update();
        }

    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

[Serializable]
public class ResourceDataCfg
{
    public List<ResourceData> fileInfoList = new List<ResourceData>();
}

[Serializable]
public class ResourceData
{
    public string resourceName;
    public string resourcePath;
    public int resouceType;
}

public class ResourceManager : IGameSystem
{

    //预置表
    Dictionary<string, ResourceRef> m_resourceDict;

    public Dictionary<string, ResourceRef> resourceDict
    {
        get
        {
            return m_resourceDict;
        }
    }


    public override void Initialize()
    {
        base.Initialize();
        m_resourceDict = new Dictionary<string, ResourceRef>();
        
        
    }

    public override void Release()
    {
        base.Release();
    }

    public override void Update()
    {
        base.Update();
    }

    void DestroyResource(ResourceRef res)
    {
        if (res != null)
            GameObject.Destroy(res.res);
    }

    /// <summary>
    /// 通过配置加载资源到资源管理
    /// </summary>
    /// <param name="cfg"></param>
    void ReadResources(ResourceDataCfg cfg)
    {
        foreach(var v in cfg.fileInfoList)
        {
            UnityEngine.Object obj = Resources.Load(v.resourcePath);
            if(obj != null)
            {
                try
                {
                    ResourceRef res = new ResourceRef();
                    res.res = obj;
                    res.resPath = v.resourcePath;
                    ResourceType type = (ResourceType)Enum.ToObject(typeof(ResourceType), v.resouceType);
                    res.resType = type;
                    AddResource(res);

                }catch(Exception e)
                {
                    Debug.Log(e.Message.ToString());
                }
                
            }
        }
    }

    public void AddResource(ResourceRef res)
    {
        if(m_resourceDict.ContainsKey(res.resName))
        {
            DestroyResource(m_resourceDict[res.resPath]);
        }
        m_resourceDict[res.resName] = res;
    }
   
    public ResourceRef FindResource(string resName)
    {
        if(m_resourceDict.ContainsKey(resName))
        {
            return m_resourceDict[resName];
        }
        return null;
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;


public class ResourceGroup
{
    public List<ResourceItem> itemList = new List<ResourceItem>();
}

public class ResourceItem
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

    Dictionary<EAssetLoaderType, IAssetLoader> m_loaderDict;

    public override void Initialize()
    {
        base.Initialize();
        m_loaderDict = new Dictionary<EAssetLoaderType, IAssetLoader>();
        m_resourceDict = new Dictionary<string, ResourceRef>();
        IAssetLoader resLoader = new ResourceLoader(GameLoop.Instance);
        


        TextAsset ta = Resources.Load<TextAsset>("Scp/internalResources.csv");
        if(ta  == null)
        {
            throw new Exception("ResourceManager Init Error! Scp/resconfig.csv not found!");
        }
        //加载内部资源组
        ResourceGroup iresGroup = null;
        try
        {
            iresGroup = new ResourceGroup();
            iresGroup.itemList = CsvUtil.LoadObjectsWithString<ResourceItem>(ta.text);

        }catch(Exception e)
        {
            Debug.LogError("Parse resconfig.csv failed !");
            throw e;
        }

        
    }

   

    public override void Release()
    {
        base.Release();
    }

    public override void Update()
    {
        base.Update();
    }

     
}

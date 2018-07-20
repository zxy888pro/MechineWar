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

    Dictionary<EAssetLoaderType, IAssetLoader> m_loaderDict;

    public override void Initialize()
    {
        base.Initialize();
        m_loaderDict = new Dictionary<EAssetLoaderType, IAssetLoader>();
        IAssetLoader resLoader = new ResourceLoader();
       
        
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
        ResourceGroup preLoadResGroup = null;
        ta = Resources.Load<TextAsset>("Scp/PreloadResources.csv");
        try
        {
            preLoadResGroup = new ResourceGroup();
            preLoadResGroup.itemList = CsvUtil.LoadObjectsWithString<ResourceItem>(ta.text);

        }
        catch (Exception e)
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

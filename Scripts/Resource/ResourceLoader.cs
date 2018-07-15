using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceLoader : IAssetLoader
{
 
    
    IEnumerator LoadTask()
    {
        yield break;
    }

    public ResourceLoader()
    {
         
    }

    public T Load<T>(string path) where T: Object
    {
       T obj = Resources.Load<T>(path);
       return obj;
    }

    public void LoadAsync<T>(string path, OnAssetLoaded callback) where T: Object
    {
        ResourceRequest requst = Resources.LoadAsync<T>(path);
        if(requst.isDone == true)
        {
            T asset = (T)requst.asset;
            callback();
        }

    }

    public EAssetLoaderType GetAssetLoaderType()
    {
        return EAssetLoaderType.EAssetLoaderType_Resource;
    }

    public void Clear(bool bForceGC = false)
    {
        
    }

    public void Unload(string resName)
    {

    }

    void LoadCallBack()
    {

    }
}

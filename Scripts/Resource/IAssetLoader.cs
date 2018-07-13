using UnityEngine;
using System.Collections;


public enum EAssetLoaderType
{
    EAssetLoaderType_Resource,
    EAssetLoaderType_AssetBundle,
    EAssetLoaderType_External,
}

public delegate void OnAssetLoaded();

public interface IAssetLoader
{
      T Load<T>(string path) where T: Object;
      void LoadAsync<T>(string path, OnAssetLoaded callback) where T : Object;

      void Clear(bool bForceGC = false);

      void Unload(string resName);

      EAssetLoaderType GetAssetLoaderType();
    
}

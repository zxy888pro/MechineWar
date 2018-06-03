using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class ResourceManager : IGameSystem
{

    //预置表
    Dictionary<string, GameObject> prefabData;
    Dictionary<string, Sprite> spriteData;

    public Dictionary<string, GameObject> PrefabData
    {
        get
        {
            return prefabData;
        }
    }

    public Dictionary<string, Sprite> SpriteData
    {
        get
        {
            return spriteData;
        }
    }

    public override void Initialize()
    {
        base.Initialize();
        prefabData = new Dictionary<string, GameObject>();
        spriteData = new Dictionary<string, Sprite>();
        
        
    }

    public override void Release()
    {
        base.Release();
    }

    public override void Update()
    {
        base.Update();
    }
   
    void ReadPrefabs(string dirPath)
    {

    }

     void ReadSprite(string dir)
    {

    }
}

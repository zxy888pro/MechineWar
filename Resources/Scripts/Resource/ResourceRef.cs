using UnityEngine;
using System.Collections;

/// <summary>
/// 资源类型
/// </summary>
public enum ResourceType
{
    ResourceType_Prefab,
    ResourceType_Sprite,
    ResourceType_Text,
    ResourceType_Binary,
    ResourceType_Texture
}

/// <summary>
/// 资源引用
/// </summary>
public class ResourceRef 
{
    public ResourceType resType;
    public string resName;
    public string resPath;
    public Object res;
}

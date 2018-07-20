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
    ResourceType_Texture,
    ResourceType_Null
}

public enum ResourceState
{
    ResourceState_NotLoaded,
    ResourceState_Queued,
    ResourceState_Loading,
    ResourceState_Ready

}
/// <summary>
/// 资源引用
/// </summary>
public abstract class IResource
{
    
    public string resName;
    public string resPath;
    public ResourceState state;
    public Object res;

    protected ResourceType m_restype;

    public IResource()
    {
        m_restype = ResourceType.ResourceType_Null;
    }

    public abstract ResourceType GetResourceType();

    public virtual Object GetData() { return res; }
    
}

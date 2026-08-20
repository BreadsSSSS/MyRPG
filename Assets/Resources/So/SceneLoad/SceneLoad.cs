using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "SceneLoad", menuName = "So/SceneLoad")]
public class SceneLoad : ScriptableObject
{
    public Vector2 pos;
    public AssetReference Scene;
    public int deep;
    public SceneType type;
}

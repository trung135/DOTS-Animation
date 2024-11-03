using Unity.Collections;
using Unity.Entities;
using UnityEngine;

public struct SpriteSheetInfo : IComponentData
{
    public int spriteSheetId;
    public NativeArray<Sprite> sprites;
}
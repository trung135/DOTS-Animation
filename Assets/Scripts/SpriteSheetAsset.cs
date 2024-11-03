using System;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteSheetAsset", menuName = "New Asset/SpriteSheetAsset")]
public class SpriteSheetAsset : ScriptableObject
{
    public ushort id;
    public Sheet[] Sheets;

    [Serializable]
    public class Sheet
    {
        public ushort ID;
        public string Name;
        public Sprite[] Sprites;
    }
}
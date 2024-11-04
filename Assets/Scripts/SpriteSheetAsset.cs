using System;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteSheetAsset", menuName = "New Asset/SpriteSheetAsset")]
public class SpriteSheetAsset : ScriptableObject
{
    // [SerializeField] private ushort _id;
    // [SerializeField] private SpriteSheet[] _spritesheets;
    //
    // public ushort Id => _id;
    // public ReadOnlyMemory<SpriteSheet> SpriteSheets => _spritesheets;
    //
    // [Serializable]
    // public class SpriteSheet
    // {
    //     [SerializeField] private ushort _id;
    //     [SerializeField] private string _name;
    //     [SerializeField] private Sprite[] _sprites;
    //     
    //     public ushort Id => _id;
    //     public string Name => _name;
    //     public ReadOnlyMemory<Sprite> Sprites => _sprites;
    // }
}
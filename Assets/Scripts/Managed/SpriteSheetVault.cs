using System;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSheetVault : MonoBehaviour
{
    [SerializeField] private SpriteSheetAsset[] spriteSheetAssets;
    
    private static Dictionary<AssetAnimId, SpriteSheetAsset.Animations> _idToAnimation;
    private static Dictionary<AssetAnimDirectionId, int> _idToAmountSprite;

    public static bool TryGetSheet(AssetAnimId id, out SpriteSheetAsset.Animations sheet)
        => _idToAnimation.TryGetValue(id, out sheet);

    public static bool TryGetAmountSprite(AssetAnimDirectionId id, out int amount)
        => _idToAmountSprite.TryGetValue(id, out amount);


    private void Awake()
    {
        _idToAnimation = new Dictionary<AssetAnimId, SpriteSheetAsset.Animations>();
        _idToAmountSprite = new Dictionary<AssetAnimDirectionId, int>();

        var assets = spriteSheetAssets.AsSpan();

        foreach (var asset in assets)
        {
            var assetId = asset.AssetID;
            var assetName = asset.AssetName;
            var animations = asset.AnimationList.Span;

            foreach (var anim in animations)
            {
                var animID = anim.AnimID;
                var animName = anim.AnimName;
                var directions = anim.DirectionList.Span;

                var id = new AssetAnimId(assetId, animID);
                _idToAnimation.TryAdd(id, anim);

                foreach (var direction in directions)
                {
                    var directionID = direction.DirectionID;
                    var assetAnimDirectionId = new AssetAnimDirectionId(assetId, animID, directionID);
                    _idToAmountSprite.TryAdd(assetAnimDirectionId, direction.SpriteList.Span.Length);
                }
            }
        }
    }
}
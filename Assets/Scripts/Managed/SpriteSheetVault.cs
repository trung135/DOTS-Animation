using System;
using UnityEngine;

public class SpriteSheetVault : MonoBehaviour
{
    [SerializeField] private AnimationSpriteSheet[] animationSpriteSheetArray;
    public void Awake()
    {
        var spriteSheets = animationSpriteSheetArray.AsSpan();
        foreach (var spriteSheet in spriteSheets)
        {
            if (!spriteSheet) continue;

            var animationID = spriteSheet.AnimationID;
            var animationName = spriteSheet.Animation;
            var directions = spriteSheet.DirectionArray.Span;

            foreach (var direction in directions)
            {
                var directionID = direction.DirectionID;
                var directionName = direction.DirectionName;
                
                if (direction.SpriteArray.Length <= 0) continue;
                
                
            }
        }
    }
}
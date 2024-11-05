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

            var sheetId = spriteSheet.Id;
            var animations = spriteSheet.AnimationArray.Span;
            foreach (var anim in animations)
            {
                var animationId = anim.Id;
                var animationName = anim.Name;
                var directions = anim.DirectionArray.Span;
                foreach (var direction in directions)
                {
                    var directionId = direction.DirectionID;
                    var directionName = direction.DirectionName;
                    
                    if (direction.SpriteArray.Length <= 0) continue;
                    
                    
                }
            }
        }
    }
}
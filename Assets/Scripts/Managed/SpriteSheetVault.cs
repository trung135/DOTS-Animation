using System;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSheetVault : MonoBehaviour
{
    private static Dictionary<SpriteSheetId, SpriteAnimation> s_animationDictionary;
    
    public static IReadOnlyDictionary<SpriteSheetId, SpriteAnimation> AnimationDictionary => s_animationDictionary;
    
    [SerializeField] private AnimationSpriteSheet[] animationSpriteSheetArray;
    public void Awake()
    {
        s_animationDictionary = new Dictionary<SpriteSheetId, SpriteAnimation>();
        var spriteSheets = animationSpriteSheetArray.AsSpan();
        foreach (var spriteSheet in spriteSheets)
        {
            if (!spriteSheet) continue;

            var spritesheetId = spriteSheet.Id;
            var animations = spriteSheet.AnimationArray.Span;

            foreach (var anim in animations)
            {
                var animationId = anim.Id;
                var animationName = anim.Name;

                var directions = anim.DirectionArray.Span;

                foreach (var direction in directions)
                    if (direction.SpriteArray.Length <= 0) continue;
                
                var uniqueId = new SpriteSheetId(spritesheetId, animationId);
                s_animationDictionary[uniqueId] = anim;
            }
        }
    }
}
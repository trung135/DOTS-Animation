using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

public class SpriteAuthoring : MonoBehaviour
{
    public Sprite[] sprites;

    public static Sprite[] Sprites;

    private void Awake()
    {
        Sprites = new Sprite[sprites.Length];
        var spanSprites = sprites.AsSpan();
        for (int i = 0; i < spanSprites.Length; i++)
        {
            Sprites[i] = spanSprites[i];
        }
    }
}
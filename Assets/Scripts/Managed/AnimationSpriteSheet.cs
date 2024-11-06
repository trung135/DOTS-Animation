using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Animation", menuName = "Scriptable Object/Animation", order = 0)]
public sealed class AnimationSpriteSheet : ScriptableObject
{
    [SerializeField] private ushort id;
    [SerializeField] private SpriteAnimation[] animationArray;
    
    public ushort Id => id;
    public ReadOnlyMemory<SpriteAnimation> AnimationArray => animationArray;
}

[Serializable]
public class SpriteAnimation
{
    [SerializeField] private ushort id;
    [SerializeField] private string name;
    [SerializeField] private Direction[] directionArray;
    
    public ushort Id => id;
    public string Name => name;
    public ReadOnlyMemory<Direction> DirectionArray => directionArray;
}

[Serializable]
public class Direction
{
    [SerializeField] private ushort directionID;
    [SerializeField] private string directionName;
    [SerializeField] private Sprite[] spriteArray;
    
    public ushort DirectionID => directionID;
    public string DirectionName => directionName;
    public ReadOnlyMemory<Sprite> SpriteArray => spriteArray;
}
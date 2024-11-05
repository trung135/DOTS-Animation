using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Animation", menuName = "Scriptable Object/Animation", order = 0)]
public sealed class AnimationSpriteSheet : ScriptableObject
{
    [SerializeField] private ushort animationID;
    [SerializeField] private string animation;
    [SerializeField] private Direction[] directionArray;
    
    public ushort AnimationID => animationID;
    public string Animation => animation;
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
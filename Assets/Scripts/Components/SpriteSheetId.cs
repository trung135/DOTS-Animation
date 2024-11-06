using System;
using System.Runtime.InteropServices;

[Serializable]
[StructLayout(LayoutKind.Explicit)]
public readonly struct SpriteSheetId : IEquatable<SpriteSheetId>
{
    [FieldOffset(0)] private readonly uint _raw;
    [FieldOffset(0)] public readonly ushort animationId;
    [FieldOffset(2)] public readonly ushort spritesheetId;
    
    public SpriteSheetId(ushort spritesheetId, ushort animationId) : this()
    {
        this.animationId = animationId;
        this.spritesheetId = spritesheetId;
    }
    public bool Equals(SpriteSheetId other) => _raw == other._raw;

    public override bool Equals(object obj) => obj is SpriteSheetId other && Equals(other);

    public override int GetHashCode() => _raw.GetHashCode();
    
    public static bool operator ==(SpriteSheetId left, SpriteSheetId right) => left._raw == right._raw;

    public static bool operator !=(SpriteSheetId left, SpriteSheetId right) => left._raw != right._raw;
}
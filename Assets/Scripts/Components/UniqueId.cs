using System;
using System.Runtime.InteropServices;

[Serializable]
[StructLayout(LayoutKind.Explicit)]
public readonly struct AssetAnimId : IEquatable<AssetAnimId>
{
    [FieldOffset(0)] private readonly uint _raw;
    [FieldOffset(0)] public readonly ushort AssetId;
    [FieldOffset(2)] public readonly ushort AnimId;

    public AssetAnimId(ushort assetId, ushort animId) : this()
    {
        AssetId = assetId;
        AnimId = animId;
    }

    public bool Equals(AssetAnimId other)
        => _raw == other._raw;

    public override bool Equals(object obj)
        => obj is AssetAnimId other && _raw == other._raw;

    public override int GetHashCode()
        => _raw.GetHashCode();

    public static bool operator ==(AssetAnimId left, AssetAnimId right)
        => left._raw == right._raw;

    public static bool operator !=(AssetAnimId left, AssetAnimId right)
        => left._raw != right._raw;
}

[StructLayout(LayoutKind.Explicit)]
public readonly struct AssetAnimDirectionId : IEquatable<AssetAnimDirectionId>
{
    [FieldOffset(0)] private readonly ulong _raw; // Sử dụng ulong để lưu trữ ba ushort trong 8 byte
    [FieldOffset(0)] public readonly ushort AssetId;
    [FieldOffset(2)] public readonly ushort AnimId;
    [FieldOffset(4)] public readonly ushort DirectionId;

    public AssetAnimDirectionId(ushort assetId, ushort animId, ushort directionId) : this()
    {
        AssetId = assetId;
        AnimId = animId;
        DirectionId = directionId;
    }

    public bool Equals(AssetAnimDirectionId other)
        => _raw == other._raw;

    public override bool Equals(object obj)
        => obj is AssetAnimDirectionId other && _raw == other._raw;

    public override int GetHashCode()
        => _raw.GetHashCode();

    public static bool operator ==(AssetAnimDirectionId left, AssetAnimDirectionId right)
        => left._raw == right._raw;

    public static bool operator !=(AssetAnimDirectionId left, AssetAnimDirectionId right)
        => left._raw != right._raw;
}
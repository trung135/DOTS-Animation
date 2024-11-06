using Unity.Collections;
using Unity.Entities;

namespace Clover
{
    public sealed partial class InitializeNativeSpriteSheetVaultSystem : SystemBase
    {
        protected override void OnCreate()
        {
            
        }

        protected override void OnUpdate()
        {
            var animationDictionary = SpriteSheetVault.AnimationDictionary;
            var count = animationDictionary.Count;
            var vault = new NativeSpriteSheetVault
            {
                uniqueIdArray = new NativeArray<SpriteSheetId>(count, Allocator.Persistent)
            };
        }
    }
}
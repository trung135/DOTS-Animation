using Unity.Entities;
using UnityEngine;

namespace Clover.Authoring
{
    public class SpriteAuthoring : MonoBehaviour
    {
        private class SpriteAuthoringBaker : Baker<SpriteAuthoring>
        {
            public override void Bake(SpriteAuthoring authoring)
            {
            }
        }
    }
}
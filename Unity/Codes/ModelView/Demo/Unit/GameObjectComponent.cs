using UnityEngine;

namespace ET
{
    public class GameObjectComponent: Entity, IAwake, IDestroy
    {
        public GameObject GameObject { get; set; }
        public SpriteRenderer SpriteRenderer;
    }
}
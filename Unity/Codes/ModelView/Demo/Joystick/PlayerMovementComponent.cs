using UnityEngine;

namespace ET
{
    public class PlayerMovementComponent : Entity, IAwake, IUpdate
    {
        public GameObject Go;
        public float Speed = 1;
        public Rigidbody2D Rigidbody2D;
        public Animator Animator;
        public float InputX, InputY;
        public float StopX, StopY;
    }
}
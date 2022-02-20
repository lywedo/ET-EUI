using UnityEngine;

namespace ET
{
    public class PlayerMovementComponentAwakeSystem: AwakeSystem<PlayerMovementComponent>
    {
        public override void Awake(PlayerMovementComponent self)
        {
            self.Go = GameObject.Find("Player");
            self.Rigidbody2D = self.Go.GetComponent<Rigidbody2D>();
            // self.Animator = self.Go.GetComponent<Animator>();
        }
    }
    
    public class PlayerMovementComponentUpdateSystem:UpdateSystem<PlayerMovementComponent>
    {
        public override void Update(PlayerMovementComponent self)
        {
            self.InputX = Input.GetAxisRaw("Horizontal");
            self.InputY = Input.GetAxisRaw("Vertical");
            Vector2 input = (self.Go.transform.right * self.InputX + self.Go.transform.up * self.InputY).normalized;
            self.Rigidbody2D.velocity = input * self.Speed;

            // if (input != Vector2.zero)
            // {
                // animator.SetBool("isMoving", true);
                // stopX = inputX;
                // stopY = inputY;
            // }
            // else
            // {
            //     animator.SetBool("isMoving", false);
            // }
            // animator.SetFloat("InputX", stopX);
            // animator.SetFloat("InputY", stopY);
        }
    }

    public class PlayerMovementComponentSystem
    {
        
    }
}
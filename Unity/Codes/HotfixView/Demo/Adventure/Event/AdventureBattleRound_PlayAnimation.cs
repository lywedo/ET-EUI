using ET.EventType;
using UnityEngine;

namespace ET
{
    public class AdventureBattleRound_PlayAnimation: AEvent<AdventureBattleRound>
    {
        protected override async void Run(AdventureBattleRound args)
        {
            if (!args.AttackUnit.IsAlive() || !args.TargetUnit.IsAlive())
            {
                return;
            }
            args.AttackUnit?.GetComponent<AnimatorComponent>().Play(MotionType.Attack);
            args.TargetUnit?.GetComponent<AnimatorComponent>().Play(MotionType.Hurt);

            long instanceId = args.TargetUnit.InstanceId;
            args.TargetUnit.GetComponent<GameObjectComponent>().SpriteRenderer.color = Color.red;
            
            await TimerComponent.Instance.WaitAsync(300);
            
            if (instanceId != args.TargetUnit.InstanceId)
            {
                return;
            }
            
            args.TargetUnit.GetComponent<GameObjectComponent>().SpriteRenderer.color = Color.white;
        }
    }
}
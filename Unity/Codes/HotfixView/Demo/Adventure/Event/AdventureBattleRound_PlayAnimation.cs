using ET.EventType;
using UnityEngine;

namespace ET
{
    public class AdventureBattleRound_PlayAnimation: AEventAsync<AdventureBattleRoundView>
    {
        protected override async ETTask Run(AdventureBattleRoundView args)
        {
            Log.Console($"AdventureBattleRound:{args.AttackUnit.Type}  {args.TargetUnit.Type}");
            if (!args.AttackUnit.IsAlive() || !args.TargetUnit.IsAlive())
            {
                return;
            }
            Log.Console($"AdventureBattleRound:{args.AttackUnit.Type}  {args.TargetUnit.Type}");
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
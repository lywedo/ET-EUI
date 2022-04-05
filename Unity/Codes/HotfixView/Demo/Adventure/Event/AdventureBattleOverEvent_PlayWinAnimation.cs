using ET.EventType;

namespace ET
{
    public class AdventureBattleOverEvent_PlayWinAnimation: AEvent<EventType.AdventureBattleOver>
    {
        protected override async void Run(AdventureBattleOver args)
        {
            args.WinUnit?.GetComponent<AnimatorComponent>()?.Play(MotionType.Win);
            await ETTask.CompletedTask;
        }
    }
}
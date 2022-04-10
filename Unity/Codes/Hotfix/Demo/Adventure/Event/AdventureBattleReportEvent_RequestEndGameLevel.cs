using ET.EventType;

namespace ET
{
    public class AdventureBattleReportEvent_RequestEndGameLevel: AEventAsync<AdventureBattleReport>
    {
        protected override async ETTask Run(AdventureBattleReport args)
        {
            if (args.BattleRoundResult == BattleRoundResult.KeepBattle)
            {
                return;
            }

            int errorCode = await AdventureHelper.RequestEndGameLevel(args.ZoneScene, args.BattleRoundResult, args.Round);
            if (errorCode != ErrorCode.ERR_Success)
            {
                return;
            }

            await TimerComponent.Instance.WaitAsync(3000);
            args.ZoneScene?.CurrentScene()?.GetComponent<AdventureComponent>()?.ShowAdventureBpBarInfo(false);
            args.ZoneScene?.CurrentScene()?.GetComponent<AdventureComponent>()?.ResetAdventure();
        }
    }
}
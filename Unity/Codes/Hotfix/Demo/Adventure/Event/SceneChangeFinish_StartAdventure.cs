﻿using ET.EventType;

namespace ET
{
    public class SceneChangeFinish_StartAdventure: AEventAsync<EventType.SceneChangeFinish>
    {
        protected override async ETTask Run(SceneChangeFinish args)
        {
            Unit unit = UnitHelper.GetMyUnitFromCurrentScene(args.CurrentScene);
            if (unit.GetComponent<NumericComponent>().GetAsInt(NumericType.AdventureState) == 0)
            {
                return;
            }

            await TimerComponent.Instance.WaitAsync(3000);
            args.CurrentScene.GetComponent<AdventureComponent>().StartAdventure().Coroutine();
        }
    }
}
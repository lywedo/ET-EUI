﻿namespace ET
{
    public class M2C_NoticeUnitNumericHandler: AMHandler<M2C_NoticeUnitNumeric>
    {
        protected override async void Run(Session session, M2C_NoticeUnitNumeric message)
        {
            Log.Debug($"M2C_NoticeUnitNumericHandler:{message}");
            session.ZoneScene()?.CurrentScene()?.GetComponent<UnitComponent>()?.Get(message.UnitId)?.GetComponent<NumericComponent>()?.Set(message.NumericType, message.NewValue);
            await ETTask.CompletedTask;
        }
    }
}
using System;

namespace ET
{
    public class C2M_ReviveHandler: AMActorLocationRpcHandler<Unit, C2M_Revive, M2C_Revive>
    {
        protected override async ETTask Run(Unit unit, C2M_Revive request, M2C_Revive response, Action reply)
        {
            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
            int dyingState = numericComponent.GetAsInt(NumericType.DyingState);
            if (dyingState == 0)
            {
                response.Error = ErrorCode.ERR_ReviveError;
                reply();
                return;
            }
            
            numericComponent.SetNoEvent(NumericType.DyingState, 0);
            response.Error = ErrorCode.ERR_Success;
            reply();
            await ETTask.CompletedTask;
        }
    }
}
using System;

namespace ET
{
    public class C2M_UpRoleLevelHandler: AMActorLocationRpcHandler<Unit, C2M_UpRoleLevel, M2C_UPRoleLevel>
    {
        protected override async ETTask Run(Unit unit, C2M_UpRoleLevel request, M2C_UPRoleLevel response, Action reply)
        {
            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
            int UnitLevel = numericComponent.GetAsInt(NumericType.Level);
            PlayerLevelConfigConfig config = PlayerLevelConfigConfigCategory.Instance.Get(UnitLevel);
            long exp = numericComponent.GetAsLong(NumericType.Exp);

            if (exp < config.NeedExp)
            {
                response.Error = ErrorCode.ERR_ExpNotEnoughError;
                reply();
                return;
            }

            long newExp = exp - config.NeedExp;
            if (newExp < 0)
            {
                response.Error = ErrorCode.ERR_ExpNumError;
                reply();
                return;
            }

            numericComponent[NumericType.Exp] = newExp;
            numericComponent[NumericType.Level] = UnitLevel + 1;
            numericComponent[NumericType.AttributePoint] += 1;
            reply();
            await ETTask.CompletedTask;
        }
    }
}
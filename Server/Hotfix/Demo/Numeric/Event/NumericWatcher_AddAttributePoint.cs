using ET.EventType;

namespace ET
{
    [NumericWatcher(NumericType.Spirit)]
    [NumericWatcher(NumericType.Agile)]
    [NumericWatcher(NumericType.PhysicalStrength)]
    [NumericWatcher(NumericType.Power)]
    public class NumericWatcher_AddAttributePoint: INumericWatcher
    {
        public void Run(NumbericChange args)
        {
            if (!(args.Parent is Unit unit))
            {
                return;
            }

            if (args.NumericType == NumericType.Power)
            {
                unit.GetComponent<NumericComponent>()[NumericType.DamageValueAdd] += 5;
            }

            if (args.NumericType == NumericType.PhysicalStrength)
            {
                unit.GetComponent<NumericComponent>()[NumericType.HpPct] += 1 * 10000;
            }

            if (args.NumericType == NumericType.Agile)
            {
                unit.GetComponent<NumericComponent>()[NumericType.ArmorFinalAdd] += 5;
            }

            if (args.NumericType == NumericType.Spirit)
            {
                unit.GetComponent<NumericComponent>()[NumericType.MpFinalPct] += 1 * 10000;
            }
        }
    }
}
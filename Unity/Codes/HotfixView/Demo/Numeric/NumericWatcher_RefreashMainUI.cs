using ET.EventType;

namespace ET
{
    [NumericWatcher(NumericType.Level)]
    [NumericWatcher(NumericType.Gold)]
    [NumericWatcher(NumericType.Exp)]
    public class NumericWatcher_RefreashMainUI: INumericWatcher
    {
        public void Run(NumbericChange args)
        {
            args.Parent.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.Refresh();
        }
    }
}
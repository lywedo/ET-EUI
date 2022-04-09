using ET.EventType;

namespace ET
{
    public class NumericChangeEvent_NoticeToClient: AEventClass<EventType.NumbericChange>
    {
        protected override async void Run(object numbericChange)
        {
            EventType.NumbericChange args = numbericChange as EventType.NumbericChange;
            if (!(args.Parent is Unit unit))
            {
                return;
            }
            unit.GetComponent<NumericNoticeComponent>()?.NoticeImmediately(args);
            await ETTask.CompletedTask;
        }
    }
}
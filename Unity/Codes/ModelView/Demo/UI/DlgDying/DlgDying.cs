namespace ET
{
	public  class DlgDying :Entity,IAwake,IUILogic
	{

		public DlgDyingViewComponent View { get => this.Parent.GetComponent<DlgDyingViewComponent>();} 

		 

	}
}

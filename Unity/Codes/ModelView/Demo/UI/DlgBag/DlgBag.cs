namespace ET
{
	public  class DlgBag :Entity,IAwake,IUILogic
	{

		public DlgBagViewComponent View { get => this.Parent.GetComponent<DlgBagViewComponent>();} 

		 

	}
}

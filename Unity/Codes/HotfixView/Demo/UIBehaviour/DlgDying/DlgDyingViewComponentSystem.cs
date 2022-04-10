
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgDyingViewComponentAwakeSystem : AwakeSystem<DlgDyingViewComponent> 
	{
		public override void Awake(DlgDyingViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgDyingViewComponentDestroySystem : DestroySystem<DlgDyingViewComponent> 
	{
		public override void Destroy(DlgDyingViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}


using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class ESCommonTestUiAwakeSystem : AwakeSystem<ESCommonTestUi,Transform> 
	{
		public override void Awake(ESCommonTestUi self,Transform transform)
		{
			self.uiTransform = transform;
		}
	}


	[ObjectSystem]
	public class ESCommonTestUiDestroySystem : DestroySystem<ESCommonTestUi> 
	{
		public override void Destroy(ESCommonTestUi self)
		{
			self.DestroyWidget();
		}
	}
}


using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_Item_StestDestroySystem : DestroySystem<Scroll_Item_Stest> 
	{
		public override void Destroy( Scroll_Item_Stest self )
		{
			self.DestroyWidget();
		}
	}
}

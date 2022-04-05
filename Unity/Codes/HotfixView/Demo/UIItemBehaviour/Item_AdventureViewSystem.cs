
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_Item_AdventureDestroySystem : DestroySystem<Scroll_Item_Adventure> 
	{
		public override void Destroy( Scroll_Item_Adventure self )
		{
			self.DestroyWidget();
		}
	}
}

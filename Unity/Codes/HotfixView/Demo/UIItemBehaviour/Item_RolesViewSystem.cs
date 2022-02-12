
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_Item_RolesDestroySystem : DestroySystem<Scroll_Item_Roles> 
	{
		public override void Destroy( Scroll_Item_Roles self )
		{
			self.DestroyWidget();
		}
	}
}

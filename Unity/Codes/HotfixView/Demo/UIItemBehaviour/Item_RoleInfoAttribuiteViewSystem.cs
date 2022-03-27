
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_Item_RoleInfoAttribuiteDestroySystem : DestroySystem<Scroll_Item_RoleInfoAttribuite> 
	{
		public override void Destroy( Scroll_Item_RoleInfoAttribuite self )
		{
			self.DestroyWidget();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static  class DlgBagSystem
	{

		public static void RegisterUIEvent(this DlgBag self)
		{
			self.View.RegisterCloseEvent<DlgBag>(self.View.E_CloseButton);
			// self.View.E_TopButtonToggleGroup.Add
		}

		public static void ShowWindow(this DlgBag self, Entity contextData = null)
		{
		}

		 

	}
}

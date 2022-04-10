using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static  class DlgDyingSystem
	{

		public static void RegisterUIEvent(this DlgDying self)
		{
			self.RegisterCloseEvent<DlgDying>(self.View.EButton_BackButton);
		}

		public static void ShowWindow(this DlgDying self, Entity contextData = null)
		{
		}

		 

	}
}

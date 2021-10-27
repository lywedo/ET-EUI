﻿using System.Collections.Generic;

namespace ET
{
	public  class DlgLogin :Entity
	{

		public DlgLoginViewComponent View { get => this.Parent.GetComponent<DlgLoginViewComponent>();} 

		public Dictionary<int, Scroll_Item_test> ItemsDictionary;

	}
}

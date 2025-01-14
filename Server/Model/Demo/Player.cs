﻿namespace ET
{
	public enum PlayerState
	{
		Disconnect,
		Gate,
		Game,
	}
	[ObjectSystem]
	public class PlayerSystem : AwakeSystem<Player, long, long>
	{
		public override void Awake(Player self, long a, long roleId)
		{
			self.Account = a;
			self.UnitId = roleId;
		}
	}

	public sealed class Player : Entity, IAwake<string>, IAwake<long, long>
	{
		public long Account { get; set; }
		
		// public long SessionInstanceId { get; set; }
		
		public long UnitId { get; set; }
		
		public PlayerState PlayerState { get; set; }
		
		public Session ClientSession { get; set; }

		// public void Awake(string account)
		// {
		// 	this.Account = account;
		// }
	}
}
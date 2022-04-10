using UnityEngine;

namespace ET
{
    public static class UnitFactory
    {
        public static async ETTask<Unit> Create(Scene currentScene, UnitInfo unitInfo)
        {
	        UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
	        Unit unit = unitComponent.AddChildWithId<Unit, int>(unitInfo.UnitId, unitInfo.ConfigId);
	        unitComponent.Add(unit);
	        
	        // unit.Position = new Vector3(unitInfo.X, unitInfo.Y, unitInfo.Z); //mmorpg
	        // unit.Forward = new Vector3(unitInfo.ForwardX, unitInfo.ForwardY, unitInfo.ForwardZ); //mmorpg
	        
	        NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
	        for (int i = 0; i < unitInfo.Ks.Count; ++i)
	        {
		        numericComponent.Set(unitInfo.Ks[i], unitInfo.Vs[i]);
	        }
	        //mmorpg
	        // unit.AddComponent<MoveComponent>();
	        // if (unitInfo.MoveInfo != null)
	        // {
		       //  if (unitInfo.MoveInfo.X.Count > 0)
		       //  {
			      //   using (ListComponent<Vector3> list = ListComponent<Vector3>.Create())
			      //   {
				     //    list.Add(unit.Position);
				     //    for (int i = 0; i < unitInfo.MoveInfo.X.Count; ++i)
				     //    {
					    //     list.Add(new Vector3(unitInfo.MoveInfo.X[i], unitInfo.MoveInfo.Y[i], unitInfo.MoveInfo.Z[i]));
				     //    }
	        //
				     //    unit.MoveToAsync(list).Coroutine();
			      //   }
		       //  }
	        // }

	        unit.AddComponent<ObjectWait>();

	        // unit.AddComponent<XunLuoPathComponent>(); //mmorpg
	        
	        await Game.EventSystem.PublishAsync(new EventType.AfterUnitCreate() {Unit = unit});
            return unit;
        }

        public static async ETTask<Unit> CreateMonster(Scene currentScene, int configId)
        {
	        UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
	        Unit unit = unitComponent.AddChildWithId<Unit, int>(IdGenerater.Instance.GenerateId(), configId);
	        unitComponent.Add(unit);

	        NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
	        numericComponent.SetNoEvent(NumericType.IsAlive, 1);
	        numericComponent.SetNoEvent(NumericType.DamageValue, unit.Config.DamageValue);
	        numericComponent.SetNoEvent(NumericType.MaxHp, unit.Config.MaxHP);
	        numericComponent.SetNoEvent(NumericType.Hp, unit.Config.MaxHP);

	        unit.AddComponent<ObjectWait>();

	        await Game.EventSystem.PublishAsync(new EventType.AfterUnitCreate() { Unit = unit });
	        return unit;
        }
    }
}

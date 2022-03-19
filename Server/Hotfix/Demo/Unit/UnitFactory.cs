using System;
using UnityEngine;

namespace ET
{
    public static class UnitFactory
    {
        public static Unit Create(Scene scene, long id, UnitType unitType)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            switch (unitType)
            {
                case UnitType.Player:
                {
                    Unit unit = unitComponent.AddChildWithId<Unit, int>(id, 1001);
                    // unit.AddComponent<MoveComponent>(); mmorpg才用得到
                    // unit.Position = new Vector3(-10, 0, -10); mmorpg才用得到
			
                    NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
                    // numericComponent.Set(NumericType.Speed, 6f); // 速度是6米每秒 mmorpg才用得到
                    // numericComponent.Set(NumericType.AOI, 15000); // 视野15米 mmorpg才用得到
                    
                    unitComponent.Add(unit);
                    // 加入aoi
                    // unit.AddComponent<AOIEntity, int, Vector3>(9 * 1000, unit.Position); mmorpg才用得到
                    return unit;
                }
                default:
                    throw new Exception($"not such unit type: {unitType}");
            }
        }
    }
}
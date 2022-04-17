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
                    //ChildType测试代码 取消注释 编译Server.hotfix 可发现报错
                    //unitComponent.AddChild<Player, string>("Player");

                    NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
                    // numericComponent.Set(NumericType.Speed, 6f); // 速度是6米每秒 mmorpg才用得到
                    // numericComponent.Set(NumericType.AOI, 15000); // 视野15米 mmorpg才用得到

                    // UnitConfig unitConfig = UnitConfigCategory.Instance.Get(1001);
                    // numericComponent.SetNoEvent(NumericType.Position, unitConfig.Position);
                    // numericComponent.SetNoEvent(NumericType.Height, unitConfig.Height);
                    // numericComponent.SetNoEvent(NumericType.Weight, unitConfig.Weight);

                    foreach (var config in PlayerNumericConfigCategory.Instance.GetAll())
                    {
                        if (config.Value.BaseValue == 0)
                        {
                            continue;
                        }
                        if (config.Value.BaseValue < 3000) //小于3000的值都用于加成属性推导
                        {
                            int baseKey = config.Key * 10 + 1;
                            numericComponent.SetNoEvent(baseKey, config.Value.BaseValue);
                        }
                        else
                        {
                            //大于3000的值 直接使用
                            numericComponent.SetNoEvent(config.Key, config.Value.BaseValue);
                        }
                    }

                    unitComponent.Add(unit);
                    // 加入aoi
                    // unit.AddComponent<AOIEntity, int, Vector3>(9 * 1000, unit.Position); mmorpg才用得到
                    return unit;
                }
                default:
                    throw new Exception($"not such unit type: {unitType}");
            }
        }

        public static Unit CreateMonster(Scene scene, int configId)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.AddChildWithId<Unit, int>(IdGenerater.Instance.GenerateId(), configId);
            NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
            
            numericComponent.SetNoEvent(NumericType.MaxHp, unit.Config.MaxHP);
            numericComponent.SetNoEvent(NumericType.Hp, unit.Config.MaxHP);
            numericComponent.SetNoEvent(NumericType.DamageValue, unit.Config.DamageValue);
            numericComponent.SetNoEvent(NumericType.IsAlive, 1);
            unitComponent.Add(unit);
            return unit;
        }
    }
}
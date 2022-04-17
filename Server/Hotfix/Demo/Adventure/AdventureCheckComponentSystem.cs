namespace ET
{
    public class AdventureCheckComponentDestorySystem:DestroySystem<AdventureCheckComponent>
    {
        public override void Destroy(AdventureCheckComponent self)
        {
            // self.ResetAdventureInfo();
            foreach (long monsterId in self.CacheEnemyIdList)
            {
                self.DomainScene().GetComponent<UnitComponent>().Remove(monsterId);
            }
            self.CacheEnemyIdList.Clear();
            self.EnemyIdList.Clear();
            self.AnimationTotalTime = 0;
            self.Random = null;
        }
    }

    public static class AdventureCheckComponentSystem
    {
        //设置战斗随机数
        public static void SetBattleRandomSeed(this AdventureCheckComponent self)
        {
            int seed = self.GetParent<Unit>().GetComponent<NumericComponent>().GetAsInt(NumericType.BattleRandomSeed);
            if (self.Random == null)
            {
                self.Random = new SRandom((uint)seed);
            }
            else
            {
                self.Random.SetRandomSeed((uint)seed);
            }
        }

        //创建关卡怪物Unit
        public static void CreateBattleMonsterUnit(this AdventureCheckComponent self)
        {
            int levelId = self.GetParent<Unit>().GetComponent<NumericComponent>().GetAsInt(NumericType.AdventureState);
            //生成最大怪物数量
            BattleLevelConfig battleLevelConfig = BattleLevelConfigCategory.Instance.Get(levelId);
            int monsterCount = battleLevelConfig.MonsterIds.Length - self.CacheEnemyIdList.Count;
            for (int i = 0; i < monsterCount; i++)
            {
                Unit monsterUnit = UnitFactory.CreateMonster(self.DomainScene(), 1002);
                self.CacheEnemyIdList.Add(monsterUnit.Id);
            }
            
            //复用怪物Unit
            self.EnemyIdList.Clear();
            for (int i = 0; i < battleLevelConfig.MonsterIds.Length; i++)
            {
                Unit monsterUnit = self.DomainScene().GetComponent<UnitComponent>().Get(self.CacheEnemyIdList[i]);
                UnitConfig unitConfig = UnitConfigCategory.Instance.Get(battleLevelConfig.MonsterIds[i]);
                monsterUnit.ConfigId = unitConfig.Id;

                NumericComponent numericComponent = monsterUnit.GetComponent<NumericComponent>();
                numericComponent.SetNoEvent(NumericType.MaxHp, monsterUnit.Config.MaxHP);
                numericComponent.SetNoEvent(NumericType.Hp, monsterUnit.Config.MaxHP);
                numericComponent.SetNoEvent(NumericType.DamageValue, monsterUnit.Config.DamageValue);
                numericComponent.SetNoEvent(NumericType.IsAlive, 1);
                self.EnemyIdList.Add(monsterUnit.Id);
            }
        }
        public static bool CheckBattleWinResult(this AdventureCheckComponent self, int totalBattleRound)
        {
            try
            {
                self.ResetAdventureInfo();
                self.SetBattleRandomSeed();
                self.CreateBattleMonsterUnit();
            
            
                // NumericComponent numericComponent = self.GetParent<Unit>().GetComponent<NumericComponent>();
                // int levelId = numericComponent.GetAsInt(NumericType.AdventureState);
                //模拟对战
                // bool isSimulateionNormal = self.SimulationBattle(levelId, totalBattleRound);
                bool isSimulateionNormal = self.SimulationBattle(totalBattleRound);

                if (!isSimulateionNormal)
                {
                    Log.Error("模拟对战失败");
                    return false;
                }
            
                //判定角色是否能在战斗中存活
                // if (self.MonsterTotalDamage >= numericComponent.GetAsInt(NumericType.MaxHp))
                // {
                //     Log.Error("角色无法存活");
                //     return false;
                // }
                if (!self.GetParent<Unit>().IsAlive())
                {
                    Log.Error("玩家未存活");
                    return false;
                }
            
                //判定所有怪物是否被击杀
                if (self.GetFirstAliveEnemy() != null)
                {
                    Log.Error("还有怪物存活");
                    return false;
                }

                // if (self.UnitTotalDamage < self.TotalMonsterHp)
                // {
                //     Log.Error("角色伤害不足");
                //     return false;
                // }
            
                //判定动画战斗时间是否正常
                NumericComponent numericComponent = self.GetParent<Unit>().GetComponent<NumericComponent>();
                long playAnimationTime = TimeHelper.ServerNow() - numericComponent.GetAsLong(NumericType.AdventureStarTime);
                if (playAnimationTime < self.AnimationTotalTime)
                {
                    Log.Error("动画时间不足");
                    return false;
                }
            

                return true;
            }
            finally
            {
                self.ResetAdventureInfo();
            }
            
        }

        //重置冒险关卡信息
        public static void ResetAdventureInfo(this AdventureCheckComponent self)
        {
            // self.Round = 0;
            self.AnimationTotalTime = 0;
            // self.MonsterTotalDamage = 0;
            // self.UnitTotalDamage = 0;
            // self.TotalMonsterHp = 0;
            // self.EnemyHpDictionary.Clear();
            NumericComponent numericComponent = self.GetParent<Unit>().GetComponent<NumericComponent>();
            numericComponent.SetNoEvent(NumericType.Hp, numericComponent.GetAsInt(NumericType.MaxHp));
            numericComponent.SetNoEvent(NumericType.IsAlive, 1);
        }

        public static bool SimulationBattle(this AdventureCheckComponent self, int BattleRound)
        {
            // //创建怪物信息
            // BattleLevelConfig battleLevelConfig = BattleLevelConfigCategory.Instance.Get(levelId);
            // for (int i = 0; i < battleLevelConfig.MonsterIds.Length; i++)
            // {
            //     UnitConfig unitConfig = UnitConfigCategory.Instance.Get(battleLevelConfig.MonsterIds[i]);
            //     self.EnemyHpDictionary.Add(i, unitConfig.MaxHP);
            //     self.TotalMonsterHp += unitConfig.MaxHP;
            // }
            
            //开启模拟对战
            for (int i = 0; i < BattleRound; i++)
            {
                if (i % 2 == 0)
                {
                    //玩家回合
                    // int targetIndex = self.GetFirstAliveEnemyIndex(levelId);
                    // if (targetIndex < 0)
                    // {
                    //     Log.Error($"targetIndex error:{targetIndex}");
                    //     return false;
                    // }
                    //
                    // int damage = self.GetParent<Unit>().GetComponent<NumericComponent>().GetAsInt(NumericType.DamageValue);
                    // self.EnemyHpDictionary[targetIndex] -= damage;
                    // self.UnitTotalDamage += damage;
                    // self.AnimationTotalTime += 1000;
                    Unit monsterUnit = self.GetFirstAliveEnemy();
                    if (monsterUnit == null)
                    {
                        Log.Debug("获取到怪物为空");
                        return false;
                    }

                    self.AnimationTotalTime += 1000;
                    self.CalcuateDamageHpValue(self.GetParent<Unit>(), monsterUnit);
                }
                else
                {
                    //敌人回合
                    // for (int j = 0; j < battleLevelConfig.MonsterIds.Length; j++)
                    // {
                    //     if (self.EnemyHpDictionary[j] <= 0)
                    //     {
                    //         continue;
                    //     }
                    //
                    //     self.MonsterTotalDamage += UnitConfigCategory.Instance.Get(battleLevelConfig.MonsterIds[j]).DamageValue;
                    //     self.AnimationTotalTime += 1000;
                    // }
                    if (!self.GetParent<Unit>().IsAlive())
                    {
                        return false;
                    }

                    for (int j = 0; j < self.EnemyIdList.Count; j++)
                    {
                        Unit monsterUnit = self.DomainScene().GetComponent<UnitComponent>().Get(self.EnemyIdList[j]);
                        if (!monsterUnit.IsAlive())
                        {
                            continue;
                        }

                        self.AnimationTotalTime += 1000;
                        self.CalcuateDamageHpValue(monsterUnit, self.GetParent<Unit>());
                    }
                }

                // ++self.Round;
            }

            return true;
        }
        
        //计算伤害值
        public static void CalcuateDamageHpValue(this AdventureCheckComponent self, Unit attackUnit, Unit targetUnit)
        {
            int Hp = targetUnit.GetComponent<NumericComponent>().GetAsInt(NumericType.Hp);
            Hp = Hp - DamageCalcuateHelper.CalcuateDamageValue(attackUnit, targetUnit, ref self.Random);
            if (Hp <= 0)
            {
                Hp = 0;
                targetUnit.GetComponent<NumericComponent>().SetNoEvent(NumericType.IsAlive, 0);
            }
            targetUnit.GetComponent<NumericComponent>().SetNoEvent(NumericType.Hp, Hp);
        }
        
        //获取存活的怪物
        public static Unit GetFirstAliveEnemy(this AdventureCheckComponent self)
        {
            for (int i = 0; i < self.EnemyIdList.Count; i++)
            {
                Unit monsterUnit = self.DomainScene().GetComponent<UnitComponent>().Get(self.EnemyIdList[i]);
                if (monsterUnit.IsAlive())
                {
                    return monsterUnit;
                }
            }

            return null;
        }
        
        // public static int GetFirstAliveEnemyIndex(this AdventureCheckComponent self, int levelId)
        // {
        //     BattleLevelConfig battleLevelConfig = BattleLevelConfigCategory.Instance.Get(levelId);
        //     for (int i = 0; i < battleLevelConfig.MonsterIds.Length; i++)
        //     {
        //         if (self.EnemyHpDictionary[i] > 0)
        //         {
        //             return i;
        //         }
        //     }
        //
        //     return -1;
        // }
        
    }
    
    
}
namespace ET
{
    public class AdventureCheckComponentDestorySystem:DestroySystem<AdventureCheckComponent>
    {
        public override void Destroy(AdventureCheckComponent self)
        {
            self.ResetAdventureInfo();
        }
    }

    public static class AdventureCheckComponentSystem
    {
        public static bool CheckBattleWinResult(this AdventureCheckComponent self, int totalBattleRound)
        {
            self.ResetAdventureInfo();
            NumericComponent numericComponent = self.GetParent<Unit>().GetComponent<NumericComponent>();
            int levelId = numericComponent.GetAsInt(NumericType.AdventureState);
            //模拟对战
            bool isSimulateionNormal = self.SimulationBattle(levelId, totalBattleRound);

            if (!isSimulateionNormal)
            {
                Log.Error("模拟对战失败");
                return false;
            }
            
            //判定角色是否能在战斗中存活
            if (self.MonsterTotalDamage >= numericComponent.GetAsInt(NumericType.MaxHp))
            {
                Log.Error("角色无法存活");
                return false;
            }

            if (self.UnitTotalDamage < self.TotalMonsterHp)
            {
                Log.Error("角色伤害不足");
                return false;
            }
            
            //判定动画战斗时间是否正常
            long playAnimationTime = TimeHelper.ServerNow() - numericComponent.GetAsLong(NumericType.AdventureStarTime);
            if (playAnimationTime < self.AnimationTotalTime)
            {
                Log.Error("动画时间不足");
                return false;
            }

            return true;
        }

        public static void ResetAdventureInfo(this AdventureCheckComponent self)
        {
            self.Round = 0;
            self.AnimationTotalTime = 0;
            self.MonsterTotalDamage = 0;
            self.UnitTotalDamage = 0;
            self.TotalMonsterHp = 0;
            self.EnemyHpDictionary.Clear();
        }

        public static bool SimulationBattle(this AdventureCheckComponent self, int levelId, int BattleRound)
        {
            //创建怪物信息
            BattleLevelConfig battleLevelConfig = BattleLevelConfigCategory.Instance.Get(levelId);
            for (int i = 0; i < battleLevelConfig.MonsterIds.Length; i++)
            {
                UnitConfig unitConfig = UnitConfigCategory.Instance.Get(battleLevelConfig.MonsterIds[i]);
                self.EnemyHpDictionary.Add(i, unitConfig.MaxHP);
                self.TotalMonsterHp += unitConfig.MaxHP;
            }
            
            //开启模拟对战
            for (int i = 0; i < BattleRound; i++)
            {
                if (self.Round % 2 == 0)
                {
                    //玩家回合
                    int targetIndex = self.GetFirstAliveEnemyIndex(levelId);
                    if (targetIndex < 0)
                    {
                        Log.Error($"targetIndex error:{targetIndex}");
                        return false;
                    }

                    int damage = self.GetParent<Unit>().GetComponent<NumericComponent>().GetAsInt(NumericType.DamageValue);
                    self.EnemyHpDictionary[targetIndex] -= damage;
                    self.UnitTotalDamage += damage;
                    self.AnimationTotalTime += 1000;
                }
                else
                {
                    //敌人回合
                    for (int j = 0; j < battleLevelConfig.MonsterIds.Length; j++)
                    {
                        if (self.EnemyHpDictionary[j] <= 0)
                        {
                            continue;
                        }

                        self.MonsterTotalDamage += UnitConfigCategory.Instance.Get(battleLevelConfig.MonsterIds[j]).DamageValue;
                        self.AnimationTotalTime += 1000;
                    }
                }

                ++self.Round;
            }

            return true;
        }
        
        public static int GetFirstAliveEnemyIndex(this AdventureCheckComponent self, int levelId)
        {
            BattleLevelConfig battleLevelConfig = BattleLevelConfigCategory.Instance.Get(levelId);
            for (int i = 0; i < battleLevelConfig.MonsterIds.Length; i++)
            {
                if (self.EnemyHpDictionary[i] > 0)
                {
                    return i;
                }
            }

            return -1;
        }
        
    }
    
    
}
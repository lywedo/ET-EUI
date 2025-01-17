﻿namespace ET
{
	// 这个可弄个配置表生成
    public static class NumericType
    {
	    public const int Max = 10000;

	    public const int Speed = 1000;
	    public const int SpeedBase = Speed * 10 + 1;
	    public const int SpeedAdd = Speed * 10 + 2;
	    public const int SpeedPct = Speed * 10 + 3;
	    public const int SpeedFinalAdd = Speed * 10 + 4;
	    public const int SpeedFinalPct = Speed * 10 + 5;

	    // public const int Hp = 1001;
	    // public const int HpBase = Hp * 10 + 1;

	    public const int MaxHp = 1002;
	    public const int MaxHpBase = MaxHp * 10 + 1;
	    public const int MaxHpAdd = MaxHp * 10 + 2;
	    public const int MaxHpPct = MaxHp * 10 + 3;
	    public const int MaxHpFinalAdd = MaxHp * 10 + 4;
	    public const int MaxHpFinalPct = MaxHp * 10 + 5;

	    public const int AOI = 1003;
	    public const int AOIBase = AOI * 10 + 1;
	    public const int AOIAdd = AOI * 10 + 2;
	    public const int AOIPct = AOI * 10 + 3;
	    public const int AOIFinalAdd = AOI * 10 + 4;
	    public const int AOIFinalPct = AOI * 10 + 5;

	    public const int DamageValue = 1011; //伤害
	    public const int DamageValueBase = DamageValue * 10 + 1;
	    public const int DamageValueAdd = DamageValue * 10 + 2;
	    public const int DamageValuePct = DamageValue * 10 + 3;
	    public const int DamageValueFinalAdd = DamageValue * 10 + 4;
	    public const int DamageValueFinalPct = DamageValue * 10 + 5;

	    public const int AdditionalDdamage = 1012; //伤害追加

	    public const int Hp = 1013; //生命值
	    public const int HpBase = Hp * 10 + 1;
	    public const int HpAdd = Hp * 10 + 2;
	    public const int HpPct = Hp * 10 + 3;
	    public const int HpFinalAdd = Hp * 10 + 4;
	    public const int HpFinalPct = Hp * 10 + 5;
	    
	    public const int Mp = 1014; 
	    public const int MpBase = Mp * 10 + 1;
	    public const int MpAdd = Mp * 10 + 2;
	    public const int MpPct = Mp * 10 + 3;
	    public const int MpFinalAdd = Mp * 10 + 4;
	    public const int MpFinalPct = Mp * 10 + 5;

	    public const int Armor = 1015; //护甲
	    public const int ArmorBase = Armor * 10 + 1;
	    public const int ArmorAdd = Armor * 10 + 2;
	    public const int ArmorPct = Armor * 10 + 3;
	    public const int ArmorFinalAdd = Armor * 10 + 4;
	    public const int ArmorFinalPct = Armor * 10 + 5;

	    public const int AdditionalArmor = 1016; //护甲追加

	    public const int Dodge = 1017; //闪避
	    public const int DodgeBase = Dodge * 10 + 1;
	    public const int DodgeAdd = Dodge * 10 + 2;
	    public const int DodgePct = Dodge * 10 + 3;
	    public const int DodgeFinalAdd = Dodge * 10 + 4;
	    public const int DodgeFInalPct = Dodge * 10 + 5;

	    public const int Power = 3001; //力量
	    public const int PhysicalStrength = 3002; //体力
	    public const int Agile = 3003; //敏捷值
	    public const int Spirit = 3004; //精神
	    public const int AttributePoint = 3005; //属性点
	    public const int CombatEffectiveness = 3006; //战力值


	    public const int Level = 3007;
	    public const int Gold = 3008;
	    public const int Exp = 3009;
	    public const int Position = 3010;
	    public const int Height = 3011;
	    public const int Weight = 3012;

	    public const int AdventureState = 3010; //关卡冒险状态
	    public const int DyingState = 3011; //垂死状态 1为垂死
	    public const int AdventureStarTime = 3012; //关卡开始冒险的时间
	    public const int IsAlive = 3013; //存活状态 0为死亡 1为活着

	    public const int BattleRandomSeed = 3014; //战斗随机数种子

	    public const int MaxBagCapacity = 3015; //背包最大负重
    }
}

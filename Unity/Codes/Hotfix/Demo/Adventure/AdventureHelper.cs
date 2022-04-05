using System;

namespace ET
{
    public class AdventureHelper
    {
        public static async ETTask<int> RequestStartGameLevel(Scene zoneScene, int levelId)
        {
            M2C_StartGameLevel m2CStartGameLevel = null;
            try
            {
                m2CStartGameLevel = (M2C_StartGameLevel) await zoneScene.GetComponent<SessionComponent>().Session
                        .Call(new C2M_StartGameLevel() { LevelId = levelId });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetorkError;
            }

            if (m2CStartGameLevel.Error != ErrorCode.ERR_Success)
            {
                Log.Error(m2CStartGameLevel.Error.ToString());
                return m2CStartGameLevel.Error;
            }

            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> RequestEndGameLevel(Scene zoneScene, BattleRoundResult battleRoundResult, int Round)
        {
            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }
    }
}
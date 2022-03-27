using System;

namespace ET
{
    public class NumericHelper
    {
        public static async ETTask<int> TestUpdateNumeric(Scene zonScene)
        {
            M2C_TestUnitNumeric m2CTestUnitNumeric = null;
            try
            {
                m2CTestUnitNumeric = (M2C_TestUnitNumeric) await zonScene.GetComponent<SessionComponent>().Session.Call(new C2M_TestUnitNumeric(){});
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetorkError;
            }

            if (m2CTestUnitNumeric.Error != ErrorCode.ERR_Success)
            {
                Log.Error(m2CTestUnitNumeric.Error.ToString());
                return m2CTestUnitNumeric.Error;
            }

            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> RequestAddAttributePoint(Scene zoneScene, int numericType)
        {
            M2C_AddAttributePoint m2CAddAttributePoint = null;
            try
            {
                m2CAddAttributePoint = (M2C_AddAttributePoint) await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2M_AddAttributePoint() { NumericType = numericType });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetorkError;
            }

            if (m2CAddAttributePoint.Error != ErrorCode.ERR_Success)
            {
                Log.Error(m2CAddAttributePoint.Error.ToString());
                return m2CAddAttributePoint.Error;
            }

            return ErrorCode.ERR_Success;
        }
    }
}
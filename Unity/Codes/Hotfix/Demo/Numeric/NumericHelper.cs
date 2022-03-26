﻿using System;

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
    }
}
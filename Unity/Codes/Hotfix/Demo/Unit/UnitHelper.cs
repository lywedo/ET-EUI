﻿namespace ET
{
    public static class UnitHelper
    {
        public static Unit GetMyUnitFromZoneScene(Scene zoneScene)
        {
            PlayerComponent playerComponent = zoneScene.GetComponent<PlayerComponent>();
            Scene currentScene = zoneScene.GetComponent<CurrentScenesComponent>().Scene;
            return currentScene.GetComponent<UnitComponent>().Get(playerComponent.MyId);
        }

        public static Unit GetMyUnitFromCurrentScene(Scene currentScene)
        {
            PlayerComponent playerComponent = currentScene.Parent.Parent.GetComponent<PlayerComponent>();
            if (null == playerComponent)
            {
                return null;
            }

            return currentScene.GetComponent<UnitComponent>().Get(playerComponent.MyId);
        }

        public static NumericComponent GetMyUnitNumericComponent(Scene currentScene)
        {
            return GetMyUnitFromCurrentScene(currentScene).GetComponent<NumericComponent>();
            // return currentScene.Parent.Parent.GetComponent<NumericComponent>();
        }
        
    }
}
using UnityEngine;

namespace ET
{
    public class JoystickAwakeSystem: AwakeSystem<JoystickComponent>
    {
        public override void Awake(JoystickComponent self)
        {
            GameObject.Find("MainCamera")?.SetActive(false);
            GameObject.Find("UICamera")?.SetActive(false);
        }
    }
    public static class JoystickSystem
    {

    }
}
using ET.EventType;
using UnityEngine;

namespace ET
{
    public class CreateJoystickView: AEvent<EventType.CreateJoystick>
    {
        protected override async ETTask Run(CreateJoystick args)
        {
            await ResourcesComponent.Instance.LoadBundleAsync("Joystick.unity3d");
            GameObject bundleGameObject = (GameObject)ResourcesComponent.Instance.GetAsset("Joystick.unity3d", "Joystick");
            GameObject prefab = bundleGameObject.Get<GameObject>("Joystick");
	        
            GameObject go = UnityEngine.Object.Instantiate(prefab, GlobalComponent.Instance.Global, true);
            args.ZoneScene.AddComponent<JoystickComponent>();
            // go.transform.position = args.Unit.Position;
            // args.Unit.AddComponent<GameObjectComponent>().GameObject = go;
            // args.Unit.AddComponent<AnimatorComponent>();
            await ETTask.CompletedTask;
        }
    }
}
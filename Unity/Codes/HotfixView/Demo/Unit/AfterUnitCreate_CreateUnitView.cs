using UnityEngine;

namespace ET
{
    [FriendClass(typeof(GlobalComponent))]
    public class AfterUnitCreate_CreateUnitView: AEventAsync<EventType.AfterUnitCreate>
    {
        protected override async ETTask Run(EventType.AfterUnitCreate args)
        {
            // // Unit View层
            // // 这里可以改成异步加载，demo就不搞了
            // await ResourcesComponent.Instance.LoadBundleAsync("knight.unity3d");
            // // GameObject bundleGameObject = (GameObject)ResourcesComponent.Instance.GetAsset("Unit.unity3d", "Unit");
            // GameObject bundleGameObject = (GameObject)ResourcesComponent.Instance.GetAsset("knight.unity3d", "knight");
            // // GameObject prefab = bundleGameObject.Get<GameObject>("Skeleton");
	           //
            // // GameObject go = UnityEngine.Object.Instantiate(prefab, GlobalComponent.Instance.Unit, true);
            // // go.transform.position = args.Unit.Position;
            // GameObject go = UnityEngine.Object.Instantiate(bundleGameObject);
            // go.transform.SetParent(GlobalComponent.Instance.Unit, true);
            // args.Unit.AddComponent<GameObjectComponent>().GameObject = go;
            // args.Unit.AddComponent<AnimatorComponent>();
            // args.Unit.Position = Vector3.zero;
            await ResourcesComponent.Instance.LoadBundleAsync($"{args.Unit.Config.PrefabName}.unity3d");
            GameObject bundleGameObject =
                    (GameObject) ResourcesComponent.Instance.GetAsset($"{args.Unit.Config.PrefabName}.unity3d", args.Unit.Config.PrefabName);
            GameObject go = UnityEngine.Object.Instantiate(bundleGameObject);
            go.transform.SetParent(GlobalComponent.Instance.Unit, true);
            args.Unit.AddComponent<GameObjectComponent>().GameObject = go;
            args.Unit.AddComponent<AnimatorComponent>();
        }
    }
}
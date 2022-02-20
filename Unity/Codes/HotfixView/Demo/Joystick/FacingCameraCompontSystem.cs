using UnityEngine;

namespace ET
{
    public class FacingCameraCompontAwakeSystem: AwakeSystem<FacingCameraCompont, GameObject>
    {
        public override void Awake(FacingCameraCompont self, GameObject go)
        {
            self.Childs = new Transform[go.transform.childCount];
            for (int i = 0; i < go.transform.childCount; i++)
            {
                self.Childs[i] = go.transform.GetChild(i);
            }
            Log.Debug($"createjoy: {self.Childs.Length}");
        }
    }
    
    public class FacingCameraCompontUpdateSystem:UpdateSystem<FacingCameraCompont>
    {
        public override void Update(FacingCameraCompont self)
        {
            for (int i = 0; i < self.Childs.Length; i++)
            {
                self.Childs[i].rotation = Camera.main.transform.rotation;
            }
        }
    }

    public class FacingCameraCompontSystem
    {
        
    }
}
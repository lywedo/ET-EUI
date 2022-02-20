using UnityEngine;

namespace ET
{
    public class FacingCameraCompont: Entity, IAwake<GameObject>, IUpdate
    {
        public Transform[] Childs;
    }
}
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    public class JoystickComponent : Entity, IAwake<GameObject>, IDestroy, ILateUpdate, IUpdate
    {
        public RectTransform TouchArea;
        public Vector3 BeginPos;
        public bool IsController;
        public Image Rocker;
        public Transform CamTrans;
    }
}
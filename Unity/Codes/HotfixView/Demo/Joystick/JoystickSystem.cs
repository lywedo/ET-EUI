using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    public class JoystickAwakeSystem: AwakeSystem<JoystickComponent, GameObject>
    {
        public override void Awake(JoystickComponent self, GameObject go)
        {
            GameObject.Find("MainCamera")?.SetActive(false);
            GameObject.Find("UICamera")?.SetActive(false);
            self.TouchArea = go.transform.Find("Canvas/Panel/LeftArm").GetComponent<RectTransform>();
            self.Rocker = go.transform.Find("Canvas/Panel/LeftArm/Bg/Center").GetComponent<Image>();
            self.CamTrans = go.transform.Find("TargetCamera").transform;
        }
    }

    public class JoystickUpdateSystem: UpdateSystem<JoystickComponent>
    {
        public override void Update(JoystickComponent self)
        {
            self.Update();
        }
    }

    public static class JoystickSystem
    {
        public static bool IsTouchArea(this JoystickComponent self, RectTransform area, Vector2 position)
        {
            Vector2 rectSize = area.parent.parent.GetComponent<RectTransform>().rect.size;
            Vector3 localPosition = area.localPosition;
            // Debug.Log($"{name} positon{position} localPosition:{localPosition} ");
            Vector3 areaLocalPosition = localPosition;
            float scale = rectSize.x / Screen.width;
            float touchX = position.x - Screen.width / 2;
            float touchY = position.y - Screen.height / 2;
            touchX = touchX * scale;
            touchY = touchY * scale;
            if (touchX > areaLocalPosition.x - area.rect.width / 2 && touchX < areaLocalPosition.x + area.rect.width / 2)
            {
                if (touchY > areaLocalPosition.y - area.rect.height / 2 && touchY < areaLocalPosition.y + area.rect.height / 2)
                {
                    return true;
                }
            }

            return false;
        }

        public static void Update(this JoystickComponent self)
        {
            if (Input.GetMouseButtonDown(0) &&
                self.IsTouchArea(self.TouchArea, Input.mousePosition))
            {
                self.BeginPos = Input.mousePosition;
                self.IsController = true;
            }
            else if (Input.GetMouseButton(0) && self.IsController)
            {
                //通过运算并normalized后求出两点之间的方向
                Vector3 vector = Input.mousePosition - self.BeginPos;
                vector = vector.normalized;

                //这里先是求出两点之间的距离 并且同mathf.Clamp进行一个范围的限制，然后在把这个距离与vector 两点之间的方向相乘 得出点点所在的位置
                self.Rocker.transform.localPosition =
                        Mathf.Clamp(Vector3.Distance(self.BeginPos, Input.mousePosition), 0, 80f) * vector;
                // if (null != onDragCb)
                self.OnDragCb(new Vector2(vector.x, vector.y));
            }
            else if (Input.GetMouseButtonUp(0) && self.IsController)
            {
                self.IsController = false;
                //鼠标抬起后 点点回到中间 关闭摇杆盘 初始化beginPos
                // beginPos = Vector3.zero;
                // Debug.Log($"up {name} {beginPos} {Input.mousePosition}");
                self.Rocker.transform.localPosition = Vector3.zero;
                // if (null != onStopCb)
                self.OnStopCb();
                // rocker.transform.parent.gameObject.SetActive(false);
            }
        }

        public static void OnDragCb(this JoystickComponent self, Vector2 direction)
        {
            Vector4 realDirect = self.CamTrans.localToWorldMatrix * new Vector3(direction.x, 0, direction.y);
            realDirect.y = 0;
            realDirect = realDirect.normalized;
            // player.Move(realDirect);
        }

        public static void OnStopCb(this JoystickComponent self)
        {
            // player.Stand();
        }
    }
}
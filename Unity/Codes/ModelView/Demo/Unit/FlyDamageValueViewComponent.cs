using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public class FlyDamageValueViewComponent: Entity, IAwake, IDestroy
    {
        public HashSet<GameObject> FlyingDamageSet = new HashSetComponent<GameObject>();
    }
}
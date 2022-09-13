using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using UnityGameFramework.Runtime;
public class HeroLogic : EntityLogic
{
    protected override void OnShow(object userData)
    {
        base.OnShow(userData);
        GameFrameworkLog.Debug("打印英雄实体");
    }
}

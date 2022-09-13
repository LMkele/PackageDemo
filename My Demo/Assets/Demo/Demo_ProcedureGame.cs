using System.Collections;
using System.Collections.Generic;
using GameFramework;
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;
using GameFramework.Event;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
public class Demo_ProcedureGame : ProcedureBase
{
    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);
        EntityComponent entity = UnityGameFramework.Runtime.GameEntry.GetComponent<EntityComponent>();
        entity.ShowEntity<EntityLogic>(1, "Assets/Demo/HeroCube", "Hero");
        GameFrameworkLog.Debug("Hero is {0}", entity);
    }
}

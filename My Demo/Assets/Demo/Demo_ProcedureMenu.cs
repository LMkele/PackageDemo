using System.Collections;
using System.Collections.Generic;
using GameFramework;
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;
using GameFramework.Event;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

public class Demo_ProcedureMenu : ProcedureBase
{
    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);
        EventComponent Event = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>();
        
        UIComponent ui = UnityGameFramework.Runtime.GameEntry.GetComponent<UIComponent>();
        Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
        ui.OpenUIForm("Assets/Demo/demoUI.prefab", "defaultGroup", this);
    }
    private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
    {
        OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
        if (ne.UserData != this)
        {
            GameFrameworkLog.Debug("fail");
            return;
        }
        string message = Utility.Text.Format("UserData =  {0}.", ne.UserData);
        GameFrameworkLog.Debug(message);
    }
    protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
    {
        base.OnLeave(procedureOwner, isShutdown);
        ChangeState<Demo_ProcedureGame>(procedureOwner);
        EventComponent Event = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>();
        Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
        UIComponent ui = UnityGameFramework.Runtime.GameEntry.GetComponent<UIComponent>();
        ui.CloseAllLoadedUIForms();
    }
}


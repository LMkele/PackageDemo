using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.Event;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameFramework.Resource
{
    public class AssignmentModel : ProcedureBase
    {
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            EventComponent Event = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>();
            Event.Subscribe(WebRequestSuccessEventArgs.EventId, initAssignment);
            Event.Subscribe(WebRequestFailureEventArgs.EventId, requestFail);
            Event.Subscribe(PackageItemChange.EventId, changeItems);
            WebRequestComponent webRequest = UnityGameFramework.Runtime.GameEntry.GetComponent<WebRequestComponent>();
            string url = "任务请求地址";
            webRequest.AddWebRequest(url, this);
        }
        /// <summary>
        /// 任务初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void initAssignment(object sender, GameEventArgs e)
        {

        }
        public void requestFail(object sender, GameEventArgs e)
        {

        }
        public void changeItems(object sender, GameEventArgs e)
        {
            
        }
        public struct Assignment
        {
            int AssID; // 任务ID
            string AssName; //任务名称
            string AssDescribe;//任务描述
            int[] AssNeedID;//任务需求id
            int[] AssNeedNum;//任务需求数量
            int[] AssRewardId;//任务奖励id
            int[] AssRewardNum;//任务奖励数量
            public int ID
            {
                get
                {
                    return AssID;
                }
            }
            public string Name
            {
                get
                {
                    return AssName;
                }
            }
            public string Describe
            {
                get
                {
                    return AssDescribe;
                }
            }
            public int[] NeedID
            {
                get
                {
                    return AssNeedID;
                }
            }
            public int[] NeedNum
            {
                get
                {
                    return AssNeedNum;
                }
            }
            public int[] RewardId
            {
                get
                {
                    return AssRewardId;
                }
            }
            public int[] RewardNum
            {
                get
                {
                    return AssRewardNum;
                }
            }
        }
    }
}
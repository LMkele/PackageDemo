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
        public Assignment assignment;
        public List<Assignment> assList;
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
            //根据任务列表和当前任务ID初始化任务
        }
        public void requestFail(object sender, GameEventArgs e)
        {
            //请求失败
        }
        public void changeItems(object sender, GameEventArgs e)
        {
            PackageItemChange packageItemChange = (PackageItemChange)e;
            var changeItem = packageItemChange.changeItem;
            var changeId = new List<int>();
            var changeNum = new List<int>();
            for (var t = 0; t < changeItem.Count; t++)
            {
                changeId.Add(changeItem[t].Id);
                changeNum.Add(changeItem[t].Num);
            }
            if (changeItem.Count <= 0)
            {
                return;
            }
            List<int> needId = assignment.NeedID;
            List<int> needNum = assignment.NeedNum;
            for (var j = 0; j < needId.Count; j++)
            {
                for (var i = 0; i < changeId.Count; i++)
                {
                    if (needId[j] == changeItem[i].Id)
                    {
                        needNum[i] = changeItem[i].Num;
                    }
                }
            }
        }
        public List<Assignment> getAssignmentList()
        {
            return assList;
        }
        public Assignment? getAssignmentById(int Id)
        {
            for (var i = 0; i < assList.Count; i++)
            {
                if (Id == assList[i].ID)
                {
                    return assList[i];
                }
            }
            return null;
        }
        public struct Assignment
        {
            int AssID; // 任务ID
            string AssName; //任务名称
            string AssDescribe;//任务描述
            List<int> AssNeedID;//任务需求id
            List<int> AssNeedNum;//任务需求数量
            List<int> AssRewardId;//任务奖励id
            List<int> AssRewardNum;//任务奖励数量
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
            public List<int> NeedID
            {
                get
                {
                    return AssNeedID;
                }

            }
            public List<int> NeedNum
            {
                get
                {
                    return AssNeedNum;
                }
                set
                {
                    AssNeedNum = value;
                }
            }
            public List<int> RewardId
            {
                get
                {
                    return AssRewardId;
                }
            }
            public List<int> RewardNum
            {
                get
                {
                    return AssRewardNum;
                }
            }
        }
    }
}
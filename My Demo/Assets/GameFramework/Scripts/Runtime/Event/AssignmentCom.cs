using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.Event;

namespace GameFramework.Resource
{
    public class AssignmentCom : GameEventArgs
    {
        public static readonly int EventId = typeof(AssignmentCom).GetHashCode();
        public override int Id
        {
            get
            {
                return EventId;
            }
        }
        public List<int> changeId
        {
            get;
            private set;
        }
        public List<int> changeNum
        {
            get;
            private set;
        }
        /// <summary>
        /// 存储道具ID和道具数量数组,相同的id与数量的index对应
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Nums"></param>
        /// <returns></returns>
        public static AssignmentCom Create(List<int> Id, List<int> Nums)
        {
            AssignmentCom assignmentCom = ReferencePool.Acquire<AssignmentCom>();
            assignmentCom.changeId = Id;
            assignmentCom.changeNum = Nums;
            return assignmentCom;
        }
        public override void Clear()
        {

        }
    }
}



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
        public List<item> changeItem
        {
            get;
            private set;
        }

        /// <summary>
        /// items包含道具Id和道具数量
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static AssignmentCom Create(List<item> items)
        {
            AssignmentCom assignmentCom = ReferencePool.Acquire<AssignmentCom>();
            assignmentCom.changeItem = items;
            return assignmentCom;
        }
        public struct item
        {
            int itemId;
            int itemNum;
            public int Id
            {
                get
                {
                    return itemId;
                }
            }
            public int Num
            {
                get
                {
                    return itemNum;
                }
            }
        }
        public override void Clear()
        {

        }
    }
}



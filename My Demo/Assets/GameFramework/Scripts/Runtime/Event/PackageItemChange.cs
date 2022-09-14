using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.Event;

namespace GameFramework.Resource
{
    public class PackageItemChange : GameEventArgs
    {
        public static readonly int EventId = typeof(PackageItemChange).GetHashCode();
        public override int Id
        {
            get
            {
                return EventId;
            }
        }
        public int[] changeId
        {
            get;
            private set;
        }
        public int[] changeNum
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
        public static PackageItemChange Create(int[] Id, int[] Nums)
        {
            PackageItemChange packageItemChange = ReferencePool.Acquire<PackageItemChange>();
            packageItemChange.changeId = Id;
            packageItemChange.changeNum = Nums;
            return packageItemChange;
        }
        public override void Clear()
        {

        }
    }
}



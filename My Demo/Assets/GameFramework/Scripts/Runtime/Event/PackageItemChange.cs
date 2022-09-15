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
        public List<item> changeItem
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
        public static PackageItemChange Create(List<item> items)
        {
            PackageItemChange packageItemChange = ReferencePool.Acquire<PackageItemChange>();
            packageItemChange.changeItem = items;
            return packageItemChange;
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



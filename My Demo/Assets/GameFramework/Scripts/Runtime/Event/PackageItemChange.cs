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
        /// items包含道具Id和道具数量
        /// </summary>
        /// <param name="items"></param>
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



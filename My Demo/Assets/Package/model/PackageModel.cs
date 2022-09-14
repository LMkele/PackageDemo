using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.Event;
using GameFramework;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameFramework.Resource
{

    public class PackageModel : ProcedureBase
    {
        public static List<item> itemList;
        // Start is called before the first frame update
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            itemList = new List<item>();
            EventComponent Event = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>();
            Event.Subscribe(PackageItemChange.EventId, changeItems);
        }
        public void changeItems(object sender, GameEventArgs e)
        {
            PackageItemChange packageItemChange = (PackageItemChange)e;
            var changeId = packageItemChange.changeId;
            var changeNum = packageItemChange.changeNum;
            int itemLength = itemList.Count;
            for (int j = 0; j < changeId.Length; j++)
            {
                for (int i = 0; i < itemLength; i++)
                {
                    if (changeId[j] == itemList[i].ID)
                    {
                        itemList[i].Num = changeNum[j];
                    }
                }
            }

        }
        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {

        }
        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
            EventComponent Event = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>();
            Event.Unsubscribe(PackageItemChange.EventId, changeItems);
        }
        public List<item> getItemList()
        {
            return itemList;
        }
        public item? getItemListById(int Id)
        {
            var id = Id;
            for (var i = 0; i < itemList.Count; i++)
            {
                if (itemList[i].ID == id)
                {
                    return itemList[i];
                }
            }
            return null;
        }
        public List<item>? getItemsListById(int[] Id)
        {
            var id = Id;
            List<item> items = new List<item>();
            for (var j = 0; j < id.Length; j++)
            {
                for (var i = 0; i < itemList.Count; i++)
                {
                    if (itemList[i].ID == id[j])
                    {
                        items.Add(itemList[i]);
                    }
                }
            }
            if (items.Count > 0)
            {
                return items;
            }
            else
            {
                return null;
            }
        }
        public void setItemList(List<item> item)
        {
            itemList = item;
        }
        public struct item
        {
            private int itemID;
            private int itemNum;
            private string itemName;
            private string itemDescribe;
            public int ID
            {
                get
                {
                    return itemID;
                }
                set
                {
                    itemID = value;
                }
            }
            public int Num
            {
                get
                {
                    return itemNum;
                }
                set
                {
                    itemNum = value;
                }
            }
            public string Name
            {
                get
                {
                    return itemName;
                }
            }
            public string Describe
            {
                get
                {
                    return itemDescribe;
                }
            }
        }
    }
}


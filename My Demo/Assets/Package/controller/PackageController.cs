using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFramework.Resource
{
    public struct item { }
    public class PackageController : MonoBehaviour
    {
        public PackageModel model;
        public PackageView view;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public List<item> getItemList()
        {
            return model.getItemList();
        }
        public List<item> getItemListById(int id)
        {
            return model.getItemListById(id);
        }
        public List<item> getItemsListById(int[] id)
        {
            return model.getItemsListById(id);
        }
        public void setItemList(List<item> item)
        {
            model.setItemList(item);
        }
    }
}
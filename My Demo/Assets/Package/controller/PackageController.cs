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
        public void getItemList()
        {
            model.getItemList();
        }
        public void getItemListById(int id)
        {
            model.getItemListById(id);
        }
        public void getItemsListById(List<int> id)
        {
            model.getItemsListById(id);
        }
        public void setItemList(List<item> item)
        {
            model.setItemList(item);
        }
    }
}
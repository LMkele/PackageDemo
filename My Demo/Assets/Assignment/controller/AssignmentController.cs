using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameFramework.Resource
{
    public class AssignmentController : MonoBehaviour
    {
        public AssignmentModel Model;
        public AssignmentView View;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void getAssignmentList()
        {
            Model.getAssignmentList();
        }
        public void getAssignmentById()
        {
            Model.getAssignmentList();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
  this.transform.localScale = new Vector3(1 + Mathf.Sin(Time.time), 1 + Mathf.Sin(Time.time), 1 + Mathf.Sin(Time.time));
    }
}
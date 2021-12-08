using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWarden : MonoBehaviour
{
   void Update()
   {
      DontDestroyOnLoad(this.gameObject);
      Debug.Log("saved Game object:" + gameObject.tag);
      if (this.gameObject.tag == "MainCamera")
      {
         //DontDestroyOnLoad(this.gameObject.);
      }
   }
}

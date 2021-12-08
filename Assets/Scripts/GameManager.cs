using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool ExitDoorBool;
    //public static GameManager Instance;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    void ExitDoorDebugManager()
    {
        if (ExitDoorBool == true)
        {
            Debug.Log("Loading New Scene");
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

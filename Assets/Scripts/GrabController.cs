using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public BoxScript BoxBool;
    //public transform variable to assign an empty game object to
    [Space]
    public Transform grabFunc;
    //identifies parent script PlayerController and defines it as "ParentRef"
    private PlayerController ParentRef;
    //This creates a pass over field for the box to be placed in when the player grabs it
    public GameObject grabbedObject;
    //public transform variable to assign an empty game object to
    //public float ParentRef;
    [Header("Box Values")]public Transform boxHolder;
    //Public float to define that distance that the ray will travel
    [Range(0,4)]public float rayDist;
    // Start is called before the first frame update
    public LayerMask boxLayer;
    
    // Update is called once per frame

    void Start()
    {
        BoxBool = GameObject.FindObjectOfType<BoxScript>();
        //Calls ParentRef and assigns the player controller to ParentRef
        ParentRef = GameObject.FindObjectOfType<PlayerController>();
    }

    void Update()
    {
       // Debug.Log("Key Count = " + keyCount);
        //using a Raycast to check the distance between the players grab object and the object being grabbed
        //Then allowing the grabbed object to flip dependant on the local scale of the player character
        RaycastHit2D grabCheck = Physics2D.Raycast(grabFunc.position, Vector2.right * transform.localScale, rayDist, boxLayer);
        Debug.DrawRay(grabFunc.position, Vector2.right * rayDist* transform.localScale , Color.blue);
        //checks if collider is hitting something and if the object grabbed has the tag "Box"
        if (grabCheck.collider != null && grabCheck.collider.tag == "" + "Box")
        {
            // check if the key E is being pressed
            if (Input.GetKeyDown(KeyCode.E) )
            {
                if (grabbedObject == null)
                {
                    Debug.Log("picked up box");
                    //Activates a bool check in the box script for it to know the player has the box
                    BoxBool.hasBox = true;
                    //Sets grabbedObject as the game object that has been hit by the raycast
                    grabbedObject = grabCheck.collider.gameObject;
                    //Assigns the boxHolder empty object as a parent to the Box
                    grabCheck.collider.gameObject.transform.parent = boxHolder;
                    //Keeps the Box in the same position as the boxHolder Game object to avoid problems with collision boxes
                    grabCheck.collider.gameObject.transform.position = boxHolder.position;
                    // This stops gravity from affecting the box so it can be moved
                    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                    //set player to walk speed
                    ParentRef.activeSpeed = ParentRef.walkSpeed;
                }
                else
                {

                    Debug.Log("dropped box");
                    BoxBool.hasBox = false;
                    //Remove the boxHolder parent from the game object
                    grabbedObject.transform.parent = null;
                    // allow gravity to take effect again
                    grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                    //boxInHand = false;
                    grabbedObject = null;
                    //sets the variable activeSpeed to the value of running speed in the parent script
                    ParentRef.activeSpeed = ParentRef.runningSpeed;
                }
            }
        }

    }
}

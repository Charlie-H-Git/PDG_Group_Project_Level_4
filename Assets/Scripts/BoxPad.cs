using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPad : MonoBehaviour
{
    public ExitDoor doorRef;
    public BoxScript boxRef;
    public float rayDist = 0.5f;
    

    // Start is called before the first frame update
    void Start()
    {
        boxRef = GameObject.FindObjectOfType<BoxScript>();
        doorRef = GameObject.FindObjectOfType<ExitDoor>();
       
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(boxRef.spriteRenderer.sprite);
        Vector2 position = transform.position;
        Vector2 direction = Vector2.up;
        RaycastHit2D Boxpad = Physics2D.Raycast(position, direction, rayDist);
        Debug.DrawRay(position,direction * rayDist, Color.red);

        if (Boxpad.collider != null && boxRef.Blue == true)
        {
            //Debug.Log("Correct Box Has Been Placed");
            doorRef.correctBox = true;
        }else if (Boxpad.collider != null && boxRef.White == true)
        {
            doorRef.correctBox = true;
            
        }else if (Boxpad.collider != null && boxRef.Orange == true)
        {
            doorRef.correctBox = true;
        }else if (Boxpad.collider != null && boxRef.Yellow)
        {
            doorRef.correctBox = true;
        }else if (Boxpad.collider != null  && boxRef.Purple)
        {
            doorRef.correctBox = true;
        }
    }
}

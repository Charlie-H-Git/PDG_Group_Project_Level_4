using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class ColourChanger : MonoBehaviour
{
    [Range(0f,2f)]public float RayDist = 7f;
    public bool Blue;
    public bool White;
    public bool Orange;
    public bool Purple;
    public bool Yellow;
    private BoxScript boxRef;
    public LayerMask boxLayerMask;
    public GameObject RayStart;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = FindObjectOfType<SpriteRenderer>();
        boxRef = GameObject.FindObjectOfType<BoxScript>();
    }

    void boxCheck()
    {
        Vector2 position = RayStart.transform.position;
        Vector2 direction = Vector2.down;
        Debug.DrawRay(position, direction * RayDist, Color.blue);
        RaycastHit2D door = Physics2D.Raycast(position, direction * RayDist, boxLayerMask);
        if (Blue == true && door.collider.tag == "Box")
        {
            //Debug.Log("Box Detected turning box blue");
            boxRef.spriteRenderer.sprite = boxRef.boxArray[1];
            
        }

        else if (White == true && door.collider.tag == "Box")
        {
            //Debug.Log("Box Detected Change box White");
            boxRef.spriteRenderer.sprite = boxRef.boxArray[0];

        }
        else if (Orange == true && door.collider.tag == "Box")
        {
            //Debug.Log("Box Detected Change box Orange");
            boxRef.spriteRenderer.sprite = boxRef.boxArray[2];
        }
        else if (Purple && door.collider.tag == "Box")
        {
            boxRef.spriteRenderer.sprite = boxRef.boxArray[3];
        }
        else if (Yellow && door.collider.tag == "Box")
        {
            boxRef.spriteRenderer.sprite = boxRef.boxArray[4];
        }
    }

    
    
    
    void Update()
    {
        boxCheck();
    }
    
}


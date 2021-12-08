using System;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Collider col;
    private PlayerController PlyrRef;
    public Rigidbody2D rb;
    public Transform Pos1, Pos2;
    public float platformSpeed = 3f;
    public Transform startPos;
    private Vector3 nextPos;
    
    void start()
    {
        PlyrRef = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider>();
        nextPos = startPos.position;
       
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        
        if (other.collider.CompareTag("Player"))
        {
            Debug.Log("Player has been parented");
            other.gameObject.transform.parent = this.gameObject.transform;
            
        }
        if (other.collider.CompareTag("Box"))
        {
            //Debug.Log("Box is on platform");
            other.gameObject.transform.parent = this.gameObject.transform;
          
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag(("Player")))
        {
            Debug.Log("Player has been Un-parented");
            other.gameObject.transform.parent = null;
            
        }

        if (other.collider.CompareTag("Box"))
        {
           //Debug.Log("Box has left platform");
           //other.gameObject.transform.parent = null;
          
        }
    }

    void FixedUpdate()
    {

        if (transform.position == Pos1.position)
        {
            nextPos = Pos2.position;
        }
        if(transform.position == Pos2.position)
        {
            nextPos = Pos1.position;
        }

        transform.position = (Vector3.MoveTowards(transform.position, nextPos, platformSpeed*Time.deltaTime));
       
    }

    
}

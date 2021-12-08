using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class PlayerController : MonoBehaviour
{
    public BoxScript BoxScript;
    private Collider2D playCol;
    private Rigidbody2D rb;
    private bool isFalling;
    [Header("Jump Force Settings")]
    public float ActiveJumpForce;
    public float withBoxJumpForce = 0f;
    public float JumpForce = 10f;
    public float Downforce = 2.5f;
    public float StaticGravity = 1f;
    [Header("Running Speed Settings")]
    public float runningSpeed = 5f;
    public float activeSpeed = 0f;
    public float walkSpeed = 2f;
    [Header("Jumping Options")]
    public float Raydist = 1.0f;
    public LayerMask platform;
    public LayerMask movingplatform;
    // Start is called before the first frame update
    void Start()
    {
        //BoxScript = GetComponent<BoxScript>();
        playCol = FindObjectOfType<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        activeSpeed = runningSpeed;
        ActiveJumpForce = JumpForce;
    }

    void Update()
    {
        if (rb.velocity.y < -1f)
        {
            isFalling = true;
            //Debug.Log("isFalling True");
        }
        else
        {
            isFalling = false;
        }

        if (isFalling)
        { 
            //Debug.Log("Adding Gravity");
            rb.gravityScale = Downforce;
        }

      
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(playCol.IsTouchingLayers(11))
        {
            gameObject.transform.SetParent(transform); 
        }
        
    }


    //Private bool declaring IsGrounded
    bool IsGrounded()
    {
        //Finds the location of parent object for the raycast function
        Vector2 position = transform.position;
        //defines the direction of the raycast downwards
        Vector2 direction = Vector2.down;
        //draws a line in the unity editor to represent the raycast
        Debug.DrawRay(position, direction*Raydist, Color.green);
        //Performs the raycast with the predefined conditions above
        RaycastHit2D hit = Physics2D.Raycast(position, direction, Raydist, platform);
        //if the ray hits a collider it returns a true value to the bool and if not then returns false
        if (hit.collider != null )
        {
            rb.gravityScale = 1f;
            return true;
        }
        return false;
            
    }
    
    private void FixedUpdate()
    {
        Vector2 yVal = transform.position;
        // An if statement that checks if IsGrounded= true and  the "jump" key is used 
        if (IsGrounded() && Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, ActiveJumpForce));
        }
        if (IsGrounded() && BoxScript.hasBox && Input.GetKey(KeyCode.Space))
        {
            ActiveJumpForce = withBoxJumpForce;
            //Debug.Log("Player has box, BoxJumpForce Applied!");
            rb.AddForce(new Vector2(0f, ActiveJumpForce));
        }else if (IsGrounded() && BoxScript.hasBox == false && Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("Resetting Active jump force");
            ActiveJumpForce = JumpForce;
        }
        //assigns the horizontal Movement Axis to the float name move
        float move = Input.GetAxis("Horizontal");
        //Rounds the float value to -1 or +1 regardless of true value
        float direction = Mathf.Sign(move);

        if (move != 0f)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = direction;
            transform.localScale = localScale;
        }
        
        Vector2 velocity = rb.velocity;
        velocity.x = move * activeSpeed;
        rb.velocity = velocity;
        
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{

    public Camera cam;
    public float parallaxMultiplierX; 
    public float parallaxMultiplierY;
    private float length, startposX; //Call sizeX of Parallax Background
    private float height, startposY; //Call sizeY of Parallax Background
    
    void Start()
    {
        cam = Camera.main;
        startposX = transform.position.x;
        startposY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distX = (cam.transform.position.x * parallaxMultiplierX); 
        float distY = (cam.transform.position.y * parallaxMultiplierY);

        transform.position = new Vector3(startposX + distX, startposY + distY, transform.position.z);
//uses cam position times the Parallax multiplier
    }
}

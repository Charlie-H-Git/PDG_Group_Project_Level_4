using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class BoxScript : MonoBehaviour
{   
     BoxCollider2D ColRef;
     GameObject box;
     public SpriteRenderer spriteRenderer;
     Light2D lightRef;
    public Sprite[] boxArray;
    
    [Header("Debug Boolean")]public bool White = false;
    public bool Blue = false;
    public bool Orange = false;
    public bool Purple = false;
    public bool Yellow = false;
    public bool hasBox;
    
    [Header("Box Light Intensity")] [Range(0f,1f)]public float orangeIntensity = 0f;
        
    [Range(0f,1f)]public float blueIntensity = 0f;

    [Range(0f,1f)]public float whiteIntensity = 0f;

    [Range(0f, 1f)] public float purpleIntensity = 0f;

    [Range(0f, 1f)] public float yellowIntensity = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
        ColRef = gameObject.GetComponentInChildren<BoxCollider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        lightRef = gameObject.GetComponentInChildren<Light2D>();
                
    }

    void lightColour()
    {
        if (spriteRenderer.sprite == boxArray[0])
        {
            lightRef.intensity = whiteIntensity;
            lightRef.color = Color.white;
            White = true;
            Blue = false;
        }else if (spriteRenderer.sprite == boxArray[1])
        {
            lightRef.intensity = blueIntensity;
            lightRef.color = Color.blue;
            Blue = true;
            White = false;
        }else if (spriteRenderer.sprite == boxArray[2])
        {
            lightRef.intensity = orangeIntensity;
            lightRef.color = new Color(255, 165, 0);
            Blue = false;
            White = false;
            Orange = true;
        }else if (spriteRenderer.sprite == boxArray[3])
        {
            lightRef.intensity = purpleIntensity;
            lightRef.color = new Color(138, 17, 215);
            Blue = false;
            White = false;
            Orange = false;
            Purple = true;
        }else if (spriteRenderer.sprite == boxArray[4])
        {
            lightRef.intensity = yellowIntensity;
            lightRef.color = new Color(199, 222, 8);
            Blue = false;
            White = false;
            Orange = false;
            Purple = false;
            Yellow = true;
        }
    }

    
    void Update()
    {
        lightColour();
    }
}

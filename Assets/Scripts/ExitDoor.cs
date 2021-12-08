using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [Header(" ")]public GameObject Player;
    public Scene targetScene;
    public bool correctBox = false;
    [Range(0f,2f)]public float RayDist = 1f;
    public GameObject RayStart;
    public Sprite[] doorSprite;
    // Start is called before the first frame update
    void start()
    {
        //Gm = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 position = RayStart.transform.position;
        Vector2 direction = Vector2.down;
        RaycastHit2D ExitDoor = Physics2D.Raycast(position,direction * RayDist);
        Debug.DrawRay(position,direction*RayDist, Color.cyan);

        if (ExitDoor.collider.tag == "Player" && correctBox == true)
        {
            //Gm.ExitDoorBool = true;
           // Player.transform.position = new Vector3(spawnX, spawnY);
            SceneManager.LoadScene(targetScene.handle);
            //spriteRenderer.sprite = doorSprite[2];
        }
    }
}

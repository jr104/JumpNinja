using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float runSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private Sprite leftNinja;
    [SerializeField] private Sprite rightNinja;

    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode run;
    [SerializeField] private KeyCode jump;
    private SpriteRenderer playerSprite;
    private Rigidbody2D playerRB;
    private bool jumping = true;
    // Start is called before the first frame update
    void Start()
    {
        playerSprite = player.GetComponent<SpriteRenderer>();
        playerRB = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(left))
        {
            playerSprite.sprite = leftNinja;
            if (Input.GetKey(run))
            {
                playerRB.velocity = new Vector2(-runSpeed, playerRB.velocity.y);
            }
            else {
                playerRB.velocity = new Vector2(-walkSpeed, playerRB.velocity.y);
                //player.position = new Vector2(player.position.x - walkSpeed, player.position.y);
            }
           
        }
        if (Input.GetKey(right))
        {
            playerSprite.sprite = rightNinja;
            if (Input.GetKey(run))
            {
                playerRB.velocity = new Vector2(runSpeed, playerRB.velocity.y);
            }
            else
            {
                playerRB.velocity = new Vector2(walkSpeed, playerRB.velocity.y);
            }
        }

        if (Input.GetKeyDown(jump))
        {

            if (jumping) {

                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpHeight);
                jumping = false;
            }
           
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Ground")
        {
            jumping = true;
        }
    }
}

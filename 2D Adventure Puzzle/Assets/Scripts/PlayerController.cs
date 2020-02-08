using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float characterSpeed = 5.0f;
    [SerializeField] float jumpPower = 5.0f;
    [SerializeField] float localScale = 5.0f;
    [SerializeField] GameObject deathEffect;
    [SerializeField] GameManager gm;
    public AudioSource jumpSound;


    private Animator myAnimator;
    public bool onGround = true;
    public new Rigidbody2D rigidbody;
    private CapsuleCollider2D body;
    private BoxCollider2D feet;
    public Vector2 respawnPosition;
    public bool respawnCoActive;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        rigidbody.GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        body = GetComponent<CapsuleCollider2D>();
        feet = GetComponent<BoxCollider2D>();
        respawnPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Function to move the player
        MainMovement();

        //Check if the player is on the ground
        if (!feet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            //If not on ground does nothing
            return;
        }
            MainJump();
           



    }

    public void MainMovement()
    {
        //Check if the player move right
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            //Move right
            rigidbody.velocity = new Vector2(characterSpeed, rigidbody.velocity.y);
            //Rotate the char depending of the side
            transform.localScale = new Vector2(localScale, localScale);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            //Move left
            rigidbody.velocity = new Vector2(-characterSpeed, rigidbody.velocity.y);
            //Rotate the char depending of the side
            transform.localScale = new Vector2(-localScale, localScale);
        }
        else
        // If no movement
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }
        //Value of the animator
        myAnimator.SetFloat("Speed", Mathf.Abs(rigidbody.velocity.x));
        myAnimator.SetBool("onGround", onGround);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "deathzone")
        {
            gm.Respawn();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "boss")
        {
            gm.Respawn();
        }
    }

    private void MainJump()
    {
        //Moment the key is press
        if (Input.GetButtonDown("Jump"))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpPower);
            jumpSound.Play();
        }
    }



}

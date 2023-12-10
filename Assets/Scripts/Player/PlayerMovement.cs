using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int jumpheight;
    public int speed;
    public bool isFacingLeft = false;
    public bool isGrounded;
    public float lastGrounded;
    public float jumpExtensionTime = 0.1f;
    
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private LayerMask jumpableObject;
    Rigidbody2D body;
    SpriteRenderer sprite;
    
    private Animator anim;
    private BoxCollider2D coll;
    private enum MovementState {idle, running, jumping, falling}
    private MovementState movementState;
    private float dirx;
    
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        Debug.Log(coll.bounds.size);
    }

    void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");
        isGrounded = IsGrounded();
       
        if(CanJump()){
            body.velocity = new Vector3(body.velocity.x,jumpheight,0);
        }

        UpdateAnimationState();
    }

    private void FixedUpdate() {
        body.velocity = new Vector2(speed*dirx, body.velocity.y);
    }

    private void UpdateAnimationState () {
        if(dirx > 0f) {
            movementState = MovementState.running;
            sprite.flipX = false;
            // transform.rotation = new Quaternion(transform.rotation.x,0,transform.rotation.z,transform.rotation.w);
            // body.rotation = 0;
            isFacingLeft = false;
        } 
        else if(dirx < 0f) {
            movementState = MovementState.running;
            sprite.flipX = true;
            // body.rotation = 180;
            // transform.rotation = new Quaternion(transform.rotation.x,180,transform.rotation.z,transform.rotation.w);
            isFacingLeft = true;
        } 
        else {
            movementState = MovementState.idle;
        }

        if(body.velocity.y > .1f){
            movementState = MovementState.jumping;
        } else if(body.velocity.y < -.1f){
            movementState = MovementState.falling;
        }
        
        anim.SetInteger("movementState", (int)movementState);
    }

    private bool CanJump() {
        if(Input.GetButtonDown("Jump")){
            if(movementState == MovementState.jumping){
                return false;
            }
            if(Physics2D.BoxCast(coll.bounds.center, new Vector3(coll.bounds.size.x-0.1f, coll.bounds.size.y, coll.bounds.size.z), 0f, Vector2.down, .5f, jumpableObject)){
                return true;
            }
            if(Time.time < (lastGrounded + jumpExtensionTime)){
                return true;
            }
        }

        return false;
    }

    public bool IsGrounded() {
        bool grounded =  Physics2D.BoxCast(coll.bounds.center, new Vector3(coll.bounds.size.x-0.1f, coll.bounds.size.y, coll.bounds.size.z), 0f, Vector2.down, .5f, jumpableGround);
        if(grounded){
            lastGrounded = Time.time;
        }
        return grounded;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullEnemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D player;
    [SerializeField] float speed = 1;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private Vector2 attackRange;

    private Rigidbody2D body;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private bool playerDetected;
    private float dirx = 0;
    private float diry = 0;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        if(IsPlayerInRange()){
            playerDetected = true;
            Debug.Log("Player detected");
        }

        if(playerDetected) {
            Vector2 direction = player.position - body.position;

            body.AddForce(direction.normalized * speed);
            Debug.Log(direction);
            Debug.Log(direction.normalized);
            if(direction.x > 0.1f){
                sprite.flipX = false;
            }
            else {
                sprite.flipX = true;
            }

            
            // float playerDirx = transform.position.x - player.position.x;
            // float playerDiry = transform.position.y - player.position.y;
            // if(playerDirx > 0) dirx = -1;
            // else dirx = 1;

            // if(playerDiry > 0) diry = -1;
            // else diry = 1;

            // body.velocity = new Vector2(speed*dirx, speed*diry);
        }
    }

    private bool IsPlayerInRange() {
        return Physics2D.BoxCast(coll.bounds.center, attackRange, 0f, Vector2.down, 0f, playerMask);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullEnemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D player;
    [SerializeField] float speed = 1;
    [SerializeField] float damage = 1;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private Vector2 attackRange;
    [SerializeField] private float knockbackForce = 500;

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
            // Debug.Log(direction);
            // Debug.Log(direction.normalized);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks to see if the GameObject the MeleeWeapon is colliding with has an EnemyHealth script
        if (collision.GetComponent<PlayerHealth>())
        {
            Debug.Log("Collision");
            //Method that checks to see what force can be applied to the player when melee attacking
            HandleCollision(collision.GetComponent<PlayerHealth>());
        }
    }
    private void HandleCollision(PlayerHealth objHealth)
    {
        if(objHealth.damageable){
            Vector2 direction = player.position - body.position;
            objHealth.Damage(1f);
            objHealth.knockback(new Vector2(direction.normalized.x*knockbackForce,200f));
        }
    }
}

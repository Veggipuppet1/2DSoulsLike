using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private BoxCollider2D coll;
    private Rigidbody2D body;
    private float dirx = 0;
    private bool playerDetected = false;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private Vector2 attackRange;
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
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
            float playerDirx = transform.position.x - player.transform.position.x;
            if(playerDirx > 0) dirx = -1;
            else dirx = 1;
            body.velocity = new Vector2(speed*dirx, body.velocity.y);
        }
    }

    private bool IsPlayerInRange() {
        return Physics2D.BoxCast(coll.bounds.center, attackRange, 0f, Vector2.down, 0f, playerMask);
    }
}

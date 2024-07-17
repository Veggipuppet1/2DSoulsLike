using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform posA, posB;
    [SerializeField] int speed;
    Vector2 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = posA.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, posA.position) < 0.1) targetPos = posB.position;
        if(Vector2.Distance(transform.position, posB.position) < 0.1) targetPos = posA.position;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // if(collision.tag == "Player") collision.transform.SetParent(transform);
        if(collision.tag == "Player") {
            Transform before = collision.transform;
            collision.transform.SetParent(transform);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.tag == "Player") collision.transform.SetParent(null);
    }
}

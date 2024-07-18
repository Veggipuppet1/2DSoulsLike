using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public Vector2 velocity;
    public float lifespan;
    public float startingVelocity;
    Rigidbody2D body;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        velocity = new Vector2(Random.Range(-startingVelocity, startingVelocity), Random.Range(0,startingVelocity));
        lifespan = Time.time + lifespan;
        body.AddForce(velocity);
        sprite.material.color = new Color(Random.Range(0,255),Random.Range(0,255),Random.Range(0,255));
        Debug.Log(sprite.material.color);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > lifespan) {
            sprite.material.color = new Color(sprite.material.color.r, sprite.material.color.g, sprite.material.color.b, sprite.material.color.a - 0.01f);
            if(sprite.material.color.a < 0.1f) Destroy(gameObject);
        }
    }
}

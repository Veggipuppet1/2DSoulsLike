using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key1 : MonoBehaviour
{
    [SerializeField] private GameObject door1;
    [SerializeField] Rigidbody2D player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision with player");
        Destroy(door1);
        Destroy(gameObject);
        // //Checks to see if the GameObject the MeleeWeapon is colliding with has an EnemyHealth script
        // if (collision.GetComponent<PlayerHealth>())
        // {
        //     Debug.Log("Collision");
        //     //Method that checks to see what force can be applied to the player when melee attacking
        //     HandleCollision(collision.GetComponent<PlayerHealth>());
        // }
    }
}

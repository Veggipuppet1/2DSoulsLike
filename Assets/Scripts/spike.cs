using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
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
        Debug.Log($"Collision with player: {collision.gameObject.name}");
        if(collision.GetComponent<PlayerHealth>()) collision.GetComponent<PlayerHealth>().OnDeath();
    }
}

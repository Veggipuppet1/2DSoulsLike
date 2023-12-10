using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controls : MonoBehaviour
{
    [SerializeField] private Rigidbody2D wKey;
    [SerializeField] private Rigidbody2D aKey;
    [SerializeField] private Rigidbody2D sKey;
    [SerializeField] private Rigidbody2D dKey;
    [SerializeField] private Rigidbody2D spaceKey;
    [SerializeField] private Vector2 bounceForce;
    private float dirx;
    private float diry;
    private float wStart;
    private float aStart;
    private float sStart;
    private float dStart;
    private float spaceStart;
    // Start is called before the first frame update
    void Start()
    {
        wStart = wKey.transform.position.y + 0.1f;
        aStart = aKey.transform.position.y + 0.1f;
        sStart = sKey.transform.position.y + 0.1f;
        dStart = dKey.transform.position.y + 0.1f;
        spaceStart = spaceKey.transform.position.y + 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");
        if(dirx < -0.1f){
            if(aKey.transform.position.y <= aStart){
                aKey.AddForce(bounceForce);
            }
        }
        if(dirx > 0.1f){
            if(dKey.transform.position.y <= dStart){
                dKey.AddForce(bounceForce);
            }
        }
        
        diry = Input.GetAxis("Vertical");
        if(diry < -0.1f){
            if(sKey.transform.position.y <= sStart){
                sKey.AddForce(bounceForce);
            }
        }
        if(diry > 0.1f){
            if(wKey.transform.position.y <= wStart){
                wKey.AddForce(bounceForce);
            }
        }

        if(Input.GetButton("Jump")){
            if(spaceKey.transform.position.y <= spaceStart){
                spaceKey.AddForce(bounceForce);
            }
        }
    }
}

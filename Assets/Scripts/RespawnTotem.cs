using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTotem : MonoBehaviour
{
    public Particle pixel;
    public int pixelsToGenerate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CoolEffect() {
        for (int i = 0; i < pixelsToGenerate; i++)
        {
            Instantiate(pixel, transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            CoolEffect();
            MainManager.Instance.SetSpawnPoint(gameObject.transform.position);
        }
    }
}

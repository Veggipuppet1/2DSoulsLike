using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public bool spawnPointSet = false;
    public Vector3 spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        if(Instance != null){
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetSpawnPoint (Vector2 position) {
        spawnPoint = position;
        spawnPointSet = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

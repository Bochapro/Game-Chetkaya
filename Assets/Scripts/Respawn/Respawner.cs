using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{

    public GameObject enemy;
    float randX;
    float direction = 0.0F;
    Vector2 WhereToSpawn;
    public float spawnRate = 2.0F;
    float nextSpawn = 0.0F;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            direction += 10.0F;
            randX = Random.Range(direction - 10.0F, direction);
            WhereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(enemy, WhereToSpawn, Quaternion.identity);
        }
        
    }
}

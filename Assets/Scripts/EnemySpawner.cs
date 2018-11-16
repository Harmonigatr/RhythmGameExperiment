using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    float randX;
    Vector2 SpawnAt;
    public float SpawnRate = 2.0f;
    float NextSpawn = 0.0f;

    void Update() {
        
        if (Time.time > NextSpawn) {
            NextSpawn = Time.time + SpawnRate;
            randX = Random.Range(5.6f, 5.6f);
            SpawnAt = new Vector2(randX, transform.position.y);
            Instantiate(enemy, SpawnAt, Quaternion.identity);
        }

    }
}

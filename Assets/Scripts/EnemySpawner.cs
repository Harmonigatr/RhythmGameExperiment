using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    private float SpawnAtX = 5.6f;
    private float[]PhySo3 = {0.00f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.5f,0.4f,0.2f,0.2f,0.45f,
                             0.95f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.5f,0.4f,0.2f,0.2f,0.45f,
                             0.95f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.5f,0.4f,0.2f,0.2f,0.45f,
                             0.95f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.5f,0.4f,0.2f,0.2f,0.45f,
                             0.95f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.5f,0.4f,0.2f,0.2f,0.45f,
                             0.95f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.5f,0.4f,0.2f,0.2f,0.45f,
                             0.95f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.5f,0.4f,0.2f,0.2f,0.45f,
                             0.95f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.4f,0.5f,0.4f,0.2f,0.2f,0.45f,
                             1};
    private int index = 0;

    void Update() {
        if (Time.time > PhySo3[index]) {
            PhySo3[index + 1] = Time.time + PhySo3[index+1];
            Instantiate(enemy, new Vector2(SpawnAtX, transform.position.y), Quaternion.identity);
            index++;
        }
    }
}

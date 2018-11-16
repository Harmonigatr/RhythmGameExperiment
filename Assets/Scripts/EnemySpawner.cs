using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    float randX;
    Vector2 SpawnAt;
    public float SpawnRate = 2.0f;
    float NextSpawn = 0.0f;
    /*public float minWaitTime = 0.15f;
    public float maxWaitTime = 1f;
    [SerializeField]
    private float baseSpawnTime = 3f;
    [SerializeField, Tooltip("The number of seconds to wait before increasing the spawn frequency.")]
    private float difficultyTimeScale = 20f;
    [SerializeField, Tooltip("The amount of base spawn time taken off with each difficulty increment.")]
    private float difficultyIncrementScale = 0.1f;
    private Coroutine cr_SpawnCycle = null;*/


    void Start() {
        //GameManager.Instance.GameStateChanged += GameManager_GameStateChanged;
    }

    void Update() {
        
        if (Time.time > NextSpawn) {
            NextSpawn = Time.time + SpawnRate;
            randX = Random.Range(5.6f, 5.6f);
            SpawnAt = new Vector2(randX, transform.position.y);
            Instantiate(enemy, SpawnAt, Quaternion.identity);
        }

    }


    /*private void GameManager_GameStateChanged(object sender, GameManager.GameStateChangedArgs e) {
        if (e.newState == GameManager.GameState.PLAYING) {
            StartSpawning();
        }
        else {
            StopSpawning();
        }
    }


    /// <summary>
    /// Start the repeating spawn sequence.
    /// </summary>
    public void StartSpawning() {
        StopSpawning();
        cr_SpawnCycle = StartCoroutine(SpawnCycle());
    }

    /// <summary>
    /// Stop all spawning Coroutines on this script.
    /// </summary>
    public void StopSpawning() {
        if (cr_SpawnCycle != null) {
            StopCoroutine(cr_SpawnCycle);
            cr_SpawnCycle = null;
        }
    }

    /// <summary>
    /// Coroutine that repeatedly spawns new troops based on a difficulty gradient.
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnCycle() {
        while (true) {
            float modifiedBaseSpawnTime = Mathf.Clamp(baseSpawnTime - (((Time.time - GameManager.Instance.LevelStartTime) / difficultyTimeScale) * difficultyIncrementScale), 0f, 99f);
            DeployEnemy();
            yield return new WaitForSeconds(UnityEngine.Random.Range(minWaitTime, maxWaitTime) + modifiedBaseSpawnTime);
        }
    }

    /// <summary>
    /// Retrieves a Troop.
    /// </summary>
    /// <returns>The retrieved Troop.</returns>
    private Enemy GetEnemy() {
        Enemy t;

        if (Enemy.Enemies.Count > 0) { //If the Troop pool isn't empty, take one from there... 
            t = Enemy.Enemies[0];
            Enemy.Enemies.RemoveAt(0);
        }
        else { //... else instantiate one.
            t = Instantiate(enemy, transform).GetComponent<Enemy>();
        }

        return t;
    }

    /// <summary>
    /// Reset and place a Troop.
    /// </summary>
    private void DeployEnemy() {
        Enemy t = GetEnemy();
        t.transform.position = transform.position;
        t.gameObject.SetActive(true);
        t.Resurrect();
    }*/
}

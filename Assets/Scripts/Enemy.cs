using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public UnityEngine.Sprite[] Expressions;
    private Rigidbody2D rb2d;
    private float speed = 10;

    private bool isAlive = true;

    public static List<Enemy> Enemies = new List<Enemy>();

    private Vector2 speedVector = new Vector2();

    private ScoreDisplay SD = new ScoreDisplay();

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start() {
        speedVector.x = speed;
    }

    void Update() {
        if (isAlive) {
            rb2d.velocity = -speedVector;
        }
        if (this.transform.position.x <= -5.5f)
        {
            Kill();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Player Player = collision.gameObject.GetComponent<Player>();
        if (Player == null) { return; } 
        if (Player.currentState == PlayerStates.Attack) {
            this.GetComponent<SpriteRenderer>().sprite = Expressions[1];
            SD.IncrementScore(1);
        }
        Kill();
    }

    /// <summary>
    /// Kill the troop.
    /// </summary>
    private void Kill() {
        Destroy(gameObject);
        if (!isAlive) { return; }
        isAlive = false;
        gameObject.layer = 13;
    }
}

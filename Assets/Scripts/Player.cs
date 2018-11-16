using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public static Player Instance { get { return _instance; } }
    private static Player _instance;

    public UnityEngine.Sprite[] Expressions;
    private Rigidbody2D rb2d;
    private Vector2 translationVector = new Vector2();
    private float speed = 10,
                  accelerationSpeed = 0.1f,
                  jumpHeight = 5;

    public PlayerStates currentState;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update() {

        if (Input.GetKey(KeyCode.D)) { //Handle Attack
            this.GetComponent<SpriteRenderer>().sprite = Expressions[1];
            currentState = PlayerStates.Attack;
        }
        if (Input.GetKeyUp(KeyCode.D)){
            this.GetComponent<SpriteRenderer>().sprite = Expressions[0];
            currentState = PlayerStates.Idle;
        }

        if (Input.GetKeyDown(KeyCode.W)) { //Handle Jump
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            this.GetComponent<SpriteRenderer>().sprite = Expressions[2];
            currentState = PlayerStates.Jump;
        }
        if (Input.GetKeyUp(KeyCode.W)) {
            this.GetComponent<SpriteRenderer>().sprite = Expressions[0];
            currentState = PlayerStates.Idle;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Enemy Enemy = collision.gameObject.GetComponent<Enemy>();
        if (Enemy == null) { return; }
        if (currentState != PlayerStates.Attack) {
                this.GetComponent<SpriteRenderer>().sprite = Expressions[3];
                currentState = PlayerStates.Hurt;
            }
    }

}

public enum PlayerStates {
    Idle,
    Attack,
    Jump,
    Hurt
}

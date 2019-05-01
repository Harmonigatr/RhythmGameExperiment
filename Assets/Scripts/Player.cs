using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //public static Player Instance { get { return _instance; } }
    //private static Player _instance;

    public UnityEngine.Sprite[] Expressions;
    private Rigidbody2D rb2d;
    private Vector2 translationVector = new Vector2();
    private float speed = 10,
                  accelerationSpeed = 0.1f,
                  jumpHeight = 5,
                  Timer = 0.0f;
    private const float AttLim = 0.3f;

    public PlayerStates currentState;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update() {
        Timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space)) { //Handle Attack
            this.GetComponent<SpriteRenderer>().sprite = Expressions[1];
            currentState = PlayerStates.Attack;
            Timer = 0.0f;
        }
        if (Input.GetKeyUp(KeyCode.Space) || (this.GetComponent<SpriteRenderer>().sprite == Expressions[1] && currentState == PlayerStates.Attack && Timer >= AttLim)) {
            this.GetComponent<SpriteRenderer>().sprite = Expressions[0];
            currentState = PlayerStates.Idle;
            Timer = Timer - AttLim;
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
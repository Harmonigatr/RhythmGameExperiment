using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public UnityEngine.Sprite[] Expressions;
    private Rigidbody2D rb2d;
    private Vector2 translationVector = new Vector2();
    private float speed = 3,
                  accelerationSpeed = 0.1f;

    private bool isAlive = true;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] hitSounds;

    private Animator animator;

    public static List<Enemy> Enemies = new List<Enemy>();

    private Coroutine fading = null;

    private Vector2 speedVector = new Vector2();

    private string deathAnim = "death_0";

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
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
            ScoreDisplay.Instance.IncrementScore(1);
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
        animator.Play(deathAnim);
        audioSource.clip = hitSounds[UnityEngine.Random.Range(0, hitSounds.Length)];
        audioSource.Play();
        if (deathAnim == "death_splat") { // ugh. String literals. If only I had more time.
            rb2d.velocity = new Vector2();
        }
        else {
            rb2d.AddForce(new Vector2(-10, 30f));
        }


        if (gameObject.activeSelf) { fading = StartCoroutine(FadeThenDestroy(5)); }


        gameObject.layer = 13;

        GameManager.Instance.AddDeath();
    }

    /// <summary>
    /// Coroutine that fades the Troop's alpha to 0 then disables it.
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    private IEnumerator FadeThenDestroy(float time) {
        float t = time;
        Color color = spriteRenderer.color;
        while (t > 0) {
            t -= Time.deltaTime;
            color.a = t / time;
            spriteRenderer.color = color;
            yield return null;
        }
        Enemies.Add(this);
        fading = null;
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Returns the Troop to its initialized state.
    /// </summary>
    public void Resurrect() {
        isAlive = true;
        gameObject.layer = 11;
        Color col = spriteRenderer.color;
        col.a = 1;
        spriteRenderer.color = col;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}

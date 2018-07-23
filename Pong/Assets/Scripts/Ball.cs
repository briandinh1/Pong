using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private float baseSpeed;
    public float ballSpeed;
    public float speedMultiplier;
    private Vector2 direction;
    public Transform[] spawnPoints;
    private ScoreManager scoreManager;
    public AudioSource hitSound; // when hitting a boundary or paddle
    public AudioSource pointSound;

	// Use this for initialization
	void Start () {
        scoreManager = FindObjectOfType<ScoreManager>();
        baseSpeed = ballSpeed;
        StartCoroutine(SpawnBall());
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(direction * ballSpeed * Time.deltaTime);
        ballSpeed *= speedMultiplier;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "LeftPaddle"
                || collision.gameObject.name == "RightPaddle") {
            hitSound.Play();
            direction.x = -direction.x;
        }
        else if (collision.gameObject.tag == "Boundary") {
            hitSound.Play();
            direction.y = -direction.y;
        }
        else if (collision.gameObject.tag == "KillBox") {
            transform.position = collision.transform.position; // move ball out the way
            direction = Vector2.zero;
            pointSound.Play();
            if (collision.gameObject.name == "LeftKillBox")
                scoreManager.AddRightScore();
            else
                scoreManager.AddLeftScore();
            StartCoroutine(SpawnBall());
        }
    }

    IEnumerator SpawnBall() {
        yield return new WaitForSeconds(3f);
        ballSpeed = baseSpeed;
        transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        float dirx = Random.Range(0, 2) == 1 ? 1 : -1;
        float diry = Random.Range(0, 2) == 1 ? Random.Range(0.1f, 1f) : Random.Range(-0.1f, -1f);
        direction = new Vector2(dirx, diry).normalized;
    }
}

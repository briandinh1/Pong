using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public float paddleSpeed;
    private bool hitBoundaryTop;
    private bool hitBoundaryBottom; 

	// Use this for initialization
	void Start () {
        Vector2 pos = Vector2.zero;
        if (gameObject.name == "LeftPaddle") {
            pos = new Vector2(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, 0);
            pos += Vector2.right * transform.localScale.x; 
        }
        else if (gameObject.name == "RightPaddle") {
            pos = new Vector2(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x, 0);
            pos -= Vector2.right * transform.localScale.x;
        }
        transform.position = pos;
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.name == "LeftPaddle") {
            if (Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.W)) { 
                if (!hitBoundaryTop)
                    transform.Translate(Vector2.up * paddleSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKeyDown(KeyCode.S)) {
                if (!hitBoundaryBottom)
                    transform.Translate(Vector2.down * paddleSpeed * Time.deltaTime);
            }
        }
        else if (gameObject.name == "RightPaddle") {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.UpArrow)) {
                if (!hitBoundaryTop)
                    transform.Translate(Vector2.up * paddleSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.DownArrow)) {
                if (!hitBoundaryBottom)
                    transform.Translate(Vector2.down * paddleSpeed * Time.deltaTime);
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "TopBoundary")
            hitBoundaryTop = true;
        else if (collision.gameObject.name == "BottomBoundary")
            hitBoundaryBottom = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.name == "TopBoundary")
            hitBoundaryTop = false;
        else if (collision.gameObject.name == "BottomBoundary")
            hitBoundaryBottom = false;
    }
}
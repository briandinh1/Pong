using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    private int leftScore;
    private int rightScore;
    public Text leftScoreUI;
    public Text rightScoreUI;

	// Use this for initialization
	void Start () {
        leftScore = 0;
        rightScore = 0;
	}

    public void AddLeftScore() {
        ++leftScore;
        leftScoreUI.text = "" + leftScore;
    }

    public void AddRightScore() {
        ++rightScore;
        rightScoreUI.text = "" + rightScore;
    }
}

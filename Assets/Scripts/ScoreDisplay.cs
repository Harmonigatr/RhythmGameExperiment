using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    //public static ScoreDisplay Instance { get { return _instance; } }
    //private static ScoreDisplay _instance;

    private static int _score;

    public UnityEngine.UI.Text Score;

    public void IncrementScore(int byAmount) {
        _score += byAmount;
    }

    void Start() {
        _score = 0;
    }

    private void UpdateScore() {
        Score.text = "Score: " + _score.ToString();
    }

    private void Update() {
        UpdateScore();
    }
}
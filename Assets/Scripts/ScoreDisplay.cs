using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {


    [SerializeField]
    private Text scoreLabel;

    public static ScoreDisplay Instance { get { return _instance; } }
    private static ScoreDisplay _instance;

    private int _score;
    public int Score { get { return _score; } }

    public void IncrementScore(int byAmount)
    {
        ScoreChangedArgs args = new ScoreChangedArgs();
        args.oldScore = _score;
        _score += byAmount;
        args.newScore = _score;

        OnScoreChanged(args);

    }

    public void SetScore(int score)
    {
        ScoreChangedArgs args = new ScoreChangedArgs();
        args.oldScore = _score;
        _score = score;
        args.newScore = _score;

        OnScoreChanged(args);
    }

    // Use this for initialization
    void Start()
    {
        ScoreDisplay.Instance.ScoreChanged += ScoreDisplay_ScoreChanged;
        UpdateScore(0);
    }

    private void ScoreDisplay_ScoreChanged(object sender, ScoreDisplay.ScoreChangedArgs e)
    {
        UpdateScoreLabel(e.newScore);
    }

    private void UpdateScoreLabel(int score)
    {
        scoreLabel.text = "X " + score.ToString();
    }

    // Update is called once per frame
    void Update () {
		
	}
}

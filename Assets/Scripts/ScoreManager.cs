using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : Singleton<ScoreManager> {
    private float scorePerSecond = 53f; // 53 meters per second, terminal egg velocity

    private float score = 0;

    [SerializeField]
    private TMP_Text scoreText;

    private bool isScoring = true;

    public int Score { get => (int)score; }

    private void Update() {
        if (!isScoring) {
            return;
        }

        score += Time.deltaTime * scorePerSecond;

        SetScoreText();
    }

    private void SetScoreText() {
        scoreText.text = $"{(int)score}M";
    }

    public int StopScore() {
        isScoring = false;

        return (int)score;
    }
}
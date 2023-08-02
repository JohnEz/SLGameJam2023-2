using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : Singleton<ScoreManager> {
    private float scorePerSecond = 53f; // 53 meters per second, terminal egg velocity

    private float score = 0;

    [SerializeField]
    private TMP_Text scoreText;

    private void Update() {
        score += Time.deltaTime * scorePerSecond;

        SetScoreText();
    }

    private void SetScoreText() {
        scoreText.text = $"{(int)score}M";
    }
}
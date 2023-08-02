using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
    public bool IsGameOver;

    private void Start() {
        IsGameOver = false;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameOver();
        }
    }

    public void GameOver() {
        IsGameOver = true;

        // stop scorer
        ScoreManager.Instance.StopScore();

        // show game over screen
        GameOverMenu.Instance.Show();
    }
}
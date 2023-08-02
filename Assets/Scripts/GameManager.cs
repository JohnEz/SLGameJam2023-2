using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
    public bool IsGameOver;

    [SerializeField]
    public AudioClip _onDefeatSFX;

    [SerializeField]
    private GameObject musicGo;

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

        if (musicGo) {
            Destroy(musicGo);
        }

        AudioManager.Instance.PlaySound(_onDefeatSFX, Vector3.zero);

        // stop scorer
        ScoreManager.Instance.StopScore();

        // show game over screen
        GameOverMenu.Instance.Show();
    }
}
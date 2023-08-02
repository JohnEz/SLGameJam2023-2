using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class GameOverMenu : Singleton<GameOverMenu> {

    [SerializeField]
    private TMP_Text scoreText;

    [SerializeField]
    private CanvasGroup canvasGroup;

    private void Start() {
        canvasGroup.alpha = 0;
        transform.localScale = Vector3.zero;
    }

    public void Show() {
        canvasGroup.alpha = 1;
        scoreText.text = $"{ScoreManager.Instance.Score}M";

        transform.DOScale(Vector3.one, .75f).SetEase(Ease.OutQuad);
    }
}
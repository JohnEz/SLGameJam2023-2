using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEntity : MonoBehaviour {

    [SerializeField, Range(.1f, 10f)]
    private float moveSpeedRangeMin = 0.5f;

    [SerializeField, Range(.1f, 10f)]
    private float moveSpeedRangeMax = 5f;

    private float moveSpeed;

    public void Start() {
        moveSpeed = Random.Range(moveSpeedRangeMin, moveSpeedRangeMax);
    }

    public void Update() {
        Vector3 movement = new Vector3(0, 1, 0) * moveSpeed * Time.deltaTime;

        transform.position += movement;
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (GameManager.Instance.IsGameOver) {
            return;
        }

        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (!player) {
            return;
        }

        OnHitPlayer(player);
    }

    protected virtual void OnHitPlayer(PlayerController player) {
        player.OnDeath();
        GameManager.Instance.GameOver();
    }
}
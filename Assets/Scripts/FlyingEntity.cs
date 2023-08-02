using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEntity : MonoBehaviour {

    [SerializeField, Range(.1f, 10f)]
    private float moveSpeedRangeMin = 0.5f;

    [SerializeField, Range(.1f, 10f)]
    private float moveSpeedRangeMax = 5f;

    private float moveSpeed;

    private Vector3 heading;

    public void Start() {
        moveSpeed = Random.Range(moveSpeedRangeMin, moveSpeedRangeMax);
        heading = new Vector3(
            Random.Range(-0.5f, 0.5f),
            1,
            0
        );
    }

    public void Update() {
        Vector3 movement = heading * moveSpeed * Time.deltaTime;

        transform.position += movement;
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (GameManager.Instance.IsGameOver) {
            return;
        }

        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player) {
            OnHitPlayer(player);
            return;
        }

        if (collision.gameObject.tag == "TopWall") {
            Destroy(gameObject);
        }

    }

    protected virtual void OnHitPlayer(PlayerController player) {
        player.OnDeath();
        GameManager.Instance.GameOver();
    }
}

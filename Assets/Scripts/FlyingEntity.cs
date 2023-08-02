using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEntity : MonoBehaviour {

    [SerializeField, Range(.1f, 10f)]
    private float moveSpeedRangeMin;

    [SerializeField, Range(.1f, 10f)]
    private float moveSpeedRangeMax;

    private float moveSpeed;

    [SerializeField, Range(-10f, 10f)]
    private float killY = 10f;

    public void Start() {
        moveSpeed = Random.Range(moveSpeedRangeMin, moveSpeedRangeMax);
    }

    public void Update() {
        Vector3 movement = new Vector3(0, 1, 0) * moveSpeed * Time.deltaTime;

        transform.position += movement;

        if (transform.position.y >= killY) {
            Destroy(gameObject);
        }
    }
}

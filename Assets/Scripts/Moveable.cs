using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour {

    [SerializeField]
    private float ACCEL = 10000.0f;

    public Vector2 Force { get; set; }

    private Rigidbody2D Rigidbody2D;

    private void Start() {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (Force != Vector2.zero) {
            Rigidbody2D.MovePosition((Vector2)transform.position + Force * ACCEL);
        }
    }
}

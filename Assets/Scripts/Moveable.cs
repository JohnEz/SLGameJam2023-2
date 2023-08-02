using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour {

    [SerializeField]
    private float ACCEL = 20.0f;

    public Vector2 Force { get; set; }

    //public Vector3 Facing { get; set; }
    private Rigidbody2D Rigidbody2D;
    [SerializeField]
    private float REV_GRAVITY = 0.005f;

    private void Start() {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (Force != Vector2.zero) {
            Rigidbody2D.AddForce(
                Force * ACCEL,
                ForceMode2D.Impulse
            );
        }
        Rigidbody2D.AddForce(
            new Vector2(0f, REV_GRAVITY),
            ForceMode2D.Impulse
        );

        /*
        graphics.rotation = Quaternion.Euler(
            0,
            0,
            Mathf.Atan2(
                Facing.y - transform.position.y,
                Facing.x - transform.position.x
            ) * Mathf.Rad2Deg - 90
        );
        */
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    [SerializeField]
    private float ACCEL = 0.1f;
    [SerializeField]
    private float MAX_SPEED = 13.0f;
    private Vector2 Velocity;
    public Vector2 Force { get; set; }
    //public Vector3 Facing { get; set; }

    void Update()
    {
        if (Force != Vector2.zero) {
            Velocity += Force * ACCEL;

            if (Mathf.Abs(Velocity.x) > MAX_SPEED) Velocity.x = MAX_SPEED * Mathf.Sign(Velocity.x);
            if (Mathf.Abs(Velocity.y) > MAX_SPEED) Velocity.y = MAX_SPEED * Mathf.Sign(Velocity.y);
        }
        if (Velocity != Vector2.zero) {
            transform.position +=  Time.deltaTime * new Vector3(Velocity.x, Velocity.y);
        }

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

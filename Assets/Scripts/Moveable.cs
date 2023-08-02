using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    public const float SPEED = 5f;
    public Vector2 MovementDirection { get; set; }
    public Vector3 Facing { get; set; }

    void Update()
    {
        if (MovementDirection != Vector2.zero) {
            transform.position += new Vector3(MovementDirection.x, MovementDirection.y)
                * SPEED * Time.deltaTime;
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

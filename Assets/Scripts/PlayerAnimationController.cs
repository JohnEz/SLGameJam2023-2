using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour {
    private Animator animator;

    [HideInInspector]
    public Vector2 MoveInput;

    private void Start() {
        animator = GetComponent<Animator>();
        MoveInput = Vector2.zero;
    }

    private void Update() {
        bool isUpPressed = MoveInput.y > 0;
        bool isDownPressed = MoveInput.y < 0;

        animator.SetBool("SlowPressed", isUpPressed);
        animator.SetBool("FastPressed", isDownPressed);
    }

    public void OnDeath() {
        animator.SetTrigger("Death");
    }
}
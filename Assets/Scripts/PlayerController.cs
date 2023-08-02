using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Moveable Moveable;
    private PlayerAnimationController animationController;

    private void Start() {
        Moveable = GetComponent<Moveable>();
        animationController = GetComponent<PlayerAnimationController>();
    }

    private void Update() {
        if (GameManager.Instance.IsGameOver) {
            return;
        }

        var moveX = Input.GetAxisRaw("Horizontal");
        var moveY = Input.GetAxisRaw("Vertical");

        var movementInput = new Vector2(moveX, moveY).normalized;
        Moveable.Force = movementInput;
        animationController.MoveInput = movementInput;

        //var mousePos = Input.mousePosition;
        //var mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        //Moveable.Facing = mouseWorldPosition;
    }
}
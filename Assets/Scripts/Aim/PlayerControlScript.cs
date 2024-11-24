using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour
{
    [SerializeField] private MovementScript movementScript;

    private PlayerInput _playerInput = new PlayerInput() {};

    public struct PlayerInput
    {
        public Vector2 axisInput;
        public bool isJumpPressed;
    }
    private void Update()
    {
        HandleInput();
        movementScript.MovePlayer(_playerInput);
    }

    private void HandleInput()
    {
        HandleHorizontalInput();
        HandleVerticalInput();
        HandleSpaceInput();
    }

    private void HandleSpaceInput()
    {
        _playerInput.isJumpPressed = false || Input.GetKey(KeyCode.Space);
    }

    private void HandleVerticalInput()
    {
        _playerInput.axisInput.y = 0;
        if (Input.GetKey(KeyCode.W))
            _playerInput.axisInput.y += 1;
        if (Input.GetKey(KeyCode.S))
            _playerInput.axisInput.y -= 1;
    }

    private void HandleHorizontalInput()
    {
        _playerInput.axisInput.x = 0;
        if (Input.GetKey(KeyCode.A))
            _playerInput.axisInput.x -= 1;
        if (Input.GetKey(KeyCode.D))
            _playerInput.axisInput.x += 1;
    }
}

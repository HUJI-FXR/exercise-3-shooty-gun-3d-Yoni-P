using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private float acceleration;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    
    private Rigidbody _rigidbody;
    private bool _isGrounded;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _isGrounded = true;
    }

    public void MovePlayer(PlayerControlScript.PlayerInput curInput)
    {
        if (!_isGrounded)
            return;
        
        float curSpeed = Mathf.Clamp(_rigidbody.velocity.z + curInput.axisInput.y * acceleration, -speed, speed);

        _rigidbody.velocity = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * Vector3.forward * curSpeed 
            + new Vector3(0, _rigidbody.velocity.y, 0);

        if (curInput.isJumpPressed && _isGrounded)
            Jump();
    }

    private void Jump()
    {
        _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
        _isGrounded = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
            _isGrounded = true;
    }
}

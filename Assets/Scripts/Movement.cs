using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private PlayerInput _playerInput;
    private Vector2 moveInput;
    [SerializeField] private float _jumpForce;

    private void Awake()
    {
        this._rigidbody2D = GetComponent<Rigidbody2D>();
        this._playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        this.moveInput = this._playerInput.actions["Move"].ReadValue<Vector2>();
        this._rigidbody2D.AddForce(new Vector2(this.moveInput.x, 0f), ForceMode2D.Force);
    }

    

    public void Jump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.phase == InputActionPhase.Performed) { 
            Debug.Log("Jump");
            this._rigidbody2D.AddForce(Vector2.up * this._jumpForce);
        }
    }
}

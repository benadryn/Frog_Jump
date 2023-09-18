using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody _rb;
    private float _heldTime = 5.0f;
    private bool _isGrounded;

    public float maxHoldTime = 10.0f;

    
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();

    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Platform"))
        {
            _isGrounded = true;
        }
    }

    private void Jump()
    {
        // get hold time when pressing down
        if (Input.GetKey(KeyCode.Space) && _isGrounded)
        {
            _heldTime += Time.deltaTime;
            if (_heldTime > maxHoldTime)
            {
                _heldTime = maxHoldTime;
            }
        }
        // grab hold time and add force to jump
        if (Input.GetKeyUp(KeyCode.Space) && _isGrounded)
        {
            _rb.AddRelativeForce(new Vector3(0, 1.0f, 1.0f) * _heldTime, ForceMode.Impulse);
            _heldTime = 5;
            _isGrounded = false;
        }
    }
}

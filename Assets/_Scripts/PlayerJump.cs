using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody _rb;
    private bool _isGrounded;
    private float _heldTime;

    public float startHoldTime;
    public float maxHoldTime = 15.0f;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _heldTime = startHoldTime;
    }
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
            _heldTime = startHoldTime;
            _isGrounded = false;
        }
    }
}

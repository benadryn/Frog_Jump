using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody _rb;
    // private bool _isGrounded;
    private float _heldTime;
    // private Animator _animator;
    [SerializeField] private float jumpSpeedMultiplier = 1.2f;
    [SerializeField] private GameObject arrow;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _jumpSFX;
    private bool _isGrounded;

    public float startHoldTime;
    public float maxHoldTime = 15.0f;
    
    void Start()
    {
        // _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _heldTime = startHoldTime;
    }
    void Update()
    {
        if (!GameManager.Instance.didFinish)
        {
            Jump();
        }
        _isGrounded = GameManager.Instance.isGrounded;

    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Platform"))
        {
            GameManager.Instance.isGrounded = true;
            // StartJumpSequence(false, true);
            arrow.gameObject.SetActive(true);

        }
    }

    private void Jump()
    {
        // get hold time when pressing down
        if (Input.GetKey(KeyCode.Space) && _isGrounded)
        {
            _heldTime += Time.deltaTime * jumpSpeedMultiplier;
            if (_heldTime > maxHoldTime)
            {
                _heldTime = maxHoldTime;
            }
        }
        // grab hold time and add force to jump
        if (Input.GetKeyUp(KeyCode.Space) && _isGrounded)
        {
            _audioSource.PlayOneShot(_jumpSFX);
            // StartJumpSequence(true, false);
            // turn off for moving platforms
            _rb.constraints &= ~RigidbodyConstraints.FreezePositionX;
            _rb.AddRelativeForce(new Vector3(0, 1.0f, 1.0f) * Mathf.Round(_heldTime), ForceMode.Impulse);
            _heldTime = startHoldTime;
            GameManager.Instance.isGrounded = false;
            arrow.gameObject.SetActive(false);


        }
    }
}

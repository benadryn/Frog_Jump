using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAnim : MonoBehaviour
{
    private bool _isGrounded;
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGrounded == false)
        {
            StartJumpSequence(true, false);
        }
        else
        {
            StartJumpSequence(false, true);
        }
    }
    private void StartJumpSequence(bool isJumping, bool isIdle)
    {
        _animator.SetBool("isJumping", isJumping);
        _animator.SetBool("isIdle", isIdle);
    }
}

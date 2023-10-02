using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    
    private Rigidbody _rigidbody;
    
    private float _xRangeMin = -7.0f;

    private Vector3 _startPos;
    private Vector3 _endPos;
    private Vector3 _targetDirection;
    private Vector3 _targetPos;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _startPos = transform.position;
        _endPos = new Vector3(_xRangeMin, _startPos.y, _startPos.z);
        _targetPos = _endPos;
    }
    
    void FixedUpdate()
    {
        // Doesn't work for certain speeds need to fix
        Vector3 currentPos = transform.position;
        if (currentPos == _startPos)
        {
            _targetPos = _endPos;
        }
        else if (currentPos.x <= _endPos.x)
        {
            _targetPos = _startPos;
        }

        _targetDirection = (_targetPos - currentPos).normalized;
        _rigidbody.MovePosition(currentPos + _targetDirection * (speed * Time.deltaTime));
    }
}

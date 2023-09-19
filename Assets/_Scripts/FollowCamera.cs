using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 5.0f;
    public float minZPosition = 0.0f;
    public float yOffset = 2.0f;

    private Vector3 _camStartPos;
    private bool _shouldFollow = false;

    private void Start()
    {
        _camStartPos = transform.position;
    }

    void Update()
    {
        if (player.position.z >= minZPosition && player.position.y >= -1)
        {
            _shouldFollow = true;
        }
        else
        {
            _shouldFollow = false;
        }

        if (_shouldFollow)
        {
            FollowPlayer();
        }

        if (OnDeath.IsDead == true)
        {
            StartCoroutine(nameof(ResetCam), 1.0f);
        }
        
        
    }

    private void FollowPlayer()
    {
        float newZ = Mathf.Lerp(transform.position.z, player.position.z, followSpeed * Time.deltaTime);
        float newY = Mathf.Lerp(transform.position.y, player.position.y + yOffset, followSpeed * Time.deltaTime);
        Vector3 newPosition = new Vector3(transform.position.x, newY, newZ);
        transform.position = newPosition;
    }

    private IEnumerator ResetCam(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        transform.position = Vector3.Lerp(transform.position, _camStartPos, followSpeed * Time.deltaTime);
        OnDeath.IsDead = false;
    }
}

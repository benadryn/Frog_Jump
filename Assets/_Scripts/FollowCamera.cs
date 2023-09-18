using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 5.0f;
    public float minZPosition = 0.0f;
    public float yOffset = 2.0f;

    private bool _shouldFollow = false;
    
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
            float newZ = Mathf.Lerp(transform.position.z, player.position.z, followSpeed * Time.deltaTime);
            float newY = Mathf.Lerp(transform.position.y, player.position.y + yOffset, followSpeed * Time.deltaTime);
            Vector3 newPosition = new Vector3(transform.position.x, newY, newZ);
            transform.position = newPosition;
        }
    }
}

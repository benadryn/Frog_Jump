using System.Collections;
using UnityEngine;


public class FollowCamera : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 5.0f;
    public float minZPosition = 0.0f;
    [SerializeField]private float yOffset = 2.0f;
    [SerializeField] private float zOffset = 1.0f;
    public float waitSeconds = 1.0f;

    [SerializeField] private float lerpBackDuration = 1.0f;

    private Vector3 _camStartPos;
    private bool _deathCoroutineRunning;
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

        if (OnDeath.IsDead == true && !_deathCoroutineRunning)
        {
            _deathCoroutineRunning = true;
            StartCoroutine(nameof(ResetCam), waitSeconds);
            // ResetCam(waitSeconds);
        }
        
        
    }

    private void FollowPlayer()
    {
        float newZ = Mathf.Lerp(transform.position.z, player.position.z + zOffset, followSpeed * Time.deltaTime);
        float newY = Mathf.Lerp(transform.position.y, player.position.y + yOffset, followSpeed * Time.deltaTime);
        Vector3 newPosition = new Vector3(transform.position.x, newY, newZ);
        transform.position = newPosition;
    }

    private IEnumerator ResetCam(float waitTime)
    {
        Vector3 lerpStartPos = transform.position;
        yield return new WaitForSeconds(waitTime);
        for (float lerpTime = 0; lerpTime < lerpBackDuration; lerpTime += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(lerpStartPos, _camStartPos, lerpTime/lerpBackDuration);
            yield return null;
        }
        OnDeath.IsDead = false;
        _deathCoroutineRunning = false;
    }
    // private async void ResetCam(float waitTime)
    // {
    //     await Awaitable.WaitForSecondsAsync(waitTime);
    //     transform.position = Vector3.Lerp(transform.position, _camStartPos, followSpeed * Time.deltaTime);
    //     OnDeath.IsDead = false;
    // }
}


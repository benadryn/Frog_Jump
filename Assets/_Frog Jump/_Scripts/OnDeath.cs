using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeath : MonoBehaviour
{
    public Transform startPos;

    public float resetYPos = -3.0f;

    public static bool IsDead = false;

    public static OnDeath Instance;

    private float _deathSoundPos = -1.5f;
    private bool _soundPlaying;
    [SerializeField] private AudioSource _src;
    [SerializeField] private AudioClip _splashSFX;

    private void Awake()
    {
        Instance = this;
    }

    void FixedUpdate()
    {
        if (transform.position.y < _deathSoundPos && !_soundPlaying)
        {
            _src.PlayOneShot(_splashSFX);
            _soundPlaying = true;
        }
        if (transform.position.y < resetYPos && !IsDead)
        {
            IsDead = true;
            transform.position = new Vector3(0, -100, 0);
            StartCoroutine(ResetDeath());
        }
    }

    private IEnumerator ResetDeath()
    {
        yield return new WaitForSeconds(1f);
        transform.position = startPos.position;
        transform.rotation = Quaternion.identity;
        _soundPlaying = false;
    }
    
}

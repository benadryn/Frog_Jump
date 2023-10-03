using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class OnDeath : MonoBehaviour
{
    public Transform startPos;

    public float resetYPos = -3.0f;

    public static bool IsDead = false;

    public static OnDeath Instance;

    private float _deathSoundPos = -2.0f;
    private bool _soundPlaying;
    [SerializeField] private AudioSource src;
    [SerializeField] private AudioClip splashSfx;
    [SerializeField] private ParticleSystem splashParticle;

    private void Awake()
    {
        Instance = this;
    }

    void FixedUpdate()
    {
        if (transform.position.y < _deathSoundPos && !_soundPlaying)
        {
            Vector3 currentPos = gameObject.transform.position;
            Instantiate(splashParticle, currentPos, quaternion.identity);
            src.PlayOneShot(splashSfx);
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

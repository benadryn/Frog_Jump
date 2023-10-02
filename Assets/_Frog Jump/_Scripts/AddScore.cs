using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    [SerializeField] private AudioSource _src;
    [SerializeField] private AudioClip _scoreSFX;
    [SerializeField] private int point = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _src.PlayOneShot(_scoreSFX);
            Score.Instance.AddScore(point);
            Destroy(gameObject);
        }
    }
}

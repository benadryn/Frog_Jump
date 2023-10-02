using System;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject player = other.gameObject;
        if (player.CompareTag("Player"))
        {
            Rigidbody rb = player.GetComponent<Rigidbody>();
            player.transform.parent = transform;
            rb.constraints |= RigidbodyConstraints.FreezePositionX;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject player = other.gameObject;

        if (player.CompareTag("Player"))
        {
            player.transform.parent = null;
        }
    }
}

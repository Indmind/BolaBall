using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallController : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController PlayerScript = other.GetComponent<PlayerController>();
            Vector3 PlayerPosition = PlayerScript.transform.position;
            PlayerScript.SetPositionFromCheckpoint();
        }
    }
}

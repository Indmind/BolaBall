using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallController1 : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController1 PlayerScript = other.GetComponent<PlayerController1>();
            Vector3 PlayerPosition = PlayerScript.transform.position;
            PlayerScript.SetPositionFromCheckpoint();
        }
    }
}

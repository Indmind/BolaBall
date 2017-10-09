using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    [HideInInspector]
    public float life;
    [HideInInspector]
    public Vector3 checkpoint;

    public Text CheckpointText;

    public float speed;

    [HideInInspector]
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    public void SetPositionFromCheckpoint()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = checkpoint;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("checkpoint"))
        {
            CheckpointText.text = "Checkpoint";
            checkpoint = other.transform.position;
            other.GetComponent<AudioSource>().Play();
        }
        if (other.CompareTag("finish"))
        {
            CheckpointText.text = "You Win!! Press 'space' to restart or 'ALT + f4' to exit";
            checkpoint = other.transform.position;
            other.GetComponent<AudioSource>().Play();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("checkpoint"))
        {
            CheckpointText.text = "";
        }
    }
}

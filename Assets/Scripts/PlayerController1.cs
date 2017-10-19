using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour {

    [HideInInspector]
    public float life;
    [HideInInspector]
    public Vector3 checkpoint;
    public bool isWin;
    public Text CheckpointText;
    public string secondLevel;
    public string firstLevel;

    public float speed;

    [HideInInspector]
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            stopMove();
            transform.position = new Vector3(0, 2.5f, 0);
        }
        if (Input.GetKeyDown("1"))
        {
            SceneManager.LoadScene(firstLevel);
        }
        if (isWin && (Input.GetKeyDown("n") || Input.GetKeyDown("2")))
        {
            SceneManager.LoadScene(secondLevel);
        }
        if(Input.GetKeyDown("c"))
        {
            SetPositionFromCheckpoint();
        }
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
        stopMove();
        transform.position = checkpoint;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("checkpoint"))
        {
            CheckpointText.text = "Checkpoint, press 'c' to back to checkpoint";
            checkpoint = other.transform.position;
            other.GetComponent<AudioSource>().Play();
        }
        if (other.CompareTag("finish"))
        {
            isWin = true;
            CheckpointText.text = "You Win!! Press 'r' to restart or press 'n' to go lvl 2 or 'ALT + f4' to exit";
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

    void stopMove()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}

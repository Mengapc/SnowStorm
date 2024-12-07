using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 3f;
    public GameObject Camera;
    public GameObject Player;

    // Update is called once per frame

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        // Move the player based on input and their local rotation
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(forward * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-forward * speed); // Move backward
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-right * speed); // Move left
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(right * speed); // Move right
        }

        if (Input.GetKey(KeyCode.V))
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0, 1, 0));
        }
    }
}
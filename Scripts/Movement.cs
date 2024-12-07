using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 10f;


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
            transform.position += (forward * speed * Time.deltaTime); // Move forward
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += (-forward * speed * Time.deltaTime); // Move backward
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += (-right * speed * Time.deltaTime); // Move left
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += (right * speed * Time.deltaTime); // Move right
        }
        if (Input.GetKey(KeyCode.V))
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0, 1, 0));
        }
    }
}
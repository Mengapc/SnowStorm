using UnityEngine;

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
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement += Vector3.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector3.back;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector3.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector3.right;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            movement += Vector3.right;
        }

        movement = movement.normalized;

        // Move o personagem
        rb.MovePosition(transform.position + movement);
    }
}
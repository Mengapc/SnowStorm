using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    public static float speed = 10f;
    public static bool andando = false;


    // Update is called once per frame

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        // Move the player based on input and their 
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += (forward * speed * Time.deltaTime); // Move forward                
            andando = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            speed = 5f;
            andando = true;
            transform.position += (-forward * speed * Time.deltaTime); // Move 
        }
        else
        {
            speed = 10f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            andando = true;
            transform.position += (-right * speed * Time.deltaTime); // Move left                
        }
        if (Input.GetKey(KeyCode.D))
        {
            andando = true;
            transform.position += (right * speed * Time.deltaTime); // Move right             
        }
        if (Input.GetKey(KeyCode.W) == false && (Input.GetKey(KeyCode.S) == false && (Input.GetKey(KeyCode.D) == false && (Input.GetKey(KeyCode.A) == false))))
        {
            andando = false;
        }
    }
}

using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 6f;
    public static bool andando = false;
    public static bool andando_rapido = false;


    // Update is called once per frame

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        if (Raycast.bota == false)
        {
            speed = 6f;
        }
        if (Raycast.bota == true)
        {
            speed = 12f;
        }
        
        // Move the player based on input and their 
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += (forward * speed * Time.deltaTime); // Move forward                
            andando = true;
            andando_rapido = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                speed /= 2;
            }            
            andando = true;
            andando_rapido = false;
            transform.position += (-forward * speed * Time.deltaTime); // Move 
        }
        if (Input.GetKey(KeyCode.A))
        {
            andando = true;
            andando_rapido = true;
            transform.position += (-right * speed * Time.deltaTime); // Move left                
        }
        if (Input.GetKey(KeyCode.D))
        {
            andando = true;
            andando_rapido = true;
            transform.position += (right * speed * Time.deltaTime); // Move right             
        }
        if (Input.GetKey(KeyCode.W) == false && (Input.GetKey(KeyCode.S) == false && (Input.GetKey(KeyCode.D) == false && (Input.GetKey(KeyCode.A) == false))))
        {
            andando = false;
            andando_rapido = false;
        }
    }
}

using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Transform cam;
    public float PlayerActivateDistance;
    bool active = false;
    static bool bota = false;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        active = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, PlayerActivateDistance);
        Debug.DrawRay(cam.position, cam.TransformDirection(Vector3.forward) * PlayerActivateDistance, Color.red);

        if (Input.GetKeyDown(KeyCode.F) && active)
        {
            // Check the tag of the object hit
            if (hit.collider.CompareTag("Floor"))
            {
                // Spawn a sphere at the hit point
                GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                ball.AddComponent<Rigidbody>();
                ball.transform.position = hit.point; // Place the ball at the raycast hit location
                ball.transform.position += new Vector3(0, 1, 0);
            }
            else if (hit.collider.CompareTag("Item"))
            {
                bota = true;
                Destroy(hit.collider.gameObject);
            }
            else if (hit.collider.CompareTag("Cube"))
            {
                // Scale the cube
                Transform cubeTransform = hit.collider.transform;
                cubeTransform.localScale += Vector3.one; 
            }
        }
    }
}

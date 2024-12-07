using UnityEngine;

public class Cursor : MonoBehaviour
{

    //Variables
    public Transform player;
    public float mouseSensivity = 2f;
    float cameraVerticalRotation = 0f;


    //bool lockedCursor = true;

    void Start()
    {
        //Lock and Hide Cursor
        /*Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;*/
    }

    // Update is called once per frame
    void Update()
    {
        //Collect Mouse Input
        float inputX = Input.GetAxis("Mouse X") * mouseSensivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensivity;
        /*
        if (Input.GetKey(KeyCode.V))
        {
            player.Rotate(Vector3.left * mouseSensivity);
        }
        */
        //Rotate the Camera around its local X axis
        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        player.Rotate(Vector3.up * inputX);
    }
}




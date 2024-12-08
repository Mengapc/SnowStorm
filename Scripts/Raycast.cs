using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class Raycast : MonoBehaviour
{
    public Transform cam;
    public float PlayerActivateDistance;
    bool active = false;
    public static bool bota = false;
    public static bool tabua = false;
    public GameObject Tabua_ponte;


    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        active = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, PlayerActivateDistance);
        Debug.DrawRay(cam.position, cam.TransformDirection(Vector3.forward) * PlayerActivateDistance, Color.red);

        if (Input.GetKeyDown(KeyCode.F) && active)
        {
            // Check the tag of the object 
            if (hit.collider.CompareTag("Bota"))
            {
                bota = true;
                Destroy(hit.collider.gameObject);
            }
            else if (hit.collider.CompareTag("Tabua"))
            {
                // Scale the cube
                tabua = true;
                Destroy(hit.collider.gameObject);
            }
            else if (hit.collider.CompareTag("noWood") && Tabua_ponte.activeSelf == false)
            {
                // Scale the cube
                Tabua_ponte.SetActive(!Tabua_ponte.activeSelf);
            }
        /*while (hit.collider.CompareTag("noWood") && Tabua_ponte.activeSelf == false && active)
            {
        Aqui vai estar o texto de feedback
            }*/
        }
    }
}

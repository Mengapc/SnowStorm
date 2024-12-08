using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Collections;

public class Raycast : MonoBehaviour
{
    public Transform cam;
    public float PlayerActivateDistance;
    bool active = false;
    public static bool bota = false;
    public static bool tabua = false;
    public GameObject Tabua_ponte;
    public GameObject Feedback;
    public TextMeshProUGUI feedback;

    IEnumerator Feedback_CD()
    {
        yield return new WaitForSecondsRealtime(4);
        Feedback.SetActive(!Feedback.activeSelf);
    }

    void Start()
    {

    }

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
                //Collecting plank
                tabua = true;
                Destroy(hit.collider.gameObject);
            }
            else if (hit.collider.CompareTag("noWood") && Tabua_ponte.activeSelf == false && tabua == true)
            {
                //Activate the plank
                Tabua_ponte.SetActive(!Tabua_ponte.activeSelf);                
            }
            else if (hit.collider.CompareTag("noWood") && Tabua_ponte.activeSelf == false && tabua == false)
            {
                //Activate Text
                Feedback.SetActive(!Feedback.activeSelf);
                feedback.text = "Não consigo passar por aqui!";
                StartCoroutine(Feedback_CD());
            }
        }
    }
}

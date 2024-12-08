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
    bool feedbackAtivo = false;
    public static bool bota = false;
    public static bool tabua = false;
    
    public GameObject Tabua_ponte;
    public GameObject Porta_cabana;
    public GameObject Porta_cabana_hitbox;
    
    public GameObject FeedbackInteracao;
    public TextMeshProUGUI feedbackinteracao;
    public GameObject Feedback;
    public TextMeshProUGUI feedback;

    IEnumerator Feedback_CD()
    {
        yield return new WaitForSecondsRealtime(4);
        Feedback.SetActive(!Feedback.activeSelf);
    }
    IEnumerator Porta_CD()
    {
        yield return new WaitForSecondsRealtime(2);
        Porta_cabana_hitbox.transform.GetComponent<BoxCollider>().enabled = true;
        Porta_cabana.GetComponent<Animator>().SetTrigger("Activate");
    }


    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        active = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, PlayerActivateDistance);
        Debug.DrawRay(cam.position, cam.TransformDirection(Vector3.forward) * PlayerActivateDistance, Color.red);

        if (Input.GetKeyDown(KeyCode.F) && active == true)
        {
            if (hit.collider.CompareTag("Porta"))
            {
                //Door Animation
                Porta_cabana_hitbox.GetComponent<BoxCollider>().enabled = false;
                Porta_cabana.GetComponent<Animator>().SetTrigger("Activate");
                StartCoroutine(Porta_CD());
            }
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
                feedback.text = "N�o consigo passar por aqui!";
                StartCoroutine(Feedback_CD());
            }
        }
        if (active == true)
        {
            while ((hit.collider.CompareTag("Untagged") == false) && feedbackAtivo == false)
            {
                feedbackAtivo = true;
                FeedbackInteracao.SetActive(!FeedbackInteracao.activeSelf);
                feedbackinteracao.text = "Use F para interagir!";
            }
            if (hit.collider.CompareTag("Untagged") == true && feedbackAtivo == true)
            {
                FeedbackInteracao.SetActive(!FeedbackInteracao.activeSelf);
                feedbackAtivo = false;
            }
        }
    }
}

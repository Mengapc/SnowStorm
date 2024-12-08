using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Collections;
using UnityEditor.Search;
using Unity.VisualScripting;

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
    public GameObject tabua_solta;

    public Transform canva;

    public GameObject FeedbackInteracao;
    public TextMeshProUGUI feedbackinteracao;
    public GameObject Feedback;
    public TextMeshProUGUI feedback;

    IEnumerator Feedback_CD()
    {
        yield return new WaitForSecondsRealtime(4);
        Feedback.SetActive(!Feedback.activeSelf);
    }
    IEnumerator ItemTela_CD()
    {  
        yield return new WaitForSecondsRealtime(3);
        tabua_solta.GetComponent<MeshRenderer>().enabled = false;  
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
            else if (hit.collider.CompareTag("Tabua") && tabua != true)
            {
                //Collecting plank
                tabua = true;
                tabua_solta.GetComponent<MeshCollider>().enabled = false;
                tabua_solta.GetComponent<MeshRenderer>().enabled = true;
                tabua_solta.transform.SetParent(canva);
                tabua_solta.transform.position = canva.transform.position - new Vector3(2, 1, -1.5f);
                tabua_solta.layer = 5;
                StartCoroutine(ItemTela_CD());

                //StartCoroutine(ItemTela_CD());
                //GameObject.FindWithTag("Tabua").transform.position = new Vector3(0, -5, 0);
            }
            else if (hit.collider.CompareTag("noWood") && Tabua_ponte.activeSelf == false && tabua == true)
            {
                //Activate the plank
                Tabua_ponte.SetActive(!Tabua_ponte.activeSelf);
                tabua_solta.GetComponent<MeshRenderer>().enabled = false;
                Destroy(hit.collider.gameObject);
            }
            else if (hit.collider.CompareTag("noWood") && Tabua_ponte.activeSelf == false && tabua == false)
            {
                //Activate Text
                Feedback.SetActive(!Feedback.activeSelf);
                feedback.text = "Não consigo passar por aqui!";
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
                if (hit.collider.CompareTag("noWood") == true && tabua == true)
                {
                    tabua_solta.GetComponent<MeshRenderer>().enabled = true;
                }
            }
            if (hit.collider.CompareTag("noWood") == false && tabua == true)
            {
                tabua_solta.GetComponent<MeshRenderer>().enabled = false;
            }
            if (hit.collider.CompareTag("Untagged") == true && feedbackAtivo == true)
            {
                FeedbackInteracao.SetActive(!FeedbackInteracao.activeSelf);
                feedbackAtivo = false;
            }
        }
    }
}

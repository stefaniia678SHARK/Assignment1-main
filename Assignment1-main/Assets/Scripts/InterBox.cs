using System.Net;
using TMPro;
using UnityEngine;

public class InterBox : MonoBehaviour
{
    public GameObject oven;
    public GameObject button;

    public TMP_Text text1; 
    public TMP_Text text2;

    private bool playerInside = false;
    private bool ovenUnlocked = false;

    void Start()
    {
        text1.gameObject.SetActive(true);
        text2.gameObject.SetActive(false);
        button.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        // Player enters the plane
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            Debug.Log("Player entered the box plane");
        }

        // Money touches the plane
        if (!ovenUnlocked && other.CompareTag("Money"))
        {
            ovenUnlocked = true;

            Destroy(other.gameObject);
            StartOven();

            text1.gameObject.SetActive(false);
            text2.gameObject.SetActive(true);

            Debug.Log("Money accepted, oven unlocked!");

            Destroy(gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            Debug.Log("Player left the box plane");
        }
    }

    private void StartOven()
    {
        oven.SetActive(true);
        button.SetActive(true);

        Debug.Log("Oven ON: Cooking burgers");
    }
}

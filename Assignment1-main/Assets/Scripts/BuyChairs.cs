using UnityEngine;
using TMPro;

public class BuyChairs : MonoBehaviour
{
    public GameObject buyobjects;
    public GameObject locker;
    public GameObject cafezone;

    public TMP_Text text1;
    public TMP_Text text2;
    public TMP_Text text3;

    private bool playerInside = false;
    private bool chairsUnlocked = false;

    void Start()
    {
        text1.gameObject.SetActive(true);
        text2.gameObject.SetActive(false);
        text3.gameObject.SetActive(false);
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
        if (!chairsUnlocked && other.CompareTag("Money"))
        {
            chairsUnlocked = true;

            Destroy(other.gameObject); 
            BuyChairsTables();

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
        }
    }

    private void BuyChairsTables()
    {
        buyobjects.SetActive(true);
        locker.SetActive(false);
        text3.gameObject.SetActive(true);
        cafezone.SetActive(true);
    }

}

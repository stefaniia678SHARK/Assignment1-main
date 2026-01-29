using UnityEngine;
using TMPro;

public class BuyChairs : MonoBehaviour
{
    public GameObject buyobjects;
    public GameObject locker;
    public GameObject cafezone;

    public TMP_Text text1;
    public TMP_Text text2;

    private bool playerInside = false;
    private bool chairsUnlocked = false;

    public float requiredAmount = 2f;

    private float currentMoney = 0f;

    void Start()
    {

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
            currentMoney += 1f;

            if (currentMoney >= requiredAmount)
            {

                chairsUnlocked = true;

                Destroy(other.gameObject);
                BuyChairsTables();

                text1.gameObject.SetActive(false);
                text2.gameObject.SetActive(false);

                Debug.Log("Money accepted!");

                Destroy(gameObject);
            }
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
        cafezone.SetActive(true);
    }

}

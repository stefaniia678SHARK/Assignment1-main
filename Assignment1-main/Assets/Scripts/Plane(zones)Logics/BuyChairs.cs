using UnityEngine;
using TMPro;

public class BuyChairs : MonoBehaviour
{

    public MeshRenderer meshRenderer;

    public Texture texture200;
    public Texture texture100;

    //logic when you buy chairs -> you throw money into the box plane
    // money and box plane disappears and then after some objects will appear 

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
        UpdateSprite();
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
            Destroy(other.gameObject);

            UpdateSprite();

            if (currentMoney >= requiredAmount)
            {

                chairsUnlocked = true;

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

    void UpdateSprite()
    {
        //function to update sprite depending on how much money is left to buy chairs
        //when you will put only 100$ to the plane with 300$ required amount
        //-> texture 200$ will appear


        int remainingMoney = (int)(requiredAmount - currentMoney);

        if (remainingMoney == 2)
        {
            meshRenderer.material.mainTexture = texture200;
        }
        else if (remainingMoney == 1)
        {
            meshRenderer.material.mainTexture = texture100;
        }
    }

}

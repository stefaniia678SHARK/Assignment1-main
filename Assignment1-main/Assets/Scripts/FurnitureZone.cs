using System.Diagnostics;
using System.Security.Permissions;
using TMPro;
using UnityEngine;

public class FurnitureZone : MonoBehaviour
{
    //this furniture zone is for chairs

    public GameObject chair;

    public TMP_Text text;

    void Start()
    {
        text.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        // Money touches the plane
        if (other.CompareTag("ChairBr"))
        {
            Destroy(other.gameObject);
            chair.SetActive(true);
            text.gameObject.SetActive(false);

            FurnitureManager.Instance.chairsPlaced++; // Increment chair count in FurnitureManager

            Destroy(gameObject);
        }
    }
}

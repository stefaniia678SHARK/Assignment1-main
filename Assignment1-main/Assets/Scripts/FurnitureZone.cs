using System.Diagnostics;
using TMPro;
using UnityEngine;

public class FurnitureZone : MonoBehaviour
{
    public GameObject chair;
    public GameObject chair2;

    public TMP_Text text;

    void Start()
    {
        text.gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        // Money touches the plane
        if (other.CompareTag("ChairBr") || other.CompareTag("ChairBr1"))
        {
            Destroy(other.gameObject);
            chair.SetActive(true);
        }

        if (other.CompareTag("ChairBr") || other.CompareTag("ChairBr1"))
        {
            Destroy(other.gameObject);
            chair2.SetActive(true);
        }
    }
}

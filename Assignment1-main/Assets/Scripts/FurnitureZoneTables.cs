using UnityEngine;

public class FurnitureZoneTables : MonoBehaviour
{

    //this furniture zone is for tables

    public GameObject table;

    bool tableUnlocked = false;
    void Start()
    {
;
    }

    void OnTriggerEnter(Collider other)
    {
        // Money touches the plane
        if (other.CompareTag("TableBr"))
        {
            Destroy(other.gameObject);
            table.SetActive(true);

            Destroy(gameObject);

            FurnitureManager.Instance.tablesPlaced++; // Increment table count in FurnitureManager

            tableUnlocked = true;
        }
    }
}

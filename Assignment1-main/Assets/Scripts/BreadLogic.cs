using System.Runtime.CompilerServices;
using UnityEngine;

public class BreadLogic : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        Table table = other.GetComponent<Table>();

        if (table != null && !table.hasBread)
        {
            table.PlaceBread();
            Debug.Log("Bread placed on table");
            Destroy(gameObject); // bread disappears
        }
    }
}

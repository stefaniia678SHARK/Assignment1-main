using UnityEngine;

public class Table : MonoBehaviour
{
    public Transform standPoint;
    public Transform exitPoint;

    public bool isOccupied = false;
    public bool hasBread = false;
    public bool isSpawning = false;

    public Visitor currentVisitor;

    //placing bread on the table logic
    public void PlaceBread()
    {
        if (hasBread)
            return;

        hasBread = true;

        if (currentVisitor != null)
        {
            currentVisitor.OnBreadPlaced();
            Debug.Log("Visitor notified of bread placement");
        }

        else
        {
            Debug.Log("No visitor to notify about bread placement");
        }
    }

    public void ClearTable()
    {
        isOccupied = false;
        hasBread = false;
        currentVisitor = null;
        isSpawning = false;
    }
}

using System; //i decide to keep this line "system" just in case
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random; //and make sure that unity understand that it
                                   //uses different random not system one but
                                   //unity random

public class SpawnVisitors : MonoBehaviour
{

    public GameObject[] visitorPrefab;
    public Table[] tables;

    public GameObject planes;

    public Transform spawnPoint;

    bool hasSpawned = false;

    // Update is called once per frame
    void Update()
    {
        if (FurnitureManager.Instance == null)
        { 
            return;
        }

        if (!hasSpawned && FurnitureManager.Instance.CanSpawnVisitors())
        {
            SpawnVisitor();
            hasSpawned = true;
            MusicManager.instance.PlaySound("DoorOpenening");
        }
    }

    void SpawnVisitor()
    {
        Table freeTable = GetFreeTable();

        if (freeTable == null)
        {
            return;
        }

        int index = Random.Range(0, visitorPrefab.Length);
        GameObject visitorObj = 
            Instantiate(visitorPrefab[index], spawnPoint.position, Quaternion.identity);

        visitorObj.GetComponent<Visitor>().assignedTable = freeTable;

        int visitorCount = FindObjectsOfType<Visitor>().Length;

        if (visitorCount >= 2)
        {
            MusicManager.instance.PlaySound("VoicesInCafe");
        }

        freeTable.isOccupied = true;

        planes.SetActive(true);
    }

    Table GetFreeTable()
    {
        foreach (var table in tables)
        {
            if (!table.isOccupied)
                return table;
        }
        return null;
    }
}

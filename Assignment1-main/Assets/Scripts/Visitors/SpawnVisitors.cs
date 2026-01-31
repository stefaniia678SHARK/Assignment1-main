using System; //i decide to keep this line "system" just in case
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
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

    // Update is called once per frame
    void Update()
    {
        if (FurnitureManager.Instance == null)
        { 
            return;
        }

        if (!FurnitureManager.Instance.CanSpawnVisitors())
        {
            return;
        }

        foreach (Table table in tables)
        {
            if (!table.gameObject.activeInHierarchy)
                continue;

            if (table.isOccupied || table.isSpawning)
                continue;

            SpawnVisitor(table);
            break; 
        }
  
    }

    void SpawnVisitor(Table freeTable)
    {

        freeTable.isSpawning = true;
        //we will be spawning random visitor from the array of visitors

        int index = Random.Range(0, visitorPrefab.Length);

        GameObject visitorObj =
                Instantiate(visitorPrefab[index], spawnPoint.position, Quaternion.identity);

        Visitor visitor = visitorObj.GetComponent<Visitor>();

        //assigning the free table to the visitor

        visitor.assignedTable = freeTable;
        freeTable.currentVisitor = visitor;
        freeTable.isOccupied = true;

        int visitorCount = FindObjectsByType<Visitor>(FindObjectsSortMode.None).Length;  

        //adding sound of cafe voices if there are 2 or more visitors

        if (visitorCount >= 2)
        {
            MusicManager.instance.PlaySound("VoicesInCafe");
        }

        planes.SetActive(true);
    }
}

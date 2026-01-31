using UnityEngine;

public class FurnitureManager : MonoBehaviour
{
    public static FurnitureManager Instance;

    public int chairsPlaced = 0;
    public int tablesPlaced = 0;

    private void Awake()
    {        
        Instance = this;        
    }

    //checking the requirments to spawn visitors
    public bool CanSpawnVisitors()
    {
        return chairsPlaced >= 2 && tablesPlaced >= 1;
    }
}

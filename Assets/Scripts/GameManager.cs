using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameResource resources = new GameResource();

    void Awake()
    {
        // Kondisi awal game
        if (resources.money == 0 && resources.dayCount == 0 && string.IsNullOrEmpty(resources.dateString))
        {
            resources.dayCount = 1;
            resources.dateString = "Monday, 01/01";
            resources.money = 1000;
            resources.ambulanceStatus = "Ready";
            resources.upgradeLevel = 1;
            resources.ambulanceCount = 1;
        }
    }
}

[System.Serializable]
public class GameResource
{
    public int dayCount;              
    public string dateString;         
    public int money;                 
    public string ambulanceStatus;    
    public int upgradeLevel;          
    public int ambulanceCount;        
}
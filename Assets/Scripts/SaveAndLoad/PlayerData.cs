using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int dayCount;
    public string dateString;
    public int money;
    public string ambulanceStatus;
    public int upgradeLevel;
    public int ambulanceCount;

    public PlayerData(GameManager manager)
    {
        dayCount = manager.resources.dayCount;
        dateString = manager.resources.dateString;
        money = manager.resources.money;
        ambulanceStatus = manager.resources.ambulanceStatus;
        upgradeLevel = manager.resources.upgradeLevel;
        ambulanceCount = manager.resources.ambulanceCount;
    }
}
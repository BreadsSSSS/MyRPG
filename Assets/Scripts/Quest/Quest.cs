using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Quest 
{
    public QuestType questType;
    public QuestStatus questStatus;
    public string QuestName;
    public string QuestDescription;
    public int EXP;
    public int Money;
    public ItemSo[] items;

    public int Current = 0;
    public int Count = 5;

    public void GetAllItem()
    {
        foreach (var item in items)
        {
            InventoryManager.Instance.AddItem(item);
        }
        GameManager.instance.Money += Money;
        GameManager.instance.Player.GetComponent<PlayerStatus>().UpdateLeve(EXP);
    }
}

public enum QuestType
{
    Talk,
    Search,
    Battle
}

public enum QuestStatus
{
    Watting,
    Accepted,
    Compeleted
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSo", menuName ="So/ItemSo")]
public class ItemSo : ScriptableObject
{
    public Sprite sprite;
    public string Name;
    public int Buy;
    public int Cell;
    public string Description;
    public ItemType type;

    public virtual void Use()
    {
        Debug.Log("Use");
        InventoryManager.Instance.RemoveItem(this);
    }

    public virtual void Drop()
    {
        InventoryManager.Instance.RemoveItem(this);
        Debug.Log("Drop");
    }
    public void CellItem()
    {
        InventoryManager.Instance.RemoveItem(this);
        GameManager.instance.Money += Cell;
    }
    public void BuyItem()
    {
        
        if(GameManager.instance.Money >= Buy && InventoryManager.Instance.items.Count < 6)
        {
            InventoryManager.Instance.AddItem(this);
            GameManager.instance.Money -= Buy;
            InventoryManager.Instance.DisPlayItems();
        }
        
    }
}

public enum ItemType
{
    Usable,
    Tool,
    Body,
    Shoe,
    KeyTool,
}
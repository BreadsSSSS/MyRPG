using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ToolItemSo", menuName = "So/ToolItemSo")]
public class ToolItem : ItemSo
{
    public int Attack;
    public int Defence;
    public int Speed;
    public override void Use()
    {
        base.Use();
        for (int i = 0; i < InventoryManager.Instance.equpmentSlots.Count; i++)
        {
            var epSlot = InventoryManager.Instance.equpmentSlots[i];
            if (this.type == epSlot.itemType)
            {
                if (epSlot.item == null)
                {
                    InventoryManager.Instance.equipments[i] = this;
                    InventoryManager.Instance.RemoveItem(this);
                    UpdateStatus();
                }
                else
                {
                    RemoveStatus(epSlot.item);
                    var temp = InventoryManager.Instance.equipments[i];
                    InventoryManager.Instance.equipments[i] = null;
                    InventoryManager.Instance.equipments[i] = this;
                    InventoryManager.Instance.items.Remove(this);
                    InventoryManager.Instance.AddItem(temp);
                    InventoryManager.Instance.DisPlayItems();
                    UpdateStatus(this);
                }
            }
        }
        InventoryManager.Instance.bagController.UpDatePlayerData();
    }

    public override void Drop()
    {
        base.Drop();
    }

    public void UnGetTool()
    {
        if (InventoryManager.Instance.items.Count < 6)
        {
            for (int i = 0; i < InventoryManager.Instance.equipments.Count; i++)
            {
                var tool = InventoryManager.Instance.equpmentSlots[i];
                if(tool.item == this)
                {
                    InventoryManager.Instance.equipments[i] = null;
                    RemoveStatus();
                    InventoryManager.Instance.AddItem(this);
                }
                
            }
        }
        InventoryManager.Instance.bagController.UpDatePlayerData();
    }

    public void RemoveStatus()
    {
        GameManager.instance.Player.GetComponent<PlayerStatus>().Attack -= Attack;
        GameManager.instance.Player.GetComponent<PlayerStatus>().Defence -= Defence;
        GameManager.instance.Player.GetComponent<PlayerStatus>().Speed -= Speed;
    }
    public void RemoveStatus(ToolItem toolItem)
    {
        GameManager.instance.Player.GetComponent<PlayerStatus>().Attack -= toolItem.Attack;
        GameManager.instance.Player.GetComponent<PlayerStatus>().Defence -= toolItem.Defence;
        GameManager.instance.Player.GetComponent<PlayerStatus>().Speed -= toolItem.Speed;
    }

    public void UpdateStatus()
    {
        GameManager.instance.Player.GetComponent<PlayerStatus>().Attack += Attack;
        GameManager.instance.Player.GetComponent<PlayerStatus>().Defence += Defence;
        GameManager.instance.Player.GetComponent<PlayerStatus>().Speed += Speed;
    }
    public void UpdateStatus(ToolItem toolItem)
    {
        GameManager.instance.Player.GetComponent<PlayerStatus>().Attack += toolItem.Attack;
        GameManager.instance.Player.GetComponent<PlayerStatus>().Defence += toolItem.Defence;
        GameManager.instance.Player.GetComponent<PlayerStatus>().Speed += toolItem.Speed;
    }
}

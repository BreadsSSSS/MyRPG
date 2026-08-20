using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemSo itemSo;
    public ItemType itemType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            if (InventoryManager.Instance.AddItem(itemSo))
            {
                Destroy(this.gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopSolt : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public ItemSo item = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(item != null)
        {
            item.BuyItem();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(item != null)
        {
            InventoryManager.Instance.shopController.Shop.SetActive(true);
            InventoryManager.Instance.shopController.shopCell.text = item.Buy.ToString();
            InventoryManager.Instance.shopController.shopDescription.text = item.Description;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InventoryManager.Instance.shopController.Shop.SetActive(false);
    }

    private void Awake()
    {
        InventoryManager.Instance.shopSolts.Add(this);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        InventoryManager.Instance.shopSolts.Remove(this);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public GameObject Shop;
    public Text shopCell;
    public Text shopDescription;
    private void Awake()
    {
        InventoryManager.Instance.shopController = this;
    }
    void Start()
    {
        InventoryManager.Instance.UpdateShop();
        InventoryManager.Instance.DisPlayItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowShopItem()
    {

    }

    public void CloseShop()
    {
        WindowManager.Instance.CloseWindow(WindowType.ShopWindow);
        GameManager.instance.isShop = false;
    }

    private void OnDestroy()
    {
        InventoryManager.Instance.shopController = null;
        InventoryManager.Instance.equpmentSlots.Clear();
        InventoryManager.Instance.itemSlots.Clear();
    }
}

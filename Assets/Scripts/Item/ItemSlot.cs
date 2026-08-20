using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    public Image Icon;
    public Transform Transform;
    public Button DropBtn;
    public ItemSo item = null;
    private void Awake()
    {
        InventoryManager.Instance.itemSlots.Add(this);
        //DropBtn.onClick.AddListener(DropthisItme);
    }

    private void OnEnable()
    {
        //InventoryManager.Instance.itemSlots.Add(this);
    }

    public void DropthisItme()
    {
        if(item != null)
        {
            item.Drop();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (item != null)
        {
            if(GameManager.instance.isBattle)
            {
                item.Use();
                WindowManager.Instance.CloseWindow(WindowType.BagWindow);
                BattleManager.Instance.NextTurn();
            }
            else if (GameManager.instance.isShop)
            {
                item.CellItem();
            }
            else
            {
                item.Use();
            }
            
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        DropBtn.onClick.RemoveAllListeners();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(item != null && InventoryManager.Instance.bagController != null)
        {
            InventoryManager.Instance.ShowNowItem(item.sprite, item.Description);
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (item != null && InventoryManager.Instance.bagController != null)
            InventoryManager.Instance.DisNowItem();
    }

    private void OnDestroy()
    {

    }
}

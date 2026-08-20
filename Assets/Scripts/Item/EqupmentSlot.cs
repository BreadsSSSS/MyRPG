using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EqupmentSlot : MonoBehaviour,IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public ItemType itemType;
    public ToolItem item = null;
    private void Awake()
    {
        InventoryManager.Instance.equpmentSlots.Add(this);
    }

    private void OnEnable()
    {
        //InventoryManager.Instance.equpmentSlots.Add(this);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
            InventoryManager.Instance.ShowNowItem(item.sprite, item.Description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InventoryManager.Instance.DisNowItem();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(item != null)
        {
            item.UnGetTool();
            InventoryManager.Instance.DisPlayItems();
        }
    }

    private void OnDestroy()
    {

    }

    private void OnDisable()
    {

    }
}

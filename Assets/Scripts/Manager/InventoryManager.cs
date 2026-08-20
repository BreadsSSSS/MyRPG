using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class InventoryManager : SigonTon<InventoryManager>
{
    public List<ItemSlot> itemSlots;
    public List<EqupmentSlot> equpmentSlots;
    public List<ItemSo> items;
    public List<ToolItem> equipments;

    public Image NowIcon;
    public Text NowInfo;
    [Header("Controller")]
    public BagController bagController;
    public ShopController shopController;
    public TextAsset dataFile;
    string[] TextLines;
    public List<ItemSo> Shops;
    public List<ShopSolt> shopSolts;
    private PlayerStatus playerStatus;
    public PlayerStatus PlayerStatus
    {
        get { return playerStatus; }
    }
    protected override void Awake()
    {
        base.Awake();
        playerStatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
        if(dataFile != null )
        {
            TextLines = dataFile.text.Split('\n');
        }
    }
    void Start()
    {
        //Init();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DisPlayItems()
    {
        for(int i = 0; i < itemSlots.Count; i++)
        {
            if(i < items.Count)
            {
                itemSlots[i].Transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                itemSlots[i].Transform.GetChild(0).GetComponent<Image>().sprite = items[i].sprite;
                itemSlots[i].item = items[i];

                if (!GameManager.instance.isShop)
                {
                    itemSlots[i].Transform.GetChild(2).gameObject.SetActive(true);
                }
            }
            else
            {
                itemSlots[i].Transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                itemSlots[i].Transform.GetChild(0).GetComponent<Image>().sprite = null;
                itemSlots[i].item = null;

                itemSlots[i].Transform.GetChild(2).gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < equpmentSlots.Count; i++)
        {
            if (i < equipments.Count && equipments[i] != null)
            {
                equpmentSlots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                equpmentSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = equipments[i].sprite;
                equpmentSlots[i].item = equipments[i];

            }
            else
            {
                equpmentSlots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                equpmentSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                equpmentSlots[i].item = null;

            }
        }
    }

    public bool AddItem(ItemSo itemSo)
    {
        if(items.Count < 6)
        {
            items.Add(itemSo);
            return true;
        }
        else
        {
            Debug.Log("no empty");
            return false;
        }
        //DisPlayItems();
    }

    public void FindALLSlots(GameObject obj)
    {
        foreach(var slot in obj.GetComponentsInChildren<ItemSlot>(true))
        {
            itemSlots.Add(slot);
        }
    }

    public void EqupmentSlots(GameObject obj)
    {
        foreach (var slot in obj.GetComponentsInChildren<EqupmentSlot>(true))
        {
            equpmentSlots.Add(slot);
        }
    }

    public void RemoveAllSlots()
    {
        for(int i = 0; i < itemSlots.Count; i++)
        {
            itemSlots.RemoveAt(i);
            i--;
        }
        for(int i = 0;i < equpmentSlots.Count; i++)
        {
            equpmentSlots.RemoveAt(i);
            i--;
        }
    }
    public void ShowNowItem(Sprite sprite, string info)
    {
        NowIcon.sprite = sprite;
        NowIcon.color = new Color(1, 1, 1, 1);
        NowInfo.text = info;
    }
    
    public void DisNowItem()
    {
        NowIcon.sprite = null;
        NowIcon.color = new Color(1, 1, 1, 0);
        NowInfo.text = null;
    }

    public void RemoveItem(ItemSo item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
        }
        DisPlayItems();
    }

    public void RemoveEqupementItem(ToolItem item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
        }
        DisPlayItems();
    }

    private void RemoveFirstDuplicates()
    {
        HashSet<ItemSo> seen = new HashSet<ItemSo>();
        List<ItemSo> duplicates = new List<ItemSo>();

        // 第一次遍历：找出所有重复的元素，但不删除它们  
        foreach (var item in items)
        {
            if (seen.Contains(item))
            {
                duplicates.Add(item); // 只添加一个重复项到duplicates列表  
            }
            else
            {
                seen.Add(item);
            }
        }

        // 第二次遍历：从原列表中删除第一个找到的重复项  
        foreach (var duplicate in duplicates)
        {
            int index = items.IndexOf(duplicate);
            if (index != -1) // 确保找到了元素  
            {
                items.RemoveAt(index); // 删除第一个找到的重复项  
                break; // 只删除一个，然后跳出循环  
            }
        }
    }

    public void AddStatus()
    {
        foreach(var eqpSlot in equipments)
        {
            if (eqpSlot != null)
            {
                playerStatus.Attack += eqpSlot.Attack;
                playerStatus.Defence += eqpSlot.Defence;
                playerStatus.Speed += eqpSlot.Speed;
            }
        }
        bagController.UpDatePlayerData();
    }

    public void RemoveStatus()
    {
        foreach (var eqpSlot in equipments)
        {
            if (eqpSlot != null)
            {
                playerStatus.Attack -= eqpSlot.Attack;
                playerStatus.Defence -= eqpSlot.Defence;
                playerStatus.Speed -= eqpSlot.Speed;
            }
        }
        bagController.UpDatePlayerData();
    }

    public void UpdateShop()
    {
        for (int i = 0; i < Shops.Count; i++)
        {
            if (i < shopSolts.Count)
            {
                shopSolts[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                shopSolts[i].transform.GetChild(0).GetComponent<Image>().sprite = Shops[i].sprite;
                shopSolts[i].item = Shops[i];

            }
            else
            {
                shopSolts[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                shopSolts[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                shopSolts[i].item = null;

            }
        }
    }

    public void Init()
    {
        for (int index = 1; index < TextLines.Length; index++)
        {
            string itemName = TextLines[index];
            if (!string.IsNullOrEmpty(itemName))
            {
                Debug.Log(itemName);
                var item = Resources.Load($"SO/{itemName}")as ItemSo;
                Shops.Add(item);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagController : MonoBehaviour
{
    public Image Icon;
    public Text Info;
    public Text[] texts;
    private void Awake()
    {
        InventoryManager.Instance.NowIcon = Icon;
        InventoryManager.Instance.NowInfo = Info;
        InventoryManager.Instance.bagController = this;
    }
    void Start()
    {
        
    }

    private void OnEnable()
    {
        InventoryManager.Instance.DisPlayItems();
        UpDatePlayerData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddListener(Button[] buttons)
    {
        foreach(var bt in buttons)
        {
            if(bt.name == "Close")
            {
                bt.onClick.AddListener(OnCloseClick);
            }
        }
    }
    public void RemoveListener(Button[] buttons)
    {
        foreach (var bt in buttons)
        {
            if (bt.name == "Close")
            {
                bt.onClick.RemoveListener(OnCloseClick);
            }
        }
    }
    private void OnCloseClick()
    {
        InventoryManager.Instance.equpmentSlots.Clear();
        InventoryManager.Instance.itemSlots.Clear();
        WindowManager.Instance.CloseWindow(WindowType.BagWindow);
        Debug.Log("Close Bag");
    }

    public void UpDatePlayerData()
    {
        PlayerStatus playerStatus = InventoryManager.Instance.PlayerStatus;
        foreach (var txt in texts)
        {
            if(txt.name == "HP")
            {
                txt.text = playerStatus.HP.ToString() + " / " +  playerStatus.MaxHP.ToString();
            }
            else if(txt.name == "MP")
            {
                txt.text = playerStatus.MP.ToString() + " / " + playerStatus.MaxMP.ToString();
            }
            else if (txt.name == "Attack")
            {
                txt.text = playerStatus.Attack.ToString();
            }
            else if (txt.name == "Defence")
            {
                txt.text = playerStatus.Defence.ToString();
            }
            else if (txt.name == "MDF")
            {
                txt.text = playerStatus.MagicDefence.ToString();
            }
            else if (txt.name == "Speed")
            {
                txt.text = playerStatus.Speed.ToString();
            }
            else if (txt.name == "LV")
            {
                txt.text = playerStatus.Level.ToString();
            }
            else if (txt.name == "EXP")
            {
                txt.text = playerStatus.Experience.ToString() + " / "+ playerStatus.MaxExp;
            }
        }


    }
    private void OnDestroy()
    {
        InventoryManager.Instance.NowIcon = null;
        InventoryManager.Instance.NowInfo = null;
        InventoryManager.Instance.bagController = null;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject inventory;
    public GameObject manue;

    public GameObject nowPanel;
    public int PanelsCount = 0;
    public bool isMenu;

    [SerializeField]
    public Stack<GameObject> Panels = new Stack<GameObject>();

    public List<GameObject> BattleUI = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    void Start()
    {
        PanelsCount = Panels.Count;
        //foreach (GameObject uis in BattleUI) 
        //{
        //    uis.SetActive(true);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        PanelsCount = Panels.Count;
        inputSystem();
        if(PanelsCount > 0)
        {
            isMenu = true;
            Time.timeScale = 0;
        }
        else
        {
            isMenu = false;
            Time.timeScale = 1;
        }
    }

    private void OpenManue()
    {
        Panels.Push(manue);
        manue.SetActive(true);
        ChangeNow();
    }

    public void CloseManue()
    {
        manue.SetActive(false);
        Panels.Pop();
        ChangeNow();
    }

    void inputSystem()
    {
        if (Panels.Count == 0)
        {
            if (Input.GetMouseButtonDown(1))
            {
                OpenManue();
            }
        }
        else
        {
            if(Panels.Count!= 0)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    nowPanel.SetActive(false);
                    Panels.Pop();
                    ChangeNow();
                }
            }
        }
    }
    public void OpenInventory()
    {
        inventory.SetActive(true);
        if (!Panels.Contains(inventory))
        {
            Panels.Push(inventory);
        }
        ChangeNow();
        Debug.Log("bag");
    }

    public void CloseInventory()
    {
        inventory.SetActive(false);
        Panels.Pop();
        ChangeNow();
        Debug.Log("close bag");
    }

    void ChangeNow()
    {
        if(nowPanel != null)
        {
            TurrnOffButton();
        }
        if (Panels.Count() != 0)
        {
            nowPanel = Panels.Peek();
            TurrnOnButton();
        }
        else
        {
            nowPanel = null;
        }
    }

    public void Logon()
    {
        Debug.Log("click");
    }

    public void TurrnOffButton()
    {
        if(nowPanel != null)
        {
            Button[] buttons = nowPanel.GetComponentsInChildren<Button>();

            // 遍历所有Button
            foreach (Button button in buttons)
            {
                button.interactable = false;
            }
        }
    }

    public void TurrnOnButton()
    {
        if (nowPanel != null)
        {
            Button[] buttons = nowPanel.GetComponentsInChildren<Button>();

            // 遍历所有Button
            foreach (Button button in buttons)
            {
                button.interactable = true;
            }
        }
    }


}

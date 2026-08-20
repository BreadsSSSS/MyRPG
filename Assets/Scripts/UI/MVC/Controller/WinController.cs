using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinController : MonoBehaviour
{
    public Text Exp;
    public Text Money;
    public Text Items;
    void Start()
    {
        Exp.text = BattleManager.Instance.TotalEXP.ToString();
        Money.text = BattleManager.Instance.TotalMoney.ToString();
        foreach (var item in BattleManager.Instance.items)
        {
            Items.text += item.Name + " ";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseWinPanel()
    {
        WindowManager.Instance.CloseWindow(WindowType.WinWindow);
        GameManager.instance.QuitBattle();
    }
}

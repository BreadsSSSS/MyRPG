using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeButton : MonoBehaviour
{
    private GameObject Hero;
    void Start()
    {
        string temp = gameObject.name;
        gameObject.GetComponent<Button>().onClick.AddListener(() => AttackCallBack(temp));
        Hero = GameObject.FindGameObjectWithTag("Player");
    }

    private void AttackCallBack(string btn)
    {
        if(btn == "Attack")
        {
            if(GameManager.instance.Enemys.Count == 1)
            {
                Hero.GetComponent<FighterAction>().SelectAction("Attack");
            }
            else
            {
                GameManager.instance.OpenHit();
                BattleManager.Instance.CloseAllButton();
            }
        }
        else if(btn == "Skill")
        {
            WindowManager.Instance.OpenWindow(WindowType.SkillSelectWindow);
        }
        else if (btn == "Run" && !GameManager.instance.isBoos)
        {
            Hero.GetComponent<FighterAction>().SelectAction("Run");
        }
        else if(btn == "Tool")
        {
            WindowManager.Instance.OpenWindow(WindowType.BagWindow);
        }
    }

}

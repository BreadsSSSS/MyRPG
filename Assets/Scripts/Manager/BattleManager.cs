using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : SigonTon<BattleManager>
{
    public GameObject BattleMenu;
    //public GameObject BattlePlayer;
    public List<FightStats> fighters = new List<FightStats>();
    //public Text DamagePoint;
    public int TotalEXP;
    public int TotalMoney;
    public List<ItemSo> items = new List<ItemSo>();
    private GameObject currenUnit;
    private Button run;
    public GameObject CurrentUnit
    {
        get { return currenUnit; }
    }
    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        
    }
    private void OnEnable()
    {
        //DamagePoint = FindFirstObjectByType<BattleController>().DamagePoint;
        TotalEXP = 0;
        TotalMoney = 0;
        StartBattle();
    }
    void Update()
    {
        
    }

    public void NextTurn()
    {
        FightStats currentStats = fighters[0];
        fighters.Remove(currentStats);
        if (!currentStats.GetDead())
        {
            currenUnit = currentStats.gameObject;
            currentStats.CalCulateNextTurn(currentStats.nextActionTrun);
            fighters.Add(currentStats);
            fighters.Sort();
            if (currenUnit.tag == "Player")
            {
                currenUnit.GetComponent<AttackScript>().CurrentSkill = null;
                if(GameManager.instance.Enemys.Count != GameManager.instance.Dies.Count)
                {
                    OpenAllButton();
                }
            }
            else
            {
                EnemyAction();
            }
        }

    }

    public void CloseAllButton()
    {
        Button[] buttons = BattleMenu.GetComponentsInChildren<Button>();
        foreach (Button btns in buttons)
        {
            btns.interactable = false;
        }
    }

    public void OpenAllButton()
    {
        Button[] buttons = BattleMenu.GetComponentsInChildren<Button>();
        foreach (Button btns in buttons)
        {
            btns.interactable = true;
            if(btns.name == "Run")
            {
                run = btns;
            }
        }
    }
    
    void EnemyAction()
    {
        CloseAllButton();
        string attackType = Random.Range(0, 2) == 1 ? "Attack" : "Skill";
        currenUnit.GetComponent<FighterAction>().SelectAction(attackType);
    }

    void StartBattle()
    {
        BattleMenu = GameObject.Find("BattleUI");

        FightStats HeroStats = GameManager.instance.Player.GetComponent<FightStats>();
        HeroStats.CalCulateNextTurn(0);
        fighters.Add(HeroStats);

        GameObject[] Enemeys = GameObject.FindGameObjectsWithTag("Enemey");
        foreach (GameObject enemy in Enemeys)
        {
            FightStats EnemeyStats = enemy.GetComponent<FightStats>();
            EnemeyStats.CalCulateNextTurn(0);
            fighters.Add(EnemeyStats);
        }

        fighters.Sort();
        CloseAllButton();

        NextTurn();
    }
    private void OnDisable()
    {
        BattleMenu = null;
        fighters.Clear();
        items.Clear();
        //DamagePoint = null;
        currenUnit = null;
    }
}

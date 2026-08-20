using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyStats : FightStats
{
    public int Gold;
    public ItemSo item;
    public bool isBoos;
    public override void Start()
    {
        base.Start();
        if(this.name == "Boos")
        {
            OverDie.AddListener(GameClear);
        }
    }

    public override void OnEnable()
    {
        base.OnEnable();
        GameManager.instance.Enemys.Add(this.gameObject);
        GameManager.instance.isBoos = isBoos;
        this.tag = "Enemey";
    }

    public override void onDie()
    {
        base.onDie();
        this.tag = "Die";
        BattleManager.Instance.TotalEXP += (int)Experience;
        BattleManager.Instance.TotalMoney += Gold;
        BattleManager.Instance.items.Add(item);
        BattleManager.Instance.fighters.Remove(this);
        GameManager.instance.RemoveEnemy(this.gameObject);
        GetComponent<QuestTarget>()?.QuestCompelete();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDie()
    {
        gameObject.SetActive(false);
    }

    private void OnMouseEnter()
    {
        Debug.Log("Emy");
    }

    public void GameClear()
    {
        StartCoroutine(Open());
        float i = 3;
        while (i>0)
        {
            i -= Time.deltaTime * 0.1f;
        }
        WindowManager.Instance.OpenWindow(WindowType.GameClearWindow);
    }

    public IEnumerator Open()
    {
        yield return new WaitForSeconds(4f);
        WindowManager.Instance.OpenWindow(WindowType.GameClearWindow);
    }
}

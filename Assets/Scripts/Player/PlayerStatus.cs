using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Networking.UnityWebRequest;

public class PlayerStatus : FightStats
{
    public int MaxExp;
    public AudioClip gameOver;
    public PlayerDatas playerDatas;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void onDie()
    {
        base.onDie();

    }
    public void ADDHelath(int add)
    {
        HP = Mathf.Min(HP+add,MaxHP);
        InventoryManager.Instance.bagController.UpDatePlayerData();
    }

    public void ADDMp(int add)
    {
        MP = Mathf.Min(MP + add, MaxMP);
        InventoryManager.Instance.bagController.UpDatePlayerData();
    }

    public void UpdateLeve(int exp)
    {
        Experience += exp;
        if(Experience >= MaxExp)
        {
            Experience -= MaxExp;
            Level = (int)MathF.Min(Level + 1, MaxLv);
            LeveUp(Level);
            UpdateLeve();
        }
    }
    public void UpdateLeve()
    {
        if (Experience >= MaxExp)
        {
            Experience -= MaxExp;
            Level = (int)MathF.Min(Level + 1, MaxLv);
            LeveUp(Level);
            UpdateLeve();
        }
    }

    public void LeveUp(int lv)
    {
        CharactorDataSo charactorData = playerDatas.UpdatleStatus(Level);
        MaxHP = charactorData.HP; 
        MaxMP = charactorData.MP;
        Attack = charactorData.Attack;
        MagicAttack = charactorData.MagicAttack;
        Defence = charactorData.Defence;
        MagicDefence = charactorData.MagicDefence;
        MaxExp = (int)charactorData.Experience;

        foreach(var ep in InventoryManager.Instance.equipments)
        {
            if(ep != null)
            {
                ep.UpdateStatus();
            }
        }
    }

    public void GameOverSound()
    {
        GameManager.instance.cameraController.transform.GetComponent<AudioSource>().clip = gameOver;
        GameManager.instance.cameraController.transform.GetComponent<AudioSource>().loop = false;
        StartCoroutine(Lose());
    }

    IEnumerator Lose()
    {
        yield return new WaitForSeconds(2);
        WindowManager.Instance.OpenWindow(WindowType.LoseWindow);
    }
}

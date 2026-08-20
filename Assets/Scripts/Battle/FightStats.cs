using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using Unity.Mathematics;

public class FightStats : MonoBehaviour,IComparable
{
    public const int MaxLv = 10;
    public Sprite photo;
    public Image Icon;
    public Text HealthPoint;
    public Text MagicPoint;

    [Header("Status")]
    public CharactorDataSo charactorData;
    public float HP;
    public float MP;
    public float Attack;
    public float MagicAttack;
    public float Defence;
    public float MagicDefence;
    public float Speed;
    public int Level;
    public float Experience;
    public int nextActionTrun;

    public float MaxHP = 20;
    public float MaxMP = 20;

    public UnityEvent OverDie;
    public AudioClip audioClip;
    protected Animator animator;
    public bool dead;
    public virtual void Start()
    {
        animator = GetComponent<Animator>();
    }
    public virtual void OnEnable()
    {
        dead = false;
        HP = MaxHP;
        MP = MaxMP;
    }
    public void ReciveDamege(float damage)
    {
        if(dead) return;
        HP = HP - (int)damage;
        
        if(HP <= 0)
        {
            onDie();
        }
    }

    public void UPdateMp(float cost)
    {
        MP -= cost;
    }

    public bool GetDead()
    {
        return dead;
    }

    public void CalCulateNextTurn(int current)
    {
        nextActionTrun = current + Mathf.CeilToInt(100 / Speed) ;
    }

    public int CompareTo(object obj)
    {
        int next = nextActionTrun.CompareTo(((FightStats)obj).nextActionTrun);

        return next;
    }

    public void ContinueTurn()
    {
        BattleManager.Instance.NextTurn();
    }

    public virtual void onDie()
    {
        dead = true;
        animator.SetBool("die", dead);
        OverDie?.Invoke();
    }

    public void WakeUp()
    {
        dead = false;
        animator.SetBool("die", dead);
    }
}

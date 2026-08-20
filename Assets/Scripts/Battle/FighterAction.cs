using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterAction : MonoBehaviour
{
    private GameObject Hero;
    private GameObject Enemey;

    private GameObject currentAttack;

    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        Hero = GameObject.FindGameObjectWithTag("Player");
        Enemey = GameObject.FindGameObjectWithTag("Enemey");
        currentAttack = this.gameObject;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectAction(string ActionName)
    {
        //被攻击的目标
        GameObject victim = Hero;
        if(tag == "Player")
        {
            victim = GameManager.instance.Enemys[0];
        }
        if(ActionName == "Attack")
        {
            Debug.Log("attack!");
            animator.SetTrigger("attack");
            currentAttack.GetComponent<AttackScript>().isMagic = false;
            currentAttack.GetComponent<AttackScript>().Attack(victim);
        }
        else if (ActionName == "Skill")
        {
            Debug.Log("skill");
            animator.SetTrigger("skill");
            Skill skill = currentAttack.GetComponent<AttackScript>().CurrentSkill;
            currentAttack.GetComponent<AttackScript>().SkillAttack(victim, skill);
        }
        else if (ActionName == "Run")
        {
            GameManager.instance.Run();
            Debug.Log("run");
        }
    }

    public void SelectAction(string ActionName,GameObject Target)
    {
        if (ActionName == "Attack")
        {
            Debug.Log("attack!");
            animator.SetTrigger("attack");
            currentAttack.GetComponent<AttackScript>().isMagic = false;
            currentAttack.GetComponent<AttackScript>().Attack(Target);
        }
        else if (ActionName == "Skill")
        {
            Debug.Log("skill");
            animator.SetTrigger("skill");
            Skill skill = currentAttack.GetComponent<AttackScript>().CurrentSkill;
            if (skill.isALL)
            {
                for (int i = 0; i < GameManager.instance.Enemys.Count; i++)
                {
                    currentAttack.GetComponent<AttackScript>().SkillAttack(GameManager.instance.Enemys[i], skill);
                }
            }
            else
            {
                currentAttack.GetComponent<AttackScript>().SkillAttack(Target, skill);
            } 
        }
        else if (ActionName == "Run")
        {
            GameManager.instance.Run();
            Debug.Log("run");
        }
    }
}

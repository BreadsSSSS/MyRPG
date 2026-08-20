using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    private FightStats attackStats;
    private FightStats tartgetStats;

    [Header("status")]
    public float minAttack;
    public float maxAttack;
    public float minDefence;
    public float maxDefence;
    public float minMagicDefence;
    public float maxMagicDefence;

    public bool isMagic;
    public float MagicCost;
    public Skill CurrentSkill;
    public void Attack(GameObject victim)
    {
        attackStats = GetComponent<FightStats>();
        tartgetStats = victim.GetComponent<FightStats>();

        float multiplier = Random.Range(minAttack, maxAttack);
        if (isMagic)
        {
            if (attackStats.MP >= MagicCost)
            {
                float damage = attackStats.MagicAttack * multiplier;
                attackStats.UPdateMp(MagicCost);
                float magicDefenceMultiplier = Random.Range(victim.GetComponent<AttackScript>().minMagicDefence, victim.GetComponent<AttackScript>().maxMagicDefence);
                damage = Mathf.Max(0,damage - magicDefenceMultiplier * tartgetStats.MagicDefence);

                if (this.tag == "Enemey")
                {
                    StartCoroutine(WaitForAttack(victim, damage));
                }
                else
                {
                    WaitAttack(victim, damage);
                }
                
            }
            else
            {
                Debug.Log("Mp,No!");
                Animator animator = GetComponent<Animator>();
                animator.SetTrigger("hurt");
            }
        }
        else
        {
            float damage = multiplier * attackStats.Attack;
            float defenceMultiplier = Random.Range(victim.GetComponent<AttackScript>().minDefence, victim.GetComponent<AttackScript>().maxDefence);
            damage = Mathf.Max(0, damage - defenceMultiplier * tartgetStats.Defence);
            if (this.tag == "Enemey")
            {
                StartCoroutine(WaitForAttack(victim, damage));
            }
            else
            {
                WaitAttack(victim, damage);
            }
        }  
        Invoke("ContinueTurn", 1);
    }

    public void SkillAttack(GameObject victim,Skill skill)
    {
        attackStats = GetComponent<FightStats>();
        tartgetStats = victim.GetComponent<FightStats>();

        float multiplier = Random.Range(minAttack, maxAttack);
        if (skill.isMagic)
        {
            if (attackStats.MP >= skill.MagicUse)
            {
                float damage = attackStats.MagicAttack* multiplier;
                attackStats.UPdateMp(skill.MagicUse);
                float magicDefenceMultiplier = Random.Range(victim.GetComponent<AttackScript>().minMagicDefence, victim.GetComponent<AttackScript>().maxMagicDefence);
                damage = Mathf.Max(0, damage - magicDefenceMultiplier * tartgetStats.MagicDefence);
                damage *= skill.Attack;
                if (this.tag == "Enemey")
                {
                    StartCoroutine(WaitForAttack(victim, damage));
                }
                else
                {
                    if (CurrentSkill.isALL)
                    {
                        for (int i = 0; i < GameManager.instance.Enemys.Count; i++)
                        {
                            GameObject target = GameManager.instance.Enemys[i];
                            if (target.tag != "Die")
                            {
                                WaitAttack(target, damage);
                            }
                        }
                    }
                    else
                    {
                        WaitAttack(victim, damage);
                    }
                }
            }
            else
            {
                Debug.Log("Mp,No!");
                Animator animator = GetComponent<Animator>();
                animator.SetTrigger("hurt");
            }
        }
        else
        {
            float damage = multiplier * attackStats.Attack;
            float defenceMultiplier = Random.Range(victim.GetComponent<AttackScript>().minDefence, victim.GetComponent<AttackScript>().maxDefence);
            damage = Mathf.Max(0, damage - defenceMultiplier * tartgetStats.Defence);
            damage *= skill.Attack;
            attackStats.UPdateMp(skill.MagicUse);
            if (this.tag == "Enemey")
            {
                StartCoroutine(WaitForAttack(victim, damage));
            }
            else
            {
                if (CurrentSkill.isALL)
                {
                    for (int i = 0; i < GameManager.instance.Enemys.Count; i++)
                    {
                        GameObject target = GameManager.instance.Enemys[i];
                        if (target.tag != "Die")
                        {
                            WaitAttack(target, damage);
                        }
                    }
                }
                else
                {
                    WaitAttack(victim, damage);
                }
            }
        }
        Invoke("ContinueTurn", 1);
    }

    private void WaitAttack(GameObject victim,float damage)
    {
        FXPlay();
        if (CurrentSkill != null)
            CurrentSkill.SkillFunc(victim);
        BattleManager.Instance.CloseAllButton();
        //yield return new WaitForSeconds(GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length);
        float len = GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length;
        while(len > 0)
        {
            len -= Time.deltaTime;
        }
        victim.GetComponent<Animator>().SetTrigger("hurt");
        victim.GetComponent<FightStats>().ReciveDamege(damage);
        Vector2 temp = victim.transform.position;
        Vector2 pos = new Vector3(temp.x, temp.y + 1);
        string point = ((int)damage).ToString();
        WindowManager.Instance.OpenWindow(WindowType.DamagePoint);
        WindowManager.Instance.damagePointWindow.DGcontroller.DGpoint.text = "-" + point;
        WindowManager.Instance.damagePointWindow.DGcontroller.DGpoint.transform.position = pos;

        //BattleManager.Instance.DamagePoint.transform.position = new Vector3(pos.x, pos.y + 1);
        //BattleManager.Instance.DamagePoint.text = "- " + point + "";
        //BattleManager.Instance.DamagePoint.gameObject.SetActive(true);
        //yield return new WaitForSeconds(2f);
        //BattleManager.Instance.DamagePoint.gameObject.SetActive(false);
    }

    public IEnumerator WaitForAttack(GameObject victim, float damage)
    {
        FXPlay();
        if (CurrentSkill != null)
            CurrentSkill.SkillFunc(victim);
        BattleManager.Instance.CloseAllButton();
        yield return new WaitForSeconds(GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length );
        victim.GetComponent<Animator>().SetTrigger("hurt");
        victim.GetComponent<FightStats>().ReciveDamege(damage);
        Vector2 temp = victim.transform.position;
        Vector2 pos = new Vector3(temp.x, temp.y + 1);
        string point = ((int)damage).ToString();
        WindowManager.Instance.OpenWindow(WindowType.DamagePoint);
        WindowManager.Instance.damagePointWindow.DGcontroller.DGpoint.text = "-" + point;
        WindowManager.Instance.damagePointWindow.DGcontroller.DGpoint.transform.position = pos;
        //yield return new WaitForSeconds(2f);
        //BattleManager.Instance.DamagePoint.transform.position = new Vector3(pos.x, pos.y + 1);
        //BattleManager.Instance.DamagePoint.text = "- " + point + "";
        //BattleManager.Instance.DamagePoint.gameObject.SetActive(true);
        //BattleManager.Instance.DamagePoint.gameObject.SetActive(false);
    }
    public void ContinueTurn()
    {
        BattleManager.Instance.NextTurn();
    }

    private void WaitAttackInStatus(GameObject victim, float damage)
    {
        victim.GetComponent<Animator>().SetTrigger("hurt");
        victim.GetComponent<FightStats>().ReciveDamege(damage);
        Vector2 temp = victim.transform.position;
        Vector2 pos = new Vector3(temp.x, temp.y + 1);
        string point = ((int)damage).ToString();
        WindowManager.Instance.OpenWindow(WindowType.DamagePoint);
        WindowManager.Instance.damagePointWindow.DGcontroller.DGpoint.text = "-" + point;
        WindowManager.Instance.damagePointWindow.DGcontroller.DGpoint.transform.position = pos;
    }

    public void FXPlay()
    {
        if(attackStats.audioClip != null)
        {
            GameManager.instance.cameraController.FX.clip = attackStats.audioClip;
            GameManager.instance.cameraController.FX.Play();
        }
    }
}

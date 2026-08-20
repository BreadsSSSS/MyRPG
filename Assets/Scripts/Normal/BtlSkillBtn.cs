using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BtlSkillBtn : MonoBehaviour,IPointerClickHandler
{
    public Skill skill;
    public int ID;
    public void OnPointerClick(PointerEventData eventData)
    {
        if ( skill != null && skill.MagicUse <= GameManager.instance.Player.GetComponent<PlayerStatus>().MP)
        {
            GameManager.instance.Player.GetComponent<AttackScript>().CurrentSkill = skill;
            if (skill.isALL)
            {
                WindowManager.Instance.CloseWindow(WindowType.SkillSelectWindow);
                BattleManager.Instance.CurrentUnit.GetComponent<FighterAction>().SelectAction("Skill");
                BattleManager.Instance.CloseAllButton();
            }
            else
            {
                WindowManager.Instance.CloseWindow(WindowType.SkillSelectWindow);
                BattleManager.Instance.CloseAllButton();
                GameManager.instance.SeleceSkillTarget();
            }
        }
        else
        {
            Debug.Log("MP no");
        }
    }

    private void Awake()
    {
        SkillManager.Instance.btlSkills.Add(this);
        if (ID < SkillManager.Instance.skills.Count)
        {
            skill = SkillManager.Instance.skills[ID];
            if (skill.MagicUse <= GameManager.instance.Player.GetComponent<PlayerStatus>().MP)
            {
                transform.gameObject.GetComponent<Image>().sprite = skill.SkillSprite;
                transform.gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

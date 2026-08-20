using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour,IPointerClickHandler
{
    public Skill skillData;

    public void OnPointerClick(PointerEventData eventData)
    {
        SkillManager.Instance.activeSkill = skillData;
        SkillManager.Instance.DisPlaySkillInfo();
    }

    // Start is called before the first frame update
    void Start()
    {
        SkillManager.Instance.skillButtons.Add(this);
        foreach (var skill in SkillManager.Instance.skills)
        {
            if(skill.SkillID == skillData.SkillID)
            {
                transform.gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        SkillManager.Instance.skillButtons.Remove(this);
    }
}

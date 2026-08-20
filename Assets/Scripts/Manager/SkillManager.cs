using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : SigonTon<SkillManager>
{
    public Skill activeSkill;
    public Image SkillImage;
    public Text SkillName;
    public Text SkillDescription;
    public Text SkillPoint;
    public int nowPoint;
    private GameObject Player;

    public List<SkillButton> skillButtons = new List<SkillButton>();
    public List<Skill> skills = new List<Skill>();
    public List<BtlSkillBtn> btlSkills = new List<BtlSkillBtn>();
    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        nowPoint = Player.GetComponent<PlayerStatus>().Level;
        nowPoint = 6;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisPlaySkillInfo()
    {
        if(activeSkill != null)
        {
            SkillImage.sprite = activeSkill.SkillSprite;
            SkillPoint.text = activeSkill.PointUse.ToString() + "/" + nowPoint.ToString();
            SkillDescription.text = activeSkill.SkillDes;
            SkillName.text = activeSkill.SkillName;
        }
    }

    public void UpgradeButton()
    {
        if (!skills.Contains(activeSkill) && activeSkill != null)
        {
            if (nowPoint >= activeSkill.PointUse && skills.Contains(activeSkill.PreSkills))
            {
                skillButtons[activeSkill.SkillID].GetComponent<Image>().color = Color.white;
                skills.Add(activeSkill);
                nowPoint -= activeSkill.PointUse;
                DisPlaySkillInfo();
            }
        }
        
    }
}

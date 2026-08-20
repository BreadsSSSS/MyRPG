using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill/New Skill", menuName ="Skill/New Skill")]
public class Skill : ScriptableObject
{
    public Sprite SkillSprite;
    public int PointUse;
    [TextArea(1,5)]public string SkillDes;
    public string SkillName;
    public float MagicUse;
    public int SkillID;
    public Skill PreSkills;
    public bool isLocked;
    public bool isMagic;
    public bool isALL;
    public GameObject Special;
    public float Attack;

    public virtual void SkillFunc(GameObject target)
    {
        if(Special != null)
        {
            GameObject spe = GameObject.Instantiate(Special);
            spe.transform.position = target.transform.position;
        }
        if(SkillName == "01")
        {

        }
    }
}

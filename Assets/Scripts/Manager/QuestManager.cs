using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : SigonTon<QuestManager>
{
    public List<QuestSolt> questSolts = new List<QuestSolt>();
    public List<Quest> questList = new List<Quest>();
    //public Dictionary<string,Quest> QuestDic = new Dictionary<string,Quest>();

    public Quest CurrentQuest;
    public Text questName;
    public Text QuestDescription;
    public Text QuestProcess;
    public Text QuestStatus;

    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateQuestInfo()
    {
        questName.text = CurrentQuest.QuestName;
        QuestDescription.text = CurrentQuest.QuestDescription + "\n" 
            +"EXP£º" + CurrentQuest.EXP.ToString() + "\n"
            +"Money: " + CurrentQuest.Money.ToString();
        QuestStatus.text = CurrentQuest.questStatus.ToString();
        
    }

    public void UpdateQuestList()
    {
        for (int i = 0; i < questSolts.Count; i++)
        {
            if(i < questList.Count)
            {
                questSolts[i].Quest = questList[i];
                questSolts[i].QstName.text = questList[i].QuestName;
                if (questList[i].questStatus == global::QuestStatus.Compeleted)
                {
                    string str = questSolts[i].QstName.text;
                    questSolts[i].QstName.text = "<color=red>"+str+"</color>";
                }
            }
            else
            {
                questSolts[i].Quest = null;
                questSolts[i].QstName.text = "";
            }
        }
    }
}

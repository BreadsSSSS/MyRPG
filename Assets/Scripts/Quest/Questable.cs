using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questable : MonoBehaviour
{
    public Quest quest;

    
    public void DelegateQuest()
    {
        if(quest.questStatus == QuestStatus.Watting && !QuestManager.Instance.questList.Contains(quest))
        {
            //领取任务
            quest.questStatus = QuestStatus.Accepted;
            QuestManager.Instance.questList.Add(quest);
        }
        else
        {
            //已经接受
            Debug.Log("已经接受该任务");
        }
    }

    public bool CheckQuest()
    {
        for (int i = 0;i < QuestManager.Instance.questList.Count; i++)
        {
            Quest temp = QuestManager.Instance.questList[i];
            if(temp.QuestName == quest.QuestName && temp.questStatus == QuestStatus.Compeleted)
            {
                GetComponent<TalkAble>()?.GetNewTextInFile();
                return true;
            }
        }
        return false;
    }
}

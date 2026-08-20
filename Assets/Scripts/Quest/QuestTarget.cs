using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTarget : MonoBehaviour
{
    public string QuestName;
    public QuestType QuestType;

    public bool isTalked;
    public void QuestCompelete()
    {
        for(int i = 0;i< QuestManager.Instance.questList.Count;i++)
        {
            var quest = QuestManager.Instance.questList[i];
            if (quest.QuestName == QuestName && quest.questStatus == QuestStatus.Accepted)
            {
                if(QuestType == QuestType.Battle)
                {
                    quest.Current++;
                    if(quest.Current >= quest.Count)
                    {
                        quest.questStatus = QuestStatus.Compeleted;
                        GetComponent<TalkAble>()?.GetNewTextInFile();
                        quest.GetAllItem();
                    }
                }
                else if(QuestType == QuestType.Talk)
                {
                    if (isTalked)
                    {
                        quest.questStatus = QuestStatus.Compeleted;
                        GetComponent<TalkAble>()?.GetNewTextInFile();
                        quest.GetAllItem();
                    }
                }
            }
        }
    }
}

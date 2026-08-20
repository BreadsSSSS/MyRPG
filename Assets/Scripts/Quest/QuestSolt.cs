using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestSolt : MonoBehaviour,IPointerClickHandler
{
    public Text QstName;
    public Quest Quest;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(Quest != null)
        {
            QuestManager.Instance.CurrentQuest = Quest;
            QuestManager.Instance.UpdateQuestInfo();
        }
    }

    private void Awake()
    {
        QuestManager.Instance.questSolts.Add(this);
    }

    private void OnDestroy()
    {
        QuestManager.Instance.questSolts.Remove(this);
    }
}

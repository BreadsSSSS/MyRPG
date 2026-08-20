using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestController : MonoBehaviour
{
    public Text QuestName;
    public Text QuestDescription;
    public Text QuestProcess;
    public Text QuestStatus;
    private void Awake()
    {
        QuestManager.Instance.questName = QuestName;
        QuestManager.Instance.QuestDescription = QuestDescription;
        QuestManager.Instance.QuestProcess = QuestProcess;
        QuestManager.Instance.QuestStatus = QuestStatus;
    }

    void Start()
    {
        QuestManager.Instance.UpdateQuestList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        QuestManager.Instance.questName = null;
        QuestManager.Instance.QuestDescription = null;
        QuestManager.Instance.CurrentQuest = null;
        QuestManager.Instance.QuestStatus = null;
        QuestManager.Instance.QuestProcess= null;

    }
    public void CloseQuest()
    {
        WindowManager.Instance.CloseWindow(WindowType.QuestWindow);
    }
}

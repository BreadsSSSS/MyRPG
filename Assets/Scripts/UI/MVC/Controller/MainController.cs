using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public Dictionary<string,GameObject> objDic = new Dictionary<string,GameObject>();
    public Button Talk;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddListener()
    {
        objDic["Bag"].GetComponent<Button>().onClick.AddListener(OnBagClick);
        objDic["Skill"].GetComponent<Button>().onClick.AddListener(OnSkillClick);
        objDic["Talk"].GetComponent<Button>().onClick.AddListener(OnTalikClick);
        objDic["Quest"].GetComponent<Button>().onClick.AddListener(OnQuestClick); 
        objDic["Setting"].GetComponent<Button>().onClick.AddListener(OnSettingClick);
    }

    public void RemoveListener()
    {
        objDic["Bag"].GetComponent<Button>().onClick.RemoveListener(OnBagClick);
        objDic["Skill"].GetComponent<Button>().onClick.RemoveListener(OnSkillClick);
        objDic["Talk"].GetComponent<Button>().onClick.RemoveListener(OnTalikClick);
        objDic["Quest"].GetComponent<Button>().onClick.RemoveListener(OnQuestClick);
        objDic["Setting"].GetComponent<Button>().onClick.RemoveListener(OnSettingClick);
    }

    private void OnBagClick()
    {
        WindowManager.Instance.OpenWindow(WindowType.BagWindow);
        Debug.Log("Bag");
    }

    private void OnSkillClick()
    {
        WindowManager.Instance.OpenWindow(WindowType.SkillWindow);
        Debug.Log("Skill");
    }
    private void OnTalikClick()
    {
        WindowManager.Instance.OpenWindow(WindowType.TalkWindow);
    }

    private void OnQuestClick()
    {
        WindowManager.Instance.OpenWindow(WindowType.QuestWindow);
    }
    private void OnSettingClick()
    {
        WindowManager.Instance.OpenWindow(WindowType.SettingWindow);
    }
}

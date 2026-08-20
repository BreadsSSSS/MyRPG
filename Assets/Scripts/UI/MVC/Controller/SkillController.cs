using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{
    public Button Close;
    public Image SkillImage;
    public Text SkillName;
    public Text SkillDescription;
    public Text SkillPoint;

    public Button LearnButton;
    void Start()
    {
        SkillManager.Instance.SkillImage = SkillImage;
        SkillManager.Instance.SkillName = SkillName;
        SkillManager.Instance.SkillDescription = SkillDescription;
        SkillManager.Instance.SkillPoint = SkillPoint;
        SkillManager.Instance.DisPlaySkillInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addListener()
    {
        /*foreach (var item in WindowManager.Instance.skillWindow.Buttons)
        {
            if(item.name == "Close")
            {
                item.onClick.AddListener(OnClose);
            }
        }*/
        Close.onClick.AddListener(OnClose);
        LearnButton.onClick.AddListener(SkillManager.Instance.UpgradeButton);
    }

    public void RemoveListener()
    {
        Close.onClick.RemoveAllListeners();
        LearnButton.onClick.RemoveListener(SkillManager.Instance.UpgradeButton);
    }
    private void OnClose()
    {
        WindowManager.Instance.CloseWindow(WindowType.SkillWindow);
    }
    private void OnDestroy()
    {
        SkillManager.Instance.SkillImage = null;
        SkillManager.Instance.SkillName = null;
        SkillManager.Instance.SkillDescription = null;
        SkillManager.Instance.SkillPoint = null;
    }
}

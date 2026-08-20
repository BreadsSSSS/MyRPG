using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillWindow : BaseWindow
{
    SkillController skillController;

    public SkillWindow()
    {
        resName = "UI/SkillTree";
        resident = false;
        windowType = WindowType.SkillWindow;
        sceneType = SceneType.None;
    }
    public override void Update(float deltaTime)
    {
        base.Update(deltaTime);
    }

    protected override void AddListener()
    {
        base.AddListener();
        skillController.addListener();
    }

    protected override void Awake()
    {
        base.Awake();
        skillController = transform.GetComponent<SkillController>();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnRemoveListener()
    {
        base.OnRemoveListener();
        skillController.RemoveListener();
    }

    protected override void RegisterUIEvent()
    {
        base.RegisterUIEvent();
    }
}

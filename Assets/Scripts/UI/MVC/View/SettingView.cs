using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingView : BaseWindow
{
    public SettingController controller;
    public SettingView() 
    {
        resName = "UI/SettingPanel";
        resident = true;
        windowType = WindowType.SettingWindow;
        sceneType = SceneType.None;
    }

    public override void Update(float deltaTime)
    {
        base.Update(deltaTime);
    }

    protected override void AddListener()
    {
        base.AddListener();
    }

    protected override void Awake()
    {
        base.Awake();
        controller = transform.GetComponent<SettingController>();
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
    }

    protected override void RegisterUIEvent()
    {
        base.RegisterUIEvent();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinWindow : BaseWindow
{

    public WinWindow()
    {
        resName = "UI/WinPanel";
        resident = false;
        windowType = WindowType.WinWindow;
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

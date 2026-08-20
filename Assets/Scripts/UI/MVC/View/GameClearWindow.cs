using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearWindow : BaseWindow
{
    public GameClearWindow()
    {
        resName = "UI/GameClearPanel";
        resident = false;
        windowType = WindowType.GameClearWindow;
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

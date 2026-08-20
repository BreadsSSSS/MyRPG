using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkWindw : BaseWindow
{
    TalkController controller;
    public TalkWindw()
    {
        resName = "UI/TalkWindw";
        resident = false;
        windowType = WindowType.TalkWindow;
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
        controller = transform.GetComponent<TalkController>(); 
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

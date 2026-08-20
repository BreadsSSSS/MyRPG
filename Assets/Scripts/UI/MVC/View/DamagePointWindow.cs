using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePointWindow : BaseWindow
{
    public DamagePointController DGcontroller;

    public DamagePointWindow()
    {
        resName = "UI/DamagePoint";
        resident = false;
        windowType = WindowType.DamagePoint;
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
        DGcontroller = transform.GetComponent<DamagePointController>();
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

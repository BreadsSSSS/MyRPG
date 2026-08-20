using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagWindow : BaseWindow
{
    BagController bagController;
    public BagWindow()
    {
        resName = "UI/InventoryMenu";
        resident = false;
        windowType = WindowType.BagWindow;
        sceneType = SceneType.None;
    }

    public override void Update(float deltaTime)
    {
        base.Update(deltaTime);
    }

    protected override void AddListener()
    {
        base.AddListener();
        bagController.AddListener(buttons);
    }

    protected override void Awake()
    {
        base.Awake();
        bagController = transform.gameObject.GetComponent<BagController>();
        bagController.texts = texts;
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
        bagController.RemoveListener(buttons);
    }

    protected override void RegisterUIEvent()
    {
        base.RegisterUIEvent();
    }
}

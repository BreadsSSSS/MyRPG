using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuWindow : BaseWindow
{
    MainController controller;
    public MenuWindow()
    {
        resName = "UI/Main";
        resident = true;
        windowType = WindowType.TipsWindow;
        sceneType = SceneType.Login;
    }

    protected override void AddListener()
    {
        base.AddListener();
        controller.AddListener();
    }

    protected override void Awake()
    {
        base.Awake();
        int count = transform.childCount;
        controller = transform.gameObject.GetComponent<MainController>();
        for (int i = 0; i < count; i++)
        {
            GameObject obj = transform.GetChild(i).gameObject;
            controller.objDic.Add(obj.name, obj);
        }
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
        controller.RemoveListener();
    }

    protected override void RegisterUIEvent()
    {
        base.RegisterUIEvent();
    }

    public override void Update(float deltaTime)
    {
        /*if (Input.GetKeyDown(KeyCode.K))
        {
            if (transform.gameObject.activeSelf==false)
            {
                WindowManager.Instance.OpenWindow(windowType);
            }
            else
            {
                WindowManager.Instance.CloseWindow(windowType);
            }
        }*/
    }
}

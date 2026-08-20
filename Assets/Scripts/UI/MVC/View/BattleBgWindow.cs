using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBgWindow : BaseWindow
{
    public BattleBgWindow()
    {
        resName = "UI/Battle";
        resident = false;
        windowType = WindowType.BattleWindow;
        sceneType = SceneType.Battle;
    }
    protected override void Awake()
    {
        base.Awake();
    }

}

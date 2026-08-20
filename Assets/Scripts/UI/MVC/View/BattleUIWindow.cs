using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUIWindow : BaseWindow
{
    public BattleUIWindow()
    {
        resName = "UI/BattleUI";
        resident = false;
        windowType = WindowType.StatusWindow;
        sceneType = SceneType.Battle;
    }

    
}

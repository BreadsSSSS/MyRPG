using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowManager : SigonTon<WindowManager>
{
    Dictionary<WindowType,BaseWindow> WindowDic = new Dictionary<WindowType,BaseWindow>();
    List<BaseWindow> windows = new List<BaseWindow>();
    public MenuWindow menuWindow;
    public BagWindow bagWindow;
    public BattleBgWindow backGround;
    public BattleUIWindow battleUIWindow;
    public DamagePointWindow damagePointWindow;
    public SkillWindow skillWindow;
    public WinWindow win;
    public TalkWindw talkWindw;
    public SkillSelectWindow skillSelectWindow;
    public QuestWindow questWindow;
    public ShopWindow shopWindow;
    public SettingView settingView;
    public GameClearWindow gameClearWindow;
    public LoseWindow loseWindow;
    public bool isMenu;
    public int Count;

    public int windowsCount
    {
        get { return windows.Count; }
    }
    protected override void Awake()
    {
        base.Awake();
        PreLoadWindow(SceneType.Login);
        //OpenWindow(WindowType.BattleWindow);
        OpenWindow(WindowType.TipsWindow);
        Count = windows.Count;
    }
    //初始化
    public WindowManager() 
    {
        backGround = new BattleBgWindow();
        menuWindow = new MenuWindow();
        bagWindow = new BagWindow();
        battleUIWindow = new BattleUIWindow();
        damagePointWindow = new DamagePointWindow();
        skillWindow = new SkillWindow();    
        win = new WinWindow();
        talkWindw = new TalkWindw();
        skillSelectWindow = new SkillSelectWindow();
        questWindow = new QuestWindow();
        shopWindow = new ShopWindow();
        settingView = new SettingView();
        gameClearWindow = new GameClearWindow();
        loseWindow = new LoseWindow();
        WindowDic.Add(menuWindow.GetWindowType(), menuWindow);
        WindowDic.Add(bagWindow.GetWindowType(), bagWindow);
        WindowDic.Add(backGround.GetWindowType(), backGround);
        WindowDic.Add(battleUIWindow.GetWindowType(), battleUIWindow);
        WindowDic.Add(damagePointWindow.GetWindowType(), damagePointWindow);
        WindowDic.Add(skillWindow.GetWindowType(), skillWindow);
        WindowDic.Add(win.GetWindowType(), win);
        WindowDic.Add(talkWindw.GetWindowType(), talkWindw);
        WindowDic.Add(skillSelectWindow.GetWindowType(), skillSelectWindow);
        WindowDic.Add(questWindow.GetWindowType(), questWindow);
        WindowDic.Add(shopWindow.GetWindowType(), shopWindow);
        WindowDic.Add(settingView.GetWindowType(), settingView);
        WindowDic.Add(gameClearWindow.GetWindowType(), gameClearWindow);
        WindowDic.Add(loseWindow.GetWindowType(), loseWindow);
    }
    //打开窗口
    public BaseWindow OpenWindow(WindowType type)
    {
        BaseWindow window;
        if(WindowDic.TryGetValue(type, out window)) 
        {
            window.Open();
            Canvas canvas = window.Transform.gameObject.GetComponent<Canvas>();
            if(canvas == null)
            {
                canvas = window.Transform.gameObject.AddComponent<Canvas>();
            }
            if(window.Transform.gameObject.GetComponent<GraphicRaycaster>()== null)
            {
                window.Transform.gameObject.AddComponent<GraphicRaycaster>();
            }
            if (!windows.Contains(window))
            {
                windows.Add(window);
                canvas.overrideSorting = true;
                if (GameManager.instance.isBattle)
                {
                    canvas.sortingOrder = windows.Count + 10;
                }
                else
                {
                    canvas.sortingOrder = windows.Count;
                }
            }
            CheckWindow();
            return window;
        }
        else
        {
            Debug.Log($"Open erro:{type}");
            return null;
        }
    }
    //关闭窗口
    public void CloseWindow(WindowType type)
    {
        BaseWindow window;
        if (WindowDic.TryGetValue(type, out window))
        {
            windows.Remove(window);
            window.Close();
        }
        else
        {
            Debug.Log($"Open erro:{type}");
        }
        CheckWindow();
    }
    //预加载
    public void PreLoadWindow(SceneType type)
    {
        foreach(var item in WindowDic.Values)
        {
            if(item.GetSceneType() == type)
            {
                item.PreLoad();
            }
        }
    }
    //隐藏某个类型的窗口
    public void HideAllWindow(SceneType type)
    {
        foreach (var item in WindowDic.Values)
        {
            if (item.GetSceneType() == type)
            {
                item.Close();
            }
        }
    }
    private void Update()
    {
        foreach(var window in WindowDic.Values)
        {
            window.Update(Time.deltaTime);
        }
    }

    public void CheckWindow()
    {
        if(windows.Count > 1)
        {
            isMenu = true;
        }
        else
        {
            isMenu = false;
        }
    }
}

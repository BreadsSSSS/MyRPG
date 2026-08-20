using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseWindow 
{
    protected Transform transform;
    public Transform Transform { get { return transform; } }
    protected string resName;
    public string resname
    {
        get { return resname; }
    }
    protected bool resident;//是否常驻
    protected bool Visible = false;
    protected WindowType windowType;
    protected SceneType sceneType;
    //UI控件
    protected Button[] buttons;
    protected Text[] texts;
    protected Image[] images;
    public Button[] Buttons { get { return buttons; } }
    public Text[] Texts { get { return texts; } }
    public Image[] Images { get { return images; } }
    //需要给与子类提供的接口
    //初始化
    protected virtual void Awake()
    {
        //隐藏物体也会查找
        //transform.position = new Vector3(0, 0, 0);
        buttons = transform.GetComponentsInChildren<Button>(true);
        texts = transform.GetComponentsInChildren<Text>(true);
        images = transform.GetComponentsInChildren<Image>(true);
        RegisterUIEvent();
    }
    //UI事件的注册
    protected virtual void RegisterUIEvent()
    {

    }
    //添加监听游戏事件
    protected virtual void AddListener()
    {

    }
    //移除游戏事件
    protected virtual void OnRemoveListener()
    {

    }
    //打开
    protected virtual void OnEnable()
    {

    }
    //关闭
    protected virtual void OnDisable()
    {

    }
    //更新
    public virtual void Update(float deltaTime)
    {

    }
    public void Open()
    {
        if(transform == null)
        {
            if (Create())
            {
                Awake();
            }
        }
        if(transform.gameObject.activeSelf==false)
        {
            CanvasTool.SetParent(transform, true, windowType == WindowType.TipsWindow);
            transform.gameObject.SetActive(true);
            Visible = true;
            OnEnable();
            AddListener();
        }

    }
    public void Close()
    {
        if(transform.gameObject.activeSelf == true)
        {
            OnRemoveListener();
            OnDisable();
            if (resident)
            {
                transform.gameObject.SetActive(false);
                CanvasTool.SetParent(transform, false, windowType == WindowType.TipsWindow);
            }
            else
            {
                GameObject.Destroy(transform.gameObject);
                transform = null;
            }
        }
    }
    public void PreLoad()
    {
        if(transform == null)
        {
            if (Create())
            {
                Awake ();
            }
        }
    }
    public SceneType GetSceneType()
    {
        return sceneType;
    }
    public WindowType GetWindowType() 
    { 
        return windowType; 
    }
    public Transform GetTransform()
    {
        return transform;
    }
    public bool isVisble()
    {
        return Visible;
    }
    public bool isResident()
    {
        return resident;
    }
    private bool Create()
    {
        if(string.IsNullOrEmpty(resName))
        {
            return false;
        }
        if(transform == null)
        {
            var obj = Resources.Load<GameObject>(resName);
            if(obj == null)
            {
                Debug.Log($"未找到UI预制体{windowType}");
                return false;
            }
            transform = GameObject.Instantiate(obj).transform;
            transform.gameObject.SetActive(false);
            CanvasTool.SetParent(transform, false,windowType == WindowType.TipsWindow);
        }
        return true;
    }
    public void CloseAllButtons()
    {
        foreach(var item in buttons)
        {
            item.interactable = false;
        }
    }
}
//窗体类型
public enum WindowType
{
    LoginWindow,
    StoreWindow,
    TipsWindow,
    MenuWinodw,
    BagWindow,
    BattleWindow,
    StatusWindow,
    DamagePoint,
    SkillWindow,
    WinWindow,
    TalkWindow,
    SkillSelectWindow,
    QuestWindow,
    ShopWindow,
    SettingWindow,
    GameClearWindow,
    LoseWindow
}
//根据场景进行预加载
public enum SceneType
{
    None,
    Town,
    Login,
    Battle
}

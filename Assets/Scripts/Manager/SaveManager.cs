using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : SigonTon<SaveManager>
{
    public string FileName;
    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveByJson()
    {
        Save save = new Save();
        save.GetValue();
        var json = JsonUtility.ToJson(save ,true);
        Debug.Log(json);
        var path = Path.Combine(Application.persistentDataPath,FileName);

        try
        {
            File.WriteAllText(path, json);
            #if UNITY_EDITOR
            Debug.Log($"Success to save {path}");
#endif
        }
        catch(Exception e)
        {
#if UNITY_EDITOR
            Debug.LogError($"filed to save {path},\n{e}");
#endif

        }
    }

    public void LoadFromJson()
    {
        var path = Path.Combine(Application.persistentDataPath,FileName);
        if (!File.Exists(Path.Combine(Application.persistentDataPath, FileName)))
        {
            return;
        }
        try
        {
            var json = File.ReadAllText(path);
            Save save = JsonUtility.FromJson<Save>(json);
            MySceneManager.Instance.LoadGameDataScene(save.sceneLoad,save);
            Debug.Log($"Success to load {path}");
        }
        catch (Exception e) 
        {
#if UNITY_EDITOR
            Debug.LogError($"filed to load {path},\n{e}");
#endif
        }
    }

}

[Serializable]
public class Save
{
    public float HP;
    public float MP;
    public float Attack;
    public float MagicAttack;
    public float Defence;
    public float MagicDefence;
    public float Speed;
    public int Level;
    public float Experience;
    public List<ItemSo> items;
    public List<ToolItem> equipenment;
    public List<Skill> skills;
    public List<Quest> quests;
    public int SkillPoint;
    public int Money;
    public Vector2 Pos;
    public SceneLoad sceneLoad;
    public void GetValue()
    {
        var playStatus = GameManager.instance.Player.GetComponent<PlayerStatus>();
        HP = playStatus.HP; 
        MP = playStatus.MP;
        Attack = playStatus.Attack;
        MagicAttack = playStatus.MagicAttack;
        Defence = playStatus.Defence;
        MagicDefence = playStatus.MagicDefence;
        Speed = playStatus.Speed;
        Level = playStatus.Level;
        Experience = playStatus.Experience;
        items = InventoryManager.Instance.items;
        equipenment = InventoryManager.Instance.equipments;
        skills = SkillManager.Instance.skills;
        quests = QuestManager.Instance.questList;
        SkillPoint = SkillManager.Instance.nowPoint;
        Money = GameManager.instance.Money;
        Pos = playStatus.transform.position;
        sceneLoad = MySceneManager.Instance.CurrentScene;
    }

    public void ReturnValue()
    {
        var playStatus = GameManager.instance.Player.GetComponent<PlayerStatus>();
        playStatus.HP = HP;
        playStatus.MP = MP;
        playStatus.Attack = Attack;
        playStatus.MagicAttack = MagicAttack;
        playStatus.Defence = Defence;
        playStatus.MagicDefence = MagicDefence;
        playStatus.Speed = Speed;
        playStatus.Level = Level;
        playStatus.Experience = Experience;
        InventoryManager.Instance.items = items;
        InventoryManager.Instance.equipments = equipenment;
        SkillManager.Instance.skills = skills;
        QuestManager.Instance.questList = quests;
        SkillManager.Instance.nowPoint = SkillPoint;
        GameManager.instance.Money = Money;
        playStatus.transform.position = Pos;
        playStatus.WakeUp();
        playStatus.nextActionTrun = 0;
        playStatus.LeveUp(Level);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTital : MonoBehaviour
{
    public SceneLoad SceneLoad;
    public Skill Base;
    public void NewGame()
    {
        InventoryManager.Instance.items.Clear();
        for(int i = 0; i < InventoryManager.Instance.equipments.Count; i++)
        {
            InventoryManager.Instance.equipments[i] = null;
        }
        SkillManager.Instance.skills.Clear();
        SkillManager.Instance.skills.Add(Base);
        QuestManager.Instance.questList.Clear();
        SkillManager.Instance.nowPoint = 6;
        GameManager.instance.Money = 0;
        GameManager.instance.Player.SetActive(true);
        MySceneManager.Instance.LoadScene(SceneLoad);
        GameManager.instance.Player.GetComponent<PlayerStatus>().LeveUp(1);
        
    }

    public void Continue()
    {
        SaveManager.Instance.LoadFromJson();
        GameManager.instance.Player.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}

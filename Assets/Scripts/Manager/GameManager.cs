using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject BtlManager; 

    public List<GameObject> Enemys = new List<GameObject>();
    public List<GameObject> EmyPool = new List<GameObject>();
    public List<GameObject> Dies = new List<GameObject>();
    public int Total;
    public bool isBattle = false;
    public bool isShop = false;
    public bool isBoos;
    public CameraController cameraController;
    public GameObject Player;
    public int Money;
    public int Deep = 0;
    public SceneType SceneType;
    public GameObject Boos;
    public float Duration;
    public GameObject FadeIage;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //EnterBattle();
    }

    public void EnterBattle()
    {
        WindowManager.Instance.OpenWindow(WindowType.BattleWindow);
        isBattle = true;
        Player.GetComponent<PlayerMovement>().InBattle();
        cameraController.InBattle();
        int count = UnityEngine.Random.Range(1, 3);
        Vector3 pos = cameraController.transform.position;
        for (int i = 0; i < count; i++)
        {
            int temp = UnityEngine.Random.Range(0, EmyPool.Count);
            EmyPool[temp].SetActive(true);
            EmyPool[temp].transform.position = new Vector3(pos.x - 3*(i+1), pos.y - i*0.5f);
        }
        BtlManager.SetActive(true);
        Total = Enemys.Count;
    }

    public void EnterBoosBattle()
    {
        WindowManager.Instance.OpenWindow(WindowType.BattleWindow);
        isBattle = true;
        Player.GetComponent<PlayerMovement>().InBattle();
        cameraController.BossBattle();
        Boos.gameObject.SetActive(true);
        Vector3 pos = cameraController.transform.position;
        Boos.transform.position = new Vector3(pos.x - 3 * + 1, pos.y - 1 * 0.5f);
        BtlManager.SetActive(true);
        Total = Enemys.Count;
    }

    public void QuitBattle()
    {
        isBattle = false;
        cameraController.QuitBattle();
        Player.GetComponent<PlayerMovement>().QuitBattle();
        WindowManager.Instance.CloseWindow(WindowType.BattleWindow);
        BtlManager.gameObject.SetActive(false);
        isBoos = false;
    }

    public void OpenHit()
    {
        cameraController.gameObject.GetComponent<MVCTest>().enabled = true;
    }

    public void CloseHit()
    {
        cameraController.gameObject.GetComponent<MVCTest>().enabled = false;
    }

    public void Run()
    {
        for(int i = 0;i < Enemys.Count;i++)
        {
            Enemys[i].SetActive(false);
            Enemys.RemoveAt(i);
        }
        for(int i = 0; i < Dies.Count; i++)
        {
            Dies[i].SetActive(false);
            Dies.RemoveAt(i);
        }
        if(Enemys.Count > 0)
        {
            foreach(var obj in Enemys)
            {
                obj.SetActive(false);
            }
        }
        if (Dies.Count > 0)
        {
            foreach (var obj in Dies)
            {
                obj.SetActive(false);
            }
        }
        Enemys.Clear();
        Dies.Clear();
        Boos.SetActive(false);
        QuitBattle();
    }

    public void RemoveEnemy(GameObject enmey)
    {
        Dies.Add(enmey);
        if(Dies.Count == Total)
        {
            StartCoroutine(Win());
        }
    }
    public IEnumerator Win()
    {
        yield return new WaitForSeconds(2f);
        Player.GetComponent<PlayerStatus>().UpdateLeve(BattleManager.Instance.TotalEXP);
        Money += BattleManager.Instance.TotalMoney;
        foreach(var item in BattleManager.Instance.items)
        {
            InventoryManager.Instance.AddItem(item);
        }
        if(!isBoos)
        {
            WindowManager.Instance.OpenWindow(WindowType.WinWindow);
        }
        Dies.Clear();
        Enemys.Clear();
    }

    public void SeleceSkillTarget()
    {
        cameraController.transform.gameObject.GetComponent<SkillSelect>().enabled = true;
    }

    public void ColseSkillTarget()
    {
        cameraController.transform.gameObject.GetComponent<SkillSelect>().enabled = false;
    }
    public void Fade(int x)
    {
        //StartCoroutine(FadeIn(x));
    }
    public IEnumerator FadeIn(float target)
    {
        FadeIage.SetActive(true);
        var cg = FadeIage.GetComponent<CanvasGroup>();
        cg.blocksRaycasts = true;
        float speed = MathF.Abs(cg.alpha - target) / Duration;
        while (!Mathf.Approximately(cg.alpha, target))
        {
            cg.alpha = Mathf.MoveTowards(cg.alpha, target, speed * Time.deltaTime);
            yield return null;
        }
        cg.blocksRaycasts = false;
        FadeIage.SetActive(false);
    }
}

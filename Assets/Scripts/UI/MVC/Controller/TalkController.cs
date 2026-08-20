using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TalkController : MonoBehaviour,IPointerClickHandler
{
    public Text DialogText;
    public Text NameText;
    public int index = 0;
    bool Finsh;
    bool QuickRead;
    private void Awake()
    {

    }
    private void OnEnable()
    {
        InitTalk();
        TalkManager.Instance.talkController = this;
        Finsh = false;
        QuickRead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ControlTalk()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if(Finsh && !QuickRead)
            {
                Talk();
            }
            else if (!Finsh)
            {
                QuickRead = !QuickRead;
            }
        }
    }

    public void Talk()
    {
        index++;
        if (index < TalkManager.Instance.DialogLines.Count)
        {
            CheckName();
            //DialogText.text = TalkManager.Instance.DialogLines[index];
            if (TalkManager.Instance.DialogLines[index].StartsWith("o-"))
            {
                DialogText.text = "";
            }
            else
            {
                StartCoroutine(ReadTalk());
            }
        }
        else
        {
            WindowManager.Instance.CloseWindow(WindowType.TalkWindow);
            if (TalkManager.Instance.Talker)
            {
                var quest = TalkManager.Instance.Talker.GetComponent<Questable>();
                var questTarget = TalkManager.Instance.Talker.GetComponent<QuestTarget>();
                if (quest)
                {
                    quest.DelegateQuest();
                }
                if (questTarget && questTarget.QuestType == QuestType.Talk)
                {
                    questTarget.isTalked = true;
                    questTarget.QuestCompelete();
                }
            }
        }
    }

    public void InitTalk()
    {
        string str = "此处没人";
        if (!GameManager.instance.Player.GetComponent<PlayerMovement>().haveNPC && TalkManager.Instance.DialogLines.Count == 0)
        {
            TalkManager.Instance.DialogLines.Add(str);
        }
        index = TalkManager.Instance.Index;
        CheckName();
        //DialogText.text = TalkManager.Instance.DialogLines[index];
        StartCoroutine(ReadTalk());
    }

    public void CheckName()
    {
        if (TalkManager.Instance.DialogLines[index].StartsWith("n-"))
        {
            NameText.text = TalkManager.Instance.DialogLines[index].Replace("n-", "");
            index++;
            CheckName();
        }
        else if(TalkManager.Instance.DialogLines[index].StartsWith("o-"))
        {
            string str = TalkManager.Instance.DialogLines[index].Substring(2);
            int temp = int.Parse(str);
            Debug.Log(str);
            TalkManager.Instance.Selects[temp].SetActive(true);
            /*GameObject obj = Resources.Load<GameObject>("UI/Select/" + str);
            Instantiate(obj).transform.SetParent(GameObject.Find("workStation").transform, false);
            obj.SetActive(true);
            obj.gameObject.AddComponent<GraphicRaycaster>();
            Canvas canvas = obj.GetComponent<Canvas>();
            if (!canvas)
            {
                obj.AddComponent<Canvas>();
            }
            canvas.overrideSorting = true;
            canvas.sortingOrder = WindowManager.Instance.windowsCount + 1;*/
        }
    }

    private void OnDestroy()
    {
        //TalkManager.Instance.DialogLines.Clear();
        TalkManager.Instance.talkController = null;
    }

    IEnumerator ReadTalk()
    {
        Finsh = false;
        DialogText.text = "";
        for (int i = 0; i < TalkManager.Instance.DialogLines[index].Length; i++)
        {
            if (QuickRead)
            {
                break;
            }
            DialogText.text += TalkManager.Instance.DialogLines[index][i];
            yield return new WaitForSeconds(TalkManager.Instance.TalkSpeed);
        }
        DialogText.text = TalkManager.Instance.DialogLines[index];
        QuickRead = false;
        Finsh = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ControlTalk();
    }
}

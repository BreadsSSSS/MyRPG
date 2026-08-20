using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasTool 
{
    public static Transform transform;
    public static Transform recyclePool;
    public static Transform workStation;
    public static Transform noticeStation;
    static bool isInit = false;
    public static void Init()
    {
        if (transform == null)
        {
            /*var obj = Resources.Load<GameObject>("UI/UIBase");
            transform = GameObject.Instantiate(obj).transform;*/
            transform = GameObject.Find("UIBase").transform;
        }
        if (recyclePool == null)
        {
            recyclePool = GameObject.Find("recyclePool").transform; //transform.Find("recyclePool");
        }
        if (workStation == null)
        {
            workStation = GameObject.Find("workStation").transform; //transform.Find("workStation");
        }
        if (noticeStation == null)
        {
            noticeStation = GameObject.Find("noticeStation").transform; //noticeStation.Find("noticeStation");
        }
    }
    public static void SetParent(Transform window, bool isOpen, bool isTipWindow = false)
    {
        if (isInit == false)
        {
            Init();
        }
        if (isOpen == true)
        {
            if (isTipWindow)
            {
                window.SetParent(noticeStation, false);
            }
            else
            {
                window.SetParent(workStation, false);
            }
        }
        else
        {
            window.SetParent(recyclePool, false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSelect : MonoBehaviour
{
    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenShop()
    {
        GameManager.instance.isShop = true;
        WindowManager.Instance.CloseWindow(WindowType.TalkWindow);
        WindowManager.Instance.OpenWindow(WindowType.ShopWindow);
        this.gameObject.SetActive(false);
    }

    public void CloseShop() 
    { 
        this.gameObject.SetActive(false);
        TalkManager.Instance.talkController.Talk();
    }
}

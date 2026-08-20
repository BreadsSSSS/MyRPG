using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseController : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load()
    {
        GameManager.instance.Run();
        WindowManager.Instance.CloseWindow(WindowType.LoseWindow);
        SaveManager.Instance.LoadFromJson();
    }

    public void Back()
    {
        GameManager.instance.Run();
        WindowManager.Instance.CloseWindow(WindowType.LoseWindow);
        GameManager.instance.Player.SetActive(false);
        MySceneManager.Instance.BackToMain();
    }
}

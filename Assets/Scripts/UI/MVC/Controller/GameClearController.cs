using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearController : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMain()
    {
        GameManager.instance.Run();
        WindowManager.Instance.CloseWindow(WindowType.GameClearWindow);
        GameManager.instance.Player.SetActive(false);
        MySceneManager.Instance.BackToMain();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{
    public Slider BGM;
    public Slider FX;

    public Button Save;
    public Button Load;
    public Button BackMain;
    void Start()
    {
        Save.onClick.AddListener(SaveClick);
        Load.onClick.AddListener(LoadClick);
        BackMain.onClick.AddListener(BackToMainClick);
    }

    private void LoadClick()
    {
        Debug.Log("Load");
        WindowManager.Instance.CloseWindow(WindowType.SettingWindow);
        SaveManager.Instance.LoadFromJson();
    }

    private void BackToMainClick()
    {
        Debug.Log("BackMain");
        WindowManager.Instance.CloseWindow(WindowType.SettingWindow);
        GameManager.instance.Player.SetActive(false);
        MySceneManager.Instance.BackToMain();
    }

    private void SaveClick()
    {
        Debug.Log("Save");
        SaveManager.Instance.SaveByJson();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BGMVolum()
    {
        GameManager.instance.cameraController.BGM.volume = BGM.value;
    }
    public void FXVolum()
    {
        GameManager.instance.cameraController.FX.volume = BGM.value;
    }
    public void CloseThis()
    {
        WindowManager.Instance.CloseWindow(WindowType.SettingWindow);
    }
}

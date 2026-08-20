using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class MySceneManager : SigonTon<MySceneManager>
{
    public SceneLoad Main;
    public SceneLoad FirstLoad;
    public SceneLoad CurrentScene;
    public bool isLoad;
    public Skill First;
    protected override void Awake()
    {
        base.Awake();
        
    }
    private void Start()
    {
        Init();
    }
    public void Init()
    {
        CurrentScene = FirstLoad;
        CurrentScene.Scene.LoadSceneAsync(LoadSceneMode.Additive);
        GameManager.instance.Player.transform.position = CurrentScene.pos;
        GameManager.instance.cameraController.SwitchPlay();
        GameManager.instance.Deep = CurrentScene.deep;
        GameManager.instance.SceneType = CurrentScene.type;
        if (!SkillManager.Instance.skills.Contains(First))
        {
            SkillManager.Instance.skills.Add(First);
        }
    }
    public void LoadScene(SceneLoad sceneLoad)
    {
        GameManager.instance.Player.transform.position = new Vector3(-99, -99, 0);
        isLoad = true;
        StartCoroutine(UnLoadThisScene(sceneLoad));
    }

    public void LoadGameDataScene(SceneLoad sceneLoad,Save save)
    {
        GameManager.instance.Player.transform.position = new Vector3(-99, -99, 0);
        isLoad = true;
        if (save.sceneLoad.Scene == CurrentScene.Scene)
        {
            save.ReturnValue();
            isLoad = false;
        }
        else
        {
            StartCoroutine(UnLoadThisScene(sceneLoad, save));
        }
        
    }

    public void BackToMain()
    {
        GameManager.instance.Player.SetActive(false);
        StartCoroutine(UnLoadThisScene(Main));
    }
    IEnumerator UnLoadThisScene(SceneLoad sceneLoad)
    {
        
        GameManager.instance.Fade(1);
        yield return null;
        CurrentScene.Scene?.UnLoadScene();
        StartCoroutine(AsyLoadScene(sceneLoad));
    }
    IEnumerator AsyLoadScene(SceneLoad sceneLoad)
    {
        yield return sceneLoad.Scene.LoadSceneAsync(LoadSceneMode.Additive,true);
        GameManager.instance.Player.transform.position = sceneLoad.pos;
        GameManager.instance.Deep = sceneLoad.deep;
        GameManager.instance.SceneType = sceneLoad.type;
        CurrentScene = sceneLoad;
        GameManager.instance.cameraController.SwitchPlay();
        yield return null;
        GameManager.instance.Fade(0);
        isLoad = false;
    }

    IEnumerator UnLoadThisScene(SceneLoad sceneLoad, Save save)
    {
        isLoad = true;
        GameManager.instance.Fade(1);
        yield return null;
        CurrentScene.Scene?.UnLoadScene();
        StartCoroutine(AsyLoadScene(sceneLoad, save));
    }
    IEnumerator AsyLoadScene(SceneLoad sceneLoad, Save save)
    {
        yield return sceneLoad.Scene.LoadSceneAsync(LoadSceneMode.Additive, true);
        GameManager.instance.Player.transform.position = sceneLoad.pos;
        GameManager.instance.Deep = sceneLoad.deep;
        GameManager.instance.SceneType = sceneLoad.type;
        CurrentScene = sceneLoad;
        GameManager.instance.cameraController.SwitchPlay();
        yield return null;
        save.ReturnValue();
        GameManager.instance.Fade(0);
        isLoad = false;
    }
}


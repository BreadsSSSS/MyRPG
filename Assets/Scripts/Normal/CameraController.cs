using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public float smoothSpeed;
    private Transform target;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public AudioMixer audioMixer;
    public AudioSource BGM;
    public AudioSource FX;
    
    public AudioClip Main;
    public AudioClip Battle;
    public AudioClip Town;
    public AudioClip Cave;
    public AudioClip Boss;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        SwitchPlay();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isBattle || GameManager.instance.SceneType == SceneType.Login)
        {
            return;
        }
        Follow();
    }

    public void InBattle()
    {
        this.GetComponent<Camera>().orthographicSize = 5;
        transform.position = new Vector3(transform.position.x - 4, transform.position.y + 1f,-10);
        BattlePlay();
    }

    public void BossBattle()
    {
        this.GetComponent<Camera>().orthographicSize = 5;
        transform.position = new Vector3(transform.position.x - 4, transform.position.y + 1f, -10);
        BossPlay();
    }

    public void QuitBattle()
    {
        this.GetComponent<Camera>().orthographicSize = 8;
        if(GameManager.instance.SceneType == SceneType.Town)
        {
            PlayTown();
        }
        else if(GameManager.instance.SceneType == SceneType.Login)
        {
            MainPlay();
        }
        else if(GameManager.instance.SceneType == SceneType.None)
        {
            CavePlay();
        }
    }

    public void LateFollow()
    {
        Vector3 pos = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, pos, smoothSpeed * Time.deltaTime);
    }

    public void Follow()
    {
        Vector3 pos = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = pos;
        if (GameManager.instance.SceneType != SceneType.Town)
        {
            return;
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,minX,maxX),
                                         Mathf.Clamp(transform.position.y,minY,maxY),
                                         transform.position.z); 
    }

    public void PlayTown()
    {
        BGM.clip = Town;
        BGM.Play();
    }

    public void BattlePlay()
    {
        BGM.clip = Battle;
        BGM.Play();
    }

    public void MainPlay()
    {
        BGM.clip = Main;
        BGM.Play();
    }

    public void CavePlay()
    {
        BGM.clip = Cave;
        BGM.Play();
    }

    public void BossPlay()
    {
        BGM.clip = Boss;
        BGM.Play();
    }
    public void SwitchPlay()
    {
        if (GameManager.instance.SceneType == SceneType.Town)
        {
            PlayTown();
        }
        else if (GameManager.instance.SceneType == SceneType.Login)
        {
            MainPlay();
        }
        else if (GameManager.instance.SceneType == SceneType.None)
        {
            CavePlay();
        }
    }
}

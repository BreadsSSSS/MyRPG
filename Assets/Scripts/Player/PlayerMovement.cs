using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;


public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    Rigidbody2D Rigidbody;
    BoxCollider2D BoxCollider;
    public float speed = 3;
    public float enemyEnter = 1;
    public bool haveNPC;
    float horizontal;
    float vertical;
    int PlayerStatus;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody2D>();
        BoxCollider = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(GameManager.instance.isBattle ||WindowManager.Instance.isMenu || MySceneManager.Instance.isLoad || GameManager.instance.SceneType == SceneType.Login)
        {
            Rigidbody.velocity = new Vector2(0, 0);
            return;
        }
        Movement();
    }


    private void Movement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector2 move = new Vector2(horizontal, vertical);
        Rigidbody.velocity = move * speed;  
        if (horizontal != 0 || vertical != 0)
        {
            animator.SetBool("LR",true);
            if(horizontal != 0)
            transform.localScale = new Vector3(-horizontal, 1, 1);
        }
        else
        {
            animator.SetBool("LR", false);
        }
        if((horizontal!=0 ||vertical !=0) && GameManager.instance.SceneType!= SceneType.Town)
        {
            int tmp = UnityEngine.Random.Range(0, 200);
            if (tmp <= enemyEnter)
            {
                GameManager.instance.EnterBattle();
            }
        }
        
    }

    private void MouseMove()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector2 pos = ray.GetPoint(10);
        if(Input.GetMouseButtonDown(0)) 
        { 
            Rigidbody.velocity = pos * speed;
            Debug.Log(pos.x + "" + pos.y);
        }
        
    }

    public void InBattle()
    {
        Rigidbody.velocity = new Vector2(0,0);
        PlayerStatus = 1;
        animator.SetLayerWeight(0, 0);
        animator.SetLayerWeight(1, 1);
        animator.SetInteger("Status", PlayerStatus);
        BoxCollider.enabled = false;
        transform.localScale = new Vector3(1, 1, 1);
        transform.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
    }

    public void QuitBattle()
    {
        PlayerStatus = 0;
        animator.SetLayerWeight(1, 0);
        animator.SetLayerWeight(0, 1);
        animator.SetInteger("Status", PlayerStatus);
        BoxCollider.enabled = true;
        transform.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "NPC")
        {
            haveNPC = true;
            TalkManager.Instance.DialogLines.Clear();
            TalkManager.Instance.Talker = collision.gameObject;
            if (!collision.GetComponent<TalkAble>().isNew)
            {
                collision.gameObject.GetComponent<Questable>()?.CheckQuest();
            }
            if (TalkManager.Instance.DialogLines.Count < collision.gameObject.GetComponent<TalkAble>().Talks.Count)
            {
                foreach(var data in collision.gameObject.GetComponent<TalkAble>().Talks)
                {
                    TalkManager.Instance.DialogLines.Add(data);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        haveNPC = false;
        TalkManager.Instance.Talker = null;
        TalkManager.Instance.DialogLines.Clear();
    }

    
}


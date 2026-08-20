using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float Speed = 5f;
    public Transform[] wayPoints;
    public int index;
    public bool isStay;
    public bool havePeople;
    NPCBaseStates currentStates;
    NPCBaseStates chaseStates;
    NPCBaseStates stayStates;
    private void Awake()
    {
        chaseStates = new NPCChaseStates();
        stayStates = new NPCStayStates();
    }
    void Start()
    {
        transform.DetachChildren();
    }

    private void OnEnable()
    {
        if(isStay)
        {
            currentStates = stayStates;
        }
        else
        {
            currentStates = chaseStates;
        }
        currentStates.OnEnter(this);
    }
    // Update is called once per frame
    void Update()
    {
        currentStates.LogicUpDate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            havePeople = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            havePeople = false;
    }

    public void NewStates(NPCStates states)
    {
        var newState = states switch
        {
            NPCStates.chase => chaseStates,
            NPCStates.stay => stayStates,
            _ => null
        };
        currentStates.onExit();
        currentStates = newState;
        currentStates.OnEnter(this);
    }
}

public enum NPCStates
{
    chase,
    stay,
}

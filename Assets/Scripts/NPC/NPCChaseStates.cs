using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCChaseStates : NPCBaseStates
{
    public override void LogicUpDate()
    {
        CurrentNpc.transform.position = Vector2.MoveTowards(
            CurrentNpc.transform.position,
            CurrentNpc.wayPoints[CurrentNpc.index].position,
            CurrentNpc.Speed * Time.deltaTime);
        if (Vector2.Distance(CurrentNpc.transform.position, CurrentNpc.wayPoints[CurrentNpc.index].position) <= 0.1f)
        {
            CurrentNpc.index++;
            if (CurrentNpc.index > CurrentNpc.wayPoints.Length - 1)
            {
                CurrentNpc.index = 0;
            }
        }
        if (CurrentNpc.havePeople)
        {
            CurrentNpc.NewStates(NPCStates.stay);
        }
    }

    public override void OnEnter(NPC Npc)
    {
        CurrentNpc = Npc;
        if(CurrentNpc.isStay)
        {
            CurrentNpc.NewStates(NPCStates.stay);
        }
    }

    public override void onExit()
    {
        
    }

    public override void PhysicsUpdate()
    {
        
    }
}

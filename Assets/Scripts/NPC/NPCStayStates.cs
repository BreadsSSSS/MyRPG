using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStayStates : NPCBaseStates
{
    public override void LogicUpDate()
    {
        if (!CurrentNpc.havePeople && !CurrentNpc.isStay)
        {
            CurrentNpc.NewStates(NPCStates.chase);
        }
    }

    public override void OnEnter(NPC Npc)
    {
        CurrentNpc = Npc;
    }

    public override void onExit()
    {
        
    }

    public override void PhysicsUpdate()
    {
        
    }
}

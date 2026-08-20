using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPCBaseStates 
{
    protected NPC CurrentNpc;
    public abstract void OnEnter(NPC Npc);
    public abstract void LogicUpDate();
    public abstract void PhysicsUpdate();
    public abstract void onExit();
}

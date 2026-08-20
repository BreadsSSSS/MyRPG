using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MagicWater", menuName = "So/MagicWater")]
public class MagicWater : ItemSo
{
    public override void Use()
    {
        base.Use();
        GameManager.instance.Player.GetComponent<PlayerStatus>().ADDHelath(20);
        GameManager.instance.Player.GetComponent<PlayerStatus>().ADDMp(20);
    }
}

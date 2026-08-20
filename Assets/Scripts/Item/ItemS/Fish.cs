using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fish", menuName = "So/Fish")]
public class Fish : ItemSo
{
    public override void Use()
    {
        base.Use();
        GameManager.instance.Player.GetComponent<PlayerStatus>().ADDHelath(10);
    }
}

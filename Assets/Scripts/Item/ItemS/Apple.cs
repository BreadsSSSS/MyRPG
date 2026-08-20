using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Apple", menuName = "So/Apple")]
public class Apple : ItemSo
{
    public override void Use()
    {
        base.Use();
        GameManager.instance.Player.GetComponent<PlayerStatus>().ADDMp(10);
    }
}

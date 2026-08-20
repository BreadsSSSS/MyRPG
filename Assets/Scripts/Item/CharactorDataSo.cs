using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharactorDataSo", menuName = "So/CharactorDataSo")]
public class CharactorDataSo : ScriptableObject
{
    public string Name;
    public float HP;
    public float MP;
    public float Attack;
    public float MagicAttack;
    public float Defence;
    public float MagicDefence;
    public float Speed;
    public float Experience;
    public int Money;
}

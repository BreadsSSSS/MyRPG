using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSelect : MonoBehaviour
{
    RaycastHit2D raycast;
    void Start()
    {

    }

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        raycast = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity);
        if (raycast)
        {
            if (Input.GetMouseButtonDown(0) && raycast.collider.tag == "Enemey")
            {
                BattleManager.Instance.CurrentUnit.GetComponent<FighterAction>().SelectAction("Skill", raycast.collider.gameObject);
                GameManager.instance.ColseSkillTarget();
            }
        }
    }
}

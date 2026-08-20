using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MVCTest : MonoBehaviour
{
    RaycastHit2D raycast;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit = new RaycastHit();
        Physics.Raycast(ray, out raycastHit);*/

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        raycast = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity);
        if (raycast)
        {
            if (Input.GetMouseButtonDown(0)&& raycast.collider.tag == "Enemey")
            {
                BattleManager.Instance.CurrentUnit.GetComponent<FighterAction>().SelectAction("Attack" , raycast.collider.gameObject);
                GameManager.instance.CloseHit();
            }
        }
    }

}

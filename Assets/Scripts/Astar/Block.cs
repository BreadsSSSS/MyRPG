using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int RowIndex;//行
    public int ColIndex;//列
    public Can_Walk Type;
    public SpriteRenderer selectSP;//选中的格子
    public SpriteRenderer gridSP;//网格图片
    public SpriteRenderer dirSP;//移动方向的图片
    // Start is called before the first frame update
    private void Awake()
    {
        selectSP = transform.Find("select").GetComponent<SpriteRenderer>();
        gridSP = transform.Find("gird").GetComponent<SpriteRenderer>();
        dirSP = transform.Find("dir").GetComponent <SpriteRenderer>();
    }
    private void OnMouseEnter()
    {
        selectSP.enabled = true;
    }

    private void OnMouseExit()
    {
        selectSP.enabled = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

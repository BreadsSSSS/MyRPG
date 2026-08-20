using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjPool : SigonTon<ObjPool>
{
    public ObjectPool<GameObject> objectPool;
    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyThis : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestrpyThis()
    {
        WindowManager.Instance.CloseWindow(WindowType.DamagePoint);
    }

    public void DesThisObj()
    {
        Destroy(this.gameObject);
    }
}

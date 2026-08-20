using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSelectController : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void CloseThis()
    {
        WindowManager.Instance.CloseWindow(WindowType.SkillSelectWindow);
    }
}

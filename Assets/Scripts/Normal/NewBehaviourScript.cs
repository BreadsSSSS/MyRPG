using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public List<CharactorDataSo> dataSos;
    void Awake()
    {
        var data = Resources.Load<CharactorDataSo>("SO/Bat");
        dataSos.Add(data);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        
    }
    void LateUpdate()
    {
        
    }
    void OnDisable()
    {
        
    }
    void OnDestroy()
    {
        
    }
}

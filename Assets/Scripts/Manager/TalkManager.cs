using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : SigonTon<TalkManager>
{
    public TalkController talkController;
    public int Index;
    [TextArea(1, 3)]
    public List<string> DialogLines;

    public float TalkSpeed = 0.05f;
    public GameObject Talker;
    public List<GameObject> Selects = new List<GameObject>();
    protected override void Awake()
    {
        base.Awake();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

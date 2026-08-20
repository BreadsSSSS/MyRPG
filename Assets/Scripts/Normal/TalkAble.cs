using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkAble : MonoBehaviour
{
    public TextAsset Textfile;
    public TextAsset newTalk;
    public List<string> Talks = new List<string>();
    public bool isNew;
    void Start()
    {
        GetTextInFile(Textfile);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetTextInFile(TextAsset file)
    {
        string[] lines = file.text.Split('\n');
        foreach (string line in lines)
        {
            Talks.Add(line);
        }
    }

    public void GetNewTextInFile()
    {
        Talks.Clear();
        if (newTalk)
        {
            string[] lines = newTalk.text.Split('\n');
            foreach (string line in lines)
            {
                Talks.Add(line);
            }
        }
    }
}

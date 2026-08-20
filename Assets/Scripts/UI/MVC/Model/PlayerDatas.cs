using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDatas : MonoBehaviour
{
    [SerializeField]private List<CharactorDataSo> charactorDatas = new List<CharactorDataSo>();
    public TextAsset charactorDataFile;
    private void Awake()
    {
        AddAllData();
    }

    public CharactorDataSo UpdatleStatus(int lv)
    {
        return charactorDatas[lv-1];
    }

    public void AddAllData()
    {
        if(charactorDataFile != null)
        {
            string[] Lines = charactorDataFile.text.Split('\n');
            for(int i = 1; i < Lines.Length; i++)
            {
                string[] datas = Lines[i].Split(",");

                CharactorDataSo charactorData = ScriptableObject.CreateInstance<CharactorDataSo>();
                charactorData.Name = i.ToString();
                charactorData.HP = int.Parse(datas[0]);
                charactorData.MP = int.Parse(datas[1]);
                charactorData.Attack = int.Parse(datas[2]);
                charactorData.MagicAttack = int.Parse(datas[3]);
                charactorData.Defence = int.Parse(datas[4]);
                charactorData.MagicDefence = int.Parse(datas[5]);
                charactorData.Experience = int.Parse(datas[6]);

                charactorDatas.Add(charactorData);
            }
        }

    }
}

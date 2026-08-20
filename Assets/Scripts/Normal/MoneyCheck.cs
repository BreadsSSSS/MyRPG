using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCheck : MonoBehaviour
{
    public Text Num;
    void Start()
    {
        Num = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Num.text = GameManager.instance.Money.ToString();
    }
}

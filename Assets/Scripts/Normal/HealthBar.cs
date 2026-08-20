using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image HP;
    public Image Effec;
    private PlayerStatus playerStatus;
    // Start is called before the first frame update
    void Start()
    {
        playerStatus = FindFirstObjectByType<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        HP.fillAmount = playerStatus.HP / playerStatus.MaxHP;
        if(Effec.fillAmount > HP.fillAmount)
        {
            Effec.fillAmount -= 0.001f;
        }
        else
        {
            Effec.fillAmount = HP.fillAmount;
        }
    }
}

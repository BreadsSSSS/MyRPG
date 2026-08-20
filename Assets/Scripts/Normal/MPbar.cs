using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MPbar : MonoBehaviour
{
    public Image MP;
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
        MP.fillAmount = playerStatus.MP / playerStatus.MaxMP;
        if (Effec.fillAmount > MP.fillAmount)
        {
            Effec.fillAmount -= 0.001f;
        }
        else
        {
            Effec.fillAmount = MP.fillAmount;
        }
    }
}

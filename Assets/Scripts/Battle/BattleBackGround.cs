using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleBackGround : MonoBehaviour
{
    public Sprite witch;
    Image image;
    public GameObject BattlePlayer;
    public Vector3 sad = new Vector3(4,4,0);
    // Start is called before the first frame update
    private void Awake()
    {
        //GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        //Vector2 born = camera.transform.position;
        //Instantiate(BattlePlayer, born, Quaternion.identity);
    }
    public void Start()
    {
       
        //Instantiate(BattlePlayer);
        image = GetComponent<Image>();
        image.sprite = witch;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

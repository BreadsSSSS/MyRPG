using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class TelePoint : MonoBehaviour
{
    public SceneLoad sceneLoad;
    private void Awake()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.tag == "Player")
        {
            MySceneManager.Instance.LoadScene(sceneLoad);
        }
        else
        {
            Debug.Log(" !");
        }
    }
}

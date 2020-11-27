using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoSingleton<PlayerScript>
{
   

    public string name;


    public override void Init()
    {
        base.Init();

        Debug.Log("Player Initialized");
    }


    //void Start()
    //{


    //    GameManager.Instance.DisplayName();
    //    UIManager.Instance.UpdateScore(40);
    //    SpawnManager.Instance.StartSpawning();

    //}


    //void Update()
    //{

    //}
}

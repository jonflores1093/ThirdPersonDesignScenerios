using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private static SpawnManager _instance;
    public static SpawnManager Instance
    {

        get
        {

            if (_instance == null)
                Debug.LogError("Spawn Manager is NULL");
            return _instance;
        }

    }


    private void Awake()
    {
        _instance = this;
    }

    public void StartSpawning()
    {

        Debug.Log("Spawn Started");


    }

    private void Start()
    {

        Debug.Log(PlayerScript.Instance.name);

    }

}

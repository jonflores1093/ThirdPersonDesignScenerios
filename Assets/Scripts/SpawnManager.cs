using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoSingleton<SpawnManager>
{
    private float repeatRate = 1.0f;
    Vector3 spawner = GameObject.FindGameObjectWithTag("Spawn").transform.position;

    [SerializeField]
    private GameObject _sphere;

    



    public void Spawn()
    {

        Instantiate(_sphere, new Vector3(spawner.x,spawner.y, spawner.z), Quaternion.identity);


    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Spawn();


        }
        

    }

  

}

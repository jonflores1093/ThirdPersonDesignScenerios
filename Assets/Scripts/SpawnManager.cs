using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoSingleton<SpawnManager>
{
    private float repeatRate = 1.0f;
    

    [SerializeField]
    private GameObject _sphere;

    [SerializeField]
     


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InvokeRepeating("RandObj", 0.5f, repeatRate);
            Destroy(gameObject, 11);
            gameObject.GetComponent<BoxCollider>().enabled = false;


        }
        

    }

    void RandObj()
    {

        Instantiate(_sphere);

    }

}

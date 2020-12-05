using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawn : MonoBehaviour
{
    

    [SerializeField]
    private GameObject sphere;

    [SerializeField]
    private GameObject location;


    private void Spawner()
    {

        Vector3 newPos = new Vector3(location.transform.position.x, location.transform.position.y, location.transform.position.z);
        GameObject obj = Instantiate(sphere, newPos, Quaternion.identity) as GameObject;



    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Spawner();


        }



    }



}

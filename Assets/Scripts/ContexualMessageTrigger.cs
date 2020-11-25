using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContexualMessageTrigger : MonoBehaviour
{
    public delegate void ContexualMessageTriggeredAction();

    public static event ContexualMessageTriggeredAction ContexualMessageTriggered;


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (ContexualMessageTriggered != null)
            {

                ContexualMessageTriggered.Invoke();

            }

        }

    }


}

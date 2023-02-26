using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushPanel : MonoBehaviour
{

    public UnityEvent OnTriggerEnter;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            OnTriggerEnter?.Invoke();

        }

    }

}

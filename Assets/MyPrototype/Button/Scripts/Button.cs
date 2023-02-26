using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{

    UnityEngine.UI.Button myButton;
    bool isEnabled = false;

    private void Start()
    {
        myButton = GetComponent<UnityEngine.UI.Button>();

    }

    private void Update()
    {
        if (isEnabled == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && myButton.interactable==true)
            {
                myButton.onClick.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag=="Player")
        {
            isEnabled = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            isEnabled = false;
        }

    }

}

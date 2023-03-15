using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{

    public void Click()
    {

        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.GetComponent<FirstPersonMovement>().enabled=true;

            player.GetComponentInChildren<FirstPersonLook>().enabled = true;

        }
        else
        {
            Debug.LogError("Player not found;");
        }

        gameObject.SetActive(false);

    }

}

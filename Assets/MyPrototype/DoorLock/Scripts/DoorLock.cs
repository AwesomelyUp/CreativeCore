using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    [SerializeField]
    [ColorUsageAttribute(false, true)]
    private Color disabledColor;

    [SerializeField]
    [ColorUsageAttribute(false, true)]
    private Color enabledColor;

    public GameObject door;

    private PlayerControl playerControl;

    private bool isNear = false;

    private void Start()
    {
        var player = GameObject.FindWithTag("Player");
        playerControl = player.GetComponent<PlayerControl>();
        playerControl.EPlayerInteract += OpenDoor;
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {
            if (playerControl.IsAxeColected)
            {
                GetComponent<HightLight>()?.ChangeColor(enabledColor);
            }
            else
            {
                GetComponent<HightLight>()?.ChangeColor(disabledColor);
            }

            isNear = true;
            GetComponent<HightLight>()?.ToggleHighlight(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        isNear = false;
        GetComponent<HightLight>()?.ToggleHighlight(false);
    }


    private void OpenDoor()
    {
        if (isNear == true && playerControl.IsAxeColected==true)
        {
            playerControl.EPlayerInteract -= OpenDoor;
            Destroy(gameObject);
            door.GetComponent<Rigidbody>().isKinematic = false;
        }
        
    }

}

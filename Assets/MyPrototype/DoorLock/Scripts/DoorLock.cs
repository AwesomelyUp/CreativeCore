using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    [SerializeField]
    [ColorUsageAttribute(false, true)]
    private Color disabledColor;

    public GameObject door;

    private PlayerControl playerControl;
    private HighlightManager highlightManager;

    private bool isActive = false;

    private void Start()
    {
        var player = GameObject.FindWithTag("Player");
        playerControl = player.GetComponent<PlayerControl>();
        playerControl.EPlayerInteract += OpenDoor;

        var highlighter = GameObject.Find("HighlightManager");
        if (highlighter == null)
        {
            Debug.Log("Warning: Unable to find Highlight Manager");
        }
        else
        {
            highlightManager = highlighter.GetComponent<HighlightManager>();
            highlightManager.OnHighlightObject += OnHighlight;
        }
    }

    private void OnHighlight(string objectName, bool isHighlighted)
    {
        if (objectName == gameObject.name)
        {
            isActive = isHighlighted;
        }
    }

    private void OpenDoor()
    {
        if (isActive == true && playerControl.IsAxeColected==true)
        {
            highlightManager.OnHighlightObject -= OnHighlight;
            playerControl.EPlayerInteract -= OpenDoor;
            Destroy(gameObject);
            door.GetComponent<Rigidbody>().isKinematic = false;
        }
        
    }

}

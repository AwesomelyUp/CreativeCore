using UnityEngine;

public class VikingAxeInteraction : MonoBehaviour
{

    private PlayerControl playerControl;

    private bool isNearAxe;

    private void Awake()
    {
        isNearAxe = false;
    }

    private void Start()
    {
        var player = GameObject.FindWithTag("Player");
        playerControl = player.GetComponent<PlayerControl>();
        playerControl.EPlayerInteract += TakeAxe;
    }

    private void OnTriggerEnter(Collider other)
    {
        isNearAxe = true;
        GetComponent<HightLight>()?.ToggleHighlight(true);
    }

    private void OnTriggerExit(Collider other)
    {
        isNearAxe = false;
        GetComponent<HightLight>()?.ToggleHighlight(false);
    }


    private void TakeAxe()
    {
        if (isNearAxe == true)
        {
            playerControl.ColectAxe();
            playerControl.EPlayerInteract -= TakeAxe;
            Destroy(gameObject);
        }
        
    }

}

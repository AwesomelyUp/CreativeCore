using UnityEngine;

public class VikingAxeInteraction : MonoBehaviour
{

    private PlayerControl playerControl;
    private HighlightManager highlightManager;

    private bool isActive;

    private void Start()
    {
        var player = GameObject.FindWithTag("Player");
        playerControl = player.GetComponent<PlayerControl>();
        playerControl.EPlayerInteract += TakeAxe;

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

        if(objectName == gameObject.name)
        {
            isActive = isHighlighted;
        }
        
    }

    private void TakeAxe()
    {

        if (isActive == true)
        {
            playerControl.ColectAxe();
            playerControl.EPlayerInteract -= TakeAxe;
            highlightManager.OnHighlightObject -= OnHighlight;
            Destroy(gameObject);
        }
        
    }

}

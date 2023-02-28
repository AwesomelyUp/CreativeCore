using UnityEngine;

public class SelectObject : MonoBehaviour
{

    public LayerMask layerMask;
    public float getDistance;

    private HighlightObject higlightedObject;

    private void FixedUpdate()
    {

        if (higlightedObject != null)
        {
            higlightedObject.ToggleHighlight(false);
            higlightedObject = null;
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f,0));

        //Debug.DrawRay(ray.origin, ray.direction * getDistance, Color.green);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, getDistance, layerMask))
        {

            higlightedObject = hit.collider.gameObject.GetComponent<HighlightObject>();
            higlightedObject.ToggleHighlight(true);

        }

    }

}

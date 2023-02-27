using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{

    public LayerMask layerMask;
    public float getDistance;

    void Update()
    {

        

    }

    private void FixedUpdate()
    {

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f,0));

        Debug.DrawRay(ray.origin, ray.direction * getDistance, Color.green);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, getDistance, layerMask))
        {

            hit.collider.gameObject.GetComponent<HighlightObject>().ToggleHighlight(true);

        }

    }

}

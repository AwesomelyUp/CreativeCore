using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObjectDemo : MonoBehaviour
{
    
    void Update()
    {

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.gameObject.name);
        }

    }
}

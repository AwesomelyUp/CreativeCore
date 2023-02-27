using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObject : MonoBehaviour
{

    [SerializeField]
    private List<Renderer> renderers;

    [SerializeField]
    [ColorUsageAttribute(false, true)]
    private Color highlightColor;

    private List<Material> materials;

    private void Awake()
    {
        materials = new List<Material>();

        foreach (var render in renderers)
        {

            materials.AddRange(new List<Material>(render.materials));

        }
    }

    public void ToggleHighlight(bool value)
    {

        if (value == true)
        {

            foreach (var material in materials)
            {
                material.EnableKeyword("_EMISSION");

                material.SetColor("_EmissionColor", highlightColor);
            }

        }
        else
        {

            foreach (var material in materials)
            {
                material.DisableKeyword("_EMISSION");
            }

        }

    }

    public void ChangeColor(Color color)
    {
        highlightColor = color;
    }

}

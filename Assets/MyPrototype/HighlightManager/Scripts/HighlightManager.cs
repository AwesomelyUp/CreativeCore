using UnityEngine;

public class HighlightManager : MonoBehaviour
{

    public HighlightManager Instance;

    [SerializeField]
    private float MaxDistance;
    [SerializeField]
    private LayerMask LayerMask;

    [SerializeField]
    [ColorUsageAttribute(false,true)]
    private Color Color;

    public delegate void HighlightObject(string objectName, bool isHighLighted);
    public event HighlightObject OnHighlightObject;


    private GameObject selected;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void FixedUpdate()
    {

        if (selected != null)
        {
            Highlight(false, selected);
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f));

        Debug.DrawRay(ray.origin, ray.direction * MaxDistance, Color.red);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, MaxDistance, LayerMask))
        {
            selected = hit.transform.gameObject;
            Highlight(true, hit.transform.gameObject);
        }

    }

    private void Highlight(bool setHighlight, GameObject highlightGameObject)
    {

        MeshRenderer meshRenderer = highlightGameObject.GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            Debug.Log("Warning: trying to highlight object without Mesh Renderer");
            return;
        }

        if (setHighlight)
        {

            foreach(var material in meshRenderer.materials)
            {
                material.SetColor("_EmissionColor", Color);
                material.EnableKeyword("_EMISSION");
            }

        }
        else
        {
            foreach(var material in meshRenderer.materials)
            {
                material.DisableKeyword("_EMISSION");
            }
        }

        OnHighlightObject?.Invoke(highlightGameObject.name, setHighlight);

    }


}

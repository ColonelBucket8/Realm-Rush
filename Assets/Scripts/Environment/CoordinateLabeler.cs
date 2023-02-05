using TMPro;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color blockedColor = Color.gray;

    private Vector2Int coordinates;
    private TextMeshPro label;
    private Waypoint waypoint;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
    }

    private void Update()
    {
        if (!Application.isPlaying)
        {
            // do something in edit mode only
            DisplayCoordinates();
            UpdateObjectName();
        }

        ToggleLabels();
        SetLabelColor();
    }

    private void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    private void SetLabelColor()
    {
        label.color = waypoint.IsPlaceable ? defaultColor : blockedColor;
    }

    private void DisplayCoordinates()
    {
        Vector3 parentPosition = transform.parent.position;
        Vector3 editorSnapSettingsMove = EditorSnapSettings.move;
        coordinates.x = Mathf.RoundToInt(parentPosition.x / editorSnapSettingsMove.x);
        coordinates.y = Mathf.RoundToInt(parentPosition.z / editorSnapSettingsMove.z);

        label.text = coordinates.x + "," + coordinates.y;
    }

    private void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
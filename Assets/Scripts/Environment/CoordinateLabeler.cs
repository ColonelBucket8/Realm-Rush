using TMPro;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color blockedColor = Color.gray;
    [SerializeField] private Color exploredColor = Color.yellow;
    [SerializeField] private Color pathColor = new Color(1f, 0.5f, 0);

    private Vector2Int coordinates;
    private TextMeshPro label;
    private GridManager gridManager;

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
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
        if (gridManager == null) return;

        Node node = gridManager.GetNode(coordinates);

        if (node == null) return;

        if (!node.isWalkable)
        {
            label.color = blockedColor;
        }
        else if (node.isPath)
        {
            label.color = pathColor;
        }
        else if (node.isExplore)
        {
            label.color = exploredColor;
        }
        else
        {
            label.color = defaultColor;
        }
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
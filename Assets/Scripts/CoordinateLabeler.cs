using TMPro;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    private Vector2Int coordinates;
    private TextMeshPro label;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
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
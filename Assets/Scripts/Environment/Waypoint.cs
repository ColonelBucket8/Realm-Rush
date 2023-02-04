using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private bool isPlaceable;

    public bool IsPlaceable => isPlaceable;

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            Instantiate(towerPrefab,
                transform.position,
                Quaternion.identity);
            isPlaceable = false;
        }
    }
}
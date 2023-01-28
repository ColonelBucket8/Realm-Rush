using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path = new();

    private void Start()
    {
    }

    private void PrintWaypointName()
    {
        foreach (Waypoint waypoint in path) Debug.Log(waypoint.name);
    }
}
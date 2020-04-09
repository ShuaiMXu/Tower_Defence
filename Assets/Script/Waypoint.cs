using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;

    [SerializeField] Tower towerPrefab;

    Vector2Int gridPos;

    const int gridSize = 10;

    private void Start()
    {
        Physics.queriesHitTriggers = true;
    }
    public int GetGridSize()
    {
        return gridSize;
    }
    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize));
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) // left click
        {
            if (isPlaceable)
            {
                Vector3 newPos = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
                Instantiate(towerPrefab, newPos, Quaternion.identity);
                isPlaceable = false;
            }
            else
            {
                print("Can't place here");
            }
        }
    }
}


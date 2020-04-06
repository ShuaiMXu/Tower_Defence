﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;

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
        // detect moucse click
        if (Input.GetMouseButtonDown(0)) {
            print(gameObject.name + "clicked");
        }
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PathFinding pathFinding = FindObjectOfType<PathFinding>();
        var path = pathFinding.GetPathFinding();
        StartCoroutine(FollowPath(path));

    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach(Waypoint waypoint in path)
        {
            transform.position = new Vector3(waypoint.transform.position.x, waypoint.transform.position.y + 2f , waypoint.transform.position.z);
            yield return new WaitForSeconds(1f);
        }
    }
}

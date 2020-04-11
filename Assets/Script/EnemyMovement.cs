using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float enemyMovement = .5f;
    [SerializeField] ParticleSystem goalParticle;

    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetObject;
    // Start is called before the first frame update
    void Start()
    {
        PathFinding pathFinding = FindObjectOfType<PathFinding>();
        var path = pathFinding.GetPathFinding();
        StartCoroutine(FollowPath(path));

    }

    void Update()
    {
        if (targetObject)
        {
            objectToPan.LookAt(targetObject);
        }
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach(Waypoint waypoint in path)
        {
            transform.position = new Vector3(waypoint.transform.position.x, waypoint.transform.position.y + 2f , waypoint.transform.position.z);
            yield return new WaitForSeconds(enemyMovement);
        }
        SelfDestruct();
    }

    private void SelfDestruct()
    {
        var vfx = Instantiate(goalParticle, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }
}

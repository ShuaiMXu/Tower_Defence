using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParentTransform;

    Queue<Tower> towerQueue = new Queue<Tower>();
    public void AddTower(Waypoint baseWayPoint)
    {
        //var towers = FindObjectsOfType<Tower>();
        //print(towerQueue.Count);
        int numOfTowers = towerQueue.Count;

        if(numOfTowers < towerLimit)
        {
            InstantiateNewTower(baseWayPoint);
        }
        else
        {
            MoveExistingTower(baseWayPoint);
        }

    }

    private void MoveExistingTower(Waypoint newBaseWayPoint)
    {
        // take bottom tower off queue
        var oldTower = towerQueue.Dequeue();
        // set the placeble tower
        oldTower.basewWaypoint.isPlaceable = true; // free-up the block
        newBaseWayPoint.isPlaceable = false;

        //set the waypoints
        oldTower.basewWaypoint = newBaseWayPoint;

        oldTower.transform.position =  new Vector3 (newBaseWayPoint.transform.position.x, 
                                                    newBaseWayPoint.transform.position.y + 2f, 
                                                    newBaseWayPoint.transform.position.z);

        //put the old tower on top od the queue
        towerQueue.Enqueue(oldTower);
    }

    private void InstantiateNewTower(Waypoint baseWayPoint)
    {
        Vector3 newPos = new Vector3(baseWayPoint.transform.position.x, baseWayPoint.transform.position.y + 2f, baseWayPoint.transform.position.z);
        
        var newTower = Instantiate(towerPrefab, newPos, Quaternion.identity);
        newTower.transform.parent = towerParentTransform.transform;

        baseWayPoint.isPlaceable = false;
        newTower.basewWaypoint = baseWayPoint;

        baseWayPoint.isPlaceable = false;
        towerQueue.Enqueue(newTower);
    }
}

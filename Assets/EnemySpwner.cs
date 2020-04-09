using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] EnemyMovement enemeyPrefab;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        while (true) // forever
        {
            Vector3 EnemyPos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            Instantiate(enemeyPrefab, EnemyPos, Quaternion.identity);

            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}

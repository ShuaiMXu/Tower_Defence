using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] EnemyMovement enemeyPrefab;
    [SerializeField] Transform EnemyParentTransform;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        while (true) // forever
        {
            Vector3 EnemyPos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            var newEnemy = Instantiate(enemeyPrefab, EnemyPos, Quaternion.identity);

            newEnemy.transform.parent = EnemyParentTransform.transform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}

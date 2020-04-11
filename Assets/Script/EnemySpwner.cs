using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpwner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] EnemyMovement enemeyPrefab;
    [SerializeField] Transform EnemyParentTransform;
    [SerializeField] Text Enemyscore;
    [SerializeField] AudioClip spawnedEnemySFX;
    int score;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
        Enemyscore.text = score.ToString();
    }
    IEnumerator SpawnEnemies()
    {
        while (true) // forever
        {
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            AddScore();
            Vector3 EnemyPos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            var newEnemy = Instantiate(enemeyPrefab, EnemyPos, Quaternion.identity);

            newEnemy.transform.parent = EnemyParentTransform.transform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void AddScore()
    {
        score++;
        Enemyscore.text = score.ToString();
    }
}

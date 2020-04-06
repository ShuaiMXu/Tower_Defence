using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Paramaters
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRang = 10f;
    [SerializeField] ParticleSystem projectileParticale;
    [SerializeField] ParticleSystem projectileParticale1;

    //State of each tower
    [SerializeField] Transform targetEnemy;


    // Update is called once per frame
    void Update()
    {
        setTargetEnemy();
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnmey();
        }
        else
        {
            Shoot(false);
        }
    }

    private void setTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if(sceneEnemies.Length == 0) { return; }
        Transform closetEnemy = sceneEnemies[0].transform;

        foreach(EnemyDamage testEnemy in sceneEnemies)
        {
            closetEnemy = GetClosest(closetEnemy, testEnemy.transform);
        }
        targetEnemy = closetEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var distToA = Vector3.Distance(transform.position, transformA.position);
        var distToB = Vector3.Distance(transform.position, transformB.position);
        if(distToA < distToB)
        {
            return transformA;
        }
        return transformB;
    }

    private void FireAtEnmey()
    {
        float distanceToEnnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if(distanceToEnnemy <= attackRang)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticale.emission;
        emissionModule.enabled = isActive;
    }
}

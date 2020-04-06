using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider collisonMesh;
    [SerializeField] int hitPoints = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoints <= 0)
        {
            KillEnmey();
        }
    }

    private void KillEnmey()
    {
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        hitPoints = hitPoints -  1;
        print("Current HitPoints" + hitPoints);
    }
}

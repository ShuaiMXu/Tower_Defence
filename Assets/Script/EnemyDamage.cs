using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider collisonMesh;
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem HitParticleSystem;
    [SerializeField] ParticleSystem DeathParticleSystem;
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
        var vfx=Instantiate(DeathParticleSystem, transform.position, Quaternion.identity);
        vfx.Play();
        float destoryDelay = vfx.main.duration;
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        hitPoints = hitPoints -  1;
        HitParticleSystem.Play();
        //print("Current HitPoints" + hitPoints);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFire : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] GameObject gun;
    float shotCounter;
    public GameObject target;
    public float speed = 100;
    private float distanceToTarget;
    private bool move = true;
    [SerializeField] GameObject projectile;
    [SerializeField] float PerShot = 5f;
    [SerializeField] float projectorFiringPeriod = 5f;
    [SerializeField] float TimeBetweenShots = 5f;

void Start()
    {
        shotCounter = TimeBetweenShots;
    }
    void Update()
    {
        CountDownAndShoot();
    }

    // Update is called once per frame
    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            FireShoot();
            shotCounter = TimeBetweenShots;
        }

    }
    private void FireShoot()
    {
            GameObject fire = Instantiate(projectile, gun.transform.position, gun.transform.rotation) as GameObject;
            fire.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * speed);
        }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //parameters
    [SerializeField] Transform objectToPan;
    [SerializeField] ParticleSystem bulletEmission;
    [SerializeField] float attackRange = 50f;

    //state of tower
    Transform targetEnemy;

    // Update is called once per frame
    void Update()
    {
        if (targetEnemy)
        {
            LookForEnemy();
        }
        else
        {
            ShootEnemy(false);
        }

    }

    private void LookForEnemy()
    {
        float enemyDistance = Vector3.Distance(targetEnemy.transform.position, transform.position);

        if (enemyDistance <= attackRange)
        {
            SnipeEnemy();
            ShootEnemy(true);
        }
        else
        {
            ShootEnemy(false);
        }
    }

    private void ShootEnemy(bool enabled)
    {
        var emmision = bulletEmission.emission;
        emmision.enabled = enabled;
    }

    private void SnipeEnemy()
    {
        objectToPan.LookAt(targetEnemy);
    }
}

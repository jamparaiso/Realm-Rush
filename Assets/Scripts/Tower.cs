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

    public WayPoint baseWaypoint;

    //state of tower
    Transform targetEnemy;

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();

        if (targetEnemy)
        {
            SnipeEnemy();
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }

    }

    private void SetTargetEnemy()
    {
        //finds all objects in the scene and put in on a list
        var sceneEnemies = FindObjectsOfType<EnemyCollisionHandler>();

        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform; //gets the first on the list

        foreach (EnemyCollisionHandler enemy in sceneEnemies)
        {
            targetEnemy = getClosest(closestEnemy, enemy.transform);
        }
    }

    private Transform getClosest(Transform enemyA, Transform enemyB)
    {
        var distA = Vector3.Distance(transform.position, enemyA.transform.position);

        var distB = Vector3.Distance(transform.position, enemyB.transform.position);

        if (distA < distB)
        {
            return enemyA;
        }
          return enemyB;

    }

    private void FireAtEnemy()
    {
        float enemyDistance = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);

        if (enemyDistance <= attackRange)
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
        var emmision = bulletEmission.emission;
        emmision.enabled = isActive;
    }

    private void SnipeEnemy()
    {
        objectToPan.LookAt(targetEnemy);
    }
}

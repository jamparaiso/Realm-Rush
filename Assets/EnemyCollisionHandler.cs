﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
public class EnemyCollisionHandler : MonoBehaviour
{

    [SerializeField] float enemyHp = 3f;
    float towerDmg = 1f;

    private void Start()
    {
    }
    private void OnParticleCollision(GameObject other)
    {
        EnemyHitHandler();
        if (enemyHp == 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }

    private void EnemyHitHandler()
    {
        enemyHp = enemyHp - towerDmg;
    }

}

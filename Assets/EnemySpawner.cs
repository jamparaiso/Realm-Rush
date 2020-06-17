using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f,120f)][SerializeField] float secondsBetweenSpawns = 5f;
    [SerializeField] MoveEnemy enemy; // only allows the same object to be attached in the editor
    bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (!gameOver)
        {
            Instantiate(enemy, transform.position, Quaternion.identity,transform);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

}

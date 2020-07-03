using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)] [SerializeField] float secondsBetweenSpawns = 5f;
    [SerializeField] MoveEnemy enemy; // only allows the same object to be attached in the editor
    [SerializeField] Transform enemyParent;
    bool gameOver = false;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (!gameOver)
        {
            Instantiate(enemy, transform.position, Quaternion.identity,enemyParent);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

}

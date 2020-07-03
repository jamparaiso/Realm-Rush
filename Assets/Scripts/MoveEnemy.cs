using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] ParticleSystem endDeathFx;
    float dwellTime = .50f;

    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));

    }

    IEnumerator FollowPath(List<WayPoint> path ) //move enemy using coroutines
    {
        foreach (WayPoint wayPoint in path)
        {
            transform.position = wayPoint.transform.position;
           yield return new WaitForSeconds(dwellTime);
        }

        SelfDestruct(); // enemy reach the end of the path
        Destroy(gameObject);
    }

    void SelfDestruct()
    {
        var deathFx = Instantiate(endDeathFx, transform.position, Quaternion.identity);
        deathFx.Play();
        Destroy(deathFx.gameObject, deathFx.main.duration);
    }

}

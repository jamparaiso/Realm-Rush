using UnityEngine;


[DisallowMultipleComponent]
public class EnemyCollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem hitFx;
    [SerializeField] ParticleSystem deathFx;
    [SerializeField] float enemyHp = 3f;
    float towerDmg = 1f;

    private void OnParticleCollision(GameObject other)
    {
        EnemyHitHandler();
        if (enemyHp == 0)
        {
            var vfx = Instantiate(deathFx, transform.position, Quaternion.identity);

            vfx.Play();
            DestroyVFx(vfx);
            KillEnemy();
        }
    }

    private static void DestroyVFx(ParticleSystem vfx)
    {
        //note destroying the particle system itself will not remove it on the heirarchy rather destroy it as gameObject
        Destroy(vfx.gameObject, vfx.main.duration);
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }

    private void EnemyHitHandler()
    {
        hitFx.Play();
        enemyHp = enemyHp - towerDmg;
    }

}

using UnityEngine;

[RequireComponent(typeof(TowerTargeting))]
public class TowerBehaviour : MonoBehaviour
{
    [Header("Tower Stats")]
    public float damage = 10f;
    public float attackRange = 10f;
    public float attackCooldown = 1.5f;

    [Header("Attack Type")]
    public AttackType attackType = AttackType.Normal;
    public float effectDuration = 2f;
    public float slowMultiplier = 0.5f;

    [Header("Attack Effect")]
    public GameObject shootEffect;
    public Transform effectSpawnPoint;

    private TowerTargeting targeting;
    private float attackTimer = 0f;

    void Start()
    {
        targeting = GetComponent<TowerTargeting>();
    }

    void Update()
    {
        Transform target = targeting.GetCurrentTarget();
        attackTimer -= Time.deltaTime;

        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);

            if (distance <= attackRange && attackTimer <= 0f)
            {
                Attack(target);
                attackTimer = attackCooldown;
            }
        }
    }

    private void Attack(Transform target)
    {
        EnemyStats enemy = target.GetComponent<EnemyStats>();
        if (enemy == null) return;

        PlayEffect();

        switch (attackType)
        {
            case AttackType.Normal:
                enemy.TakeDamage(damage);
                break;

            case AttackType.Slow:
                enemy.TakeDamage(damage);
                enemy.ApplySlow(slowMultiplier, effectDuration);
                break;
        }
    }

    private void PlayEffect()
    {
        if (shootEffect == null) return;

        Vector3 pos = effectSpawnPoint ? effectSpawnPoint.position : transform.position;
        Quaternion rot = effectSpawnPoint ? effectSpawnPoint.rotation : Quaternion.identity;

        GameObject fx = Instantiate(shootEffect, pos, rot);

        fx.transform.localScale = transform.lossyScale;

        Destroy(fx, 0.5f);
    }



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

public enum AttackType
{
    Normal,
    Slow
}

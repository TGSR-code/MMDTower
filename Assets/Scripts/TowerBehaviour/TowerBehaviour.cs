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
    public float effectDuration = 2f;  // Hoe lang slow/freeze duurt
    public float slowMultiplier = 0.5f; // Hoeveel langzamer bij slow (0.5 = helft snelheid)

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

        switch (attackType)
        {
            case AttackType.Normal:
                enemy.TakeDamage(damage);
                break;

            case AttackType.Slow:
                enemy.TakeDamage(damage);
                enemy.ApplySlow(slowMultiplier, effectDuration);
                break;

            case AttackType.Freeze:
                enemy.TakeDamage(damage);
                enemy.ApplyFreeze(effectDuration);
                break;
        }
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
    Slow,
    Freeze
}
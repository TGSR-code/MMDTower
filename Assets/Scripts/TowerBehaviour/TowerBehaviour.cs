using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TowerTargetting))]
public class TowerBehaviour : MonoBehaviour
{
    [Header("Tower Stats")]
    [SerializeField] public float damage = 10f;
    [SerializeField] public float attackRange = 10f;
    [SerializeField] public float attackCooldown = 1.5f;

    private TowerTargetting targetting;
    private bool canAttack = true;

    void Start()
    {
        targetting = GetComponent<TowerTargetting>();
    }

    void Update()
    {
        Transform currentTarget = targetting.GetCurrentTarget();

        if (currentTarget != null)
        {
            float distance = Vector3.Distance(transform.position, currentTarget.position);

            if (distance <= attackRange && canAttack)
            {
                StartCoroutine(Attack(currentTarget));
            }
        }
    }

    private IEnumerator Attack(Transform target)
    {
        canAttack = false;

        EnemyStats enemy = target.GetComponent<EnemyStats>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
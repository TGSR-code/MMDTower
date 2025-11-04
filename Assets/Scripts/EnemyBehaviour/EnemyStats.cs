using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float maxHealth = 50f;
    public float baseSpeed = 3f;

    private float currentHealth;
    private float currentSpeed;

    private bool isSlowed = false;
    private float slowTimer = 0f;
    private float slowMultiplier = 1f;

    void Start()
    {
        currentHealth = maxHealth;
        currentSpeed = baseSpeed;
    }

    void Update()
    {
        HandleSlowEffect();
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }

    private void HandleSlowEffect()
    {
        if (slowTimer > 0)
        {
            slowTimer -= Time.deltaTime;

            if (slowTimer <= 0)
            {
                isSlowed = false;
                slowMultiplier = 1f;
                currentSpeed = baseSpeed;
            }
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public void ApplySlow(float multiplier, float duration)
    {
        isSlowed = true;
        slowMultiplier = Mathf.Clamp(multiplier, 0.1f, 1f);
        slowTimer = duration;
        currentSpeed = baseSpeed * slowMultiplier;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}

using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float maxHealth = 50f;
    public float baseSpeed = 3f;

    private float currentHealth;
    private float currentSpeed;
    private bool isFrozen = false;
    private float effectTimer = 0f;

    void Start()
    {
        currentHealth = maxHealth;
        currentSpeed = baseSpeed;
    }

    void Update()
    {
        HandleEffects();

        // Beweging alleen als niet bevroren
        if (!isFrozen)
        {
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        }
    }

    private void HandleEffects()
    {
        if (effectTimer > 0)
        {
            effectTimer -= Time.deltaTime;

            if (effectTimer <= 0)
            {
                // effect is voorbij, reset
                isFrozen = false;
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

    public void ApplySlow(float slowMultiplier, float duration)
    {
        if (isFrozen) return; // niet tegelijk met freeze

        currentSpeed = baseSpeed * Mathf.Clamp(slowMultiplier, 0.1f, 1f);
        effectTimer = duration;
    }

    public void ApplyFreeze(float duration)
    {
        isFrozen = true;
        currentSpeed = 0f;
        effectTimer = duration;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
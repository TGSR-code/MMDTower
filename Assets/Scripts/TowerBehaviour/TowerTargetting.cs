using UnityEngine;

public class TowerTargeting : MonoBehaviour
{
    [SerializeField] private string enemyLayerName = "Enemy";
    [SerializeField] private float rotationSpeed = 5f;

    private Transform currentTarget;

    void Update()
    {
        if (currentTarget == null)
        {
            currentTarget = GetFirstEnemy();
        }

        if (currentTarget != null)
        {
            Vector3 direction = currentTarget.position - transform.position;
            direction.y = 0; // Alleen horizontaal draaien

            if (direction.sqrMagnitude > 0.01f)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
            }

            if (!currentTarget.gameObject.activeInHierarchy)
            {
                currentTarget = null;
            }
        }
    }

    private Transform GetFirstEnemy()
    {
        int enemyLayer = LayerMask.NameToLayer(enemyLayerName);

        // Nieuwe manier (Unity 2023+)
        GameObject[] allObjects = Object.FindObjectsByType<GameObject>(FindObjectsSortMode.None);

        foreach (GameObject obj in allObjects)
        {
            if (obj.layer == enemyLayer)
            {
                return obj.transform;
            }
        }

        return null;
    }

    public Transform GetCurrentTarget()
    {
        return currentTarget;
    }
}
using UnityEngine;
using System.Collections.Generic;

public class TowerTargetting : MonoBehaviour
{
    [SerializeField] private string enemyLayerName = "Enemy";
    [SerializeField] private float rotationSpeed = 5f;

    private Transform currentTarget;

    void Update()
    {
        if (currentTarget == null)
        {
            currentTarget = GetFirstEnemyInScene();
        }

        if (currentTarget != null)
        {
            Vector3 direction = (currentTarget.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

            if (!currentTarget.gameObject.activeInHierarchy)
            {
                currentTarget = null;
            }
        }
    }

    private Transform GetFirstEnemyInScene()
    {
        int enemyLayer = LayerMask.NameToLayer(enemyLayerName);
        GameObject[] allObjects = Object.FindObjectsByType<GameObject>(FindObjectsSortMode.None);

        List<GameObject> enemies = new List<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.layer == enemyLayer)
            {
                enemies.Add(obj);
            }
        }

        if (enemies.Count == 0)
            return null;

        return enemies[0].transform;
    }

    public Transform GetCurrentTarget()
    {
        return currentTarget;
    }
}

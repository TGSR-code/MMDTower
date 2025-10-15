using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class waveSystem : MonoBehaviour
{
    [SerializeField] private EnemyPathfinding EnemyPathfindingEnemy;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private TextMeshProUGUI waveCounterText;

    [SerializeField] private Transform Turn1;
    [SerializeField] private Transform Turn2;
    [SerializeField] private Transform Turn3;
    [SerializeField] private Transform Turn4;
    [SerializeField] private Transform Turn5;
    [SerializeField] private Transform Turn6;
    [SerializeField] private Transform Turn7;

    [SerializeField] private Button startButton;

    [Header("Money System")]
    [SerializeField] private MoneyHandler moneyHandler; 

    private int currentWave = 0;
    private int totalWaves = 15;
    private int aliveEnemies = 0;

    public void StartGame()
    {
       
        Destroy(startButton.gameObject);

        
        if (moneyHandler != null)
        {
            moneyHandler.GainMoney(500);
        }
        else
        {
            Debug.LogWarning("MoneyHandler??DASd/a");
        }

       
        StartWave();
    }

    void Update()
    {
        if (aliveEnemies <= 0 && currentWave > 0 && currentWave < totalWaves)
        {
            StartWave();
        }
    }

    private void StartWave()
    {
        currentWave++;
        waveCounterText.text = $"Wave: {currentWave}/{totalWaves}";

        if (currentWave == 1)
        {
            SpawnEnemies(EnemyPathfindingEnemy.EnemyPrefab, 3);
        }
        else if (currentWave == 2)
        {
            SpawnEnemies(EnemyPathfindingEnemy.EnemyPrefab, 3);
        }
        else if (currentWave == 3)
        {
            SpawnEnemies(EnemyPathfindingEnemy.EnemyPrefab, 3);
        }
        else if (currentWave == 4)
        {
            SpawnEnemies(EnemyPathfindingEnemy.EnemyPrefab, 3);
        }
        else if (currentWave == 5)
        {
            SpawnEnemies(EnemyPathfindingEnemy.EnemyPrefab, 3);
        }
        else if (currentWave == 6)
        {
            SpawnEnemies(EnemyPathfindingEnemy.EnemyPrefab, 3);
        }
        else if (currentWave == 7)
        {
            SpawnEnemies(EnemyPathfindingEnemy.EnemyPrefab, 3);
        }
        else if (currentWave == 8)
        {
            SpawnEnemies(EnemyPathfindingEnemy.EnemyPrefab, 3);
        }
        else if (currentWave == 9)
        {
            SpawnEnemies(EnemyPathfindingEnemy.EnemyPrefab, 3);
        }
        else if (currentWave == 10)
        {
            SpawnEnemies(EnemyPathfindingEnemy.EnemyPrefab, 3);
        }
        else if (currentWave == 11)
        {
            SpawnEnemies(EnemyPathfindingEnemy.EnemyPrefab, 3);
        }
        else if (currentWave == 12)
        {
            SpawnEnemies(EnemyPathfindingEnemy.EnemyPrefab, 3);
        }
        else if (currentWave == 13)
        {
            SpawnEnemies(EnemyPathfindingEnemy.EnemyPrefab, 3);
        }
        else if (currentWave == 14)
        {
            SpawnEnemies(EnemyPathfindingEnemy.EnemyPrefab, 3);
        }
        else if (currentWave == 15)
        {
            SpawnEnemies(EnemyPathfindingEnemy.EnemyPrefab, 3);
            Debug.Log("LastWave");
        }
    }

    private void SpawnEnemies(GameObject prefab, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject enemy = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
            aliveEnemies++;

            enemy.GetComponent<EnemyPathfinding>().SetTurns(Turn1, Turn2, Turn3, Turn4, Turn5, Turn6, Turn7);

            EnemyDeathHandler deathHandler = enemy.AddComponent<EnemyDeathHandler>();
            deathHandler.onDeath += () => aliveEnemies--;

            enemy.GetComponent<EnemyPathfinding>().EnemyPrefab = EnemyPathfindingEnemy.EnemyPrefab;
        }
    }
}

public class EnemyDeathHandler : MonoBehaviour
{
    public System.Action onDeath;

    private void OnDestroy()
    {
        if (onDeath != null) onDeath.Invoke();
    }
}

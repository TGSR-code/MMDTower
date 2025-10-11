using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class waveSystem : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private TextMeshProUGUI waveCounterText;
  
    [SerializeField] private Button startButton;


    private int currentWave = 0;
    private int totalWaves = 15;
    private int aliveEnemies = 0;
    


    public void StartGame()
    {
        Destroy(startButton.gameObject);
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
            SpawnEnemies(enemyPrefab, 3);
        }
        else if (currentWave == 2)
        {
            SpawnEnemies(enemyPrefab, 3);
        }
        else if (currentWave == 3)
        {
            SpawnEnemies(enemyPrefab, 3);
        }
        else if (currentWave == 4)
        {
            SpawnEnemies(enemyPrefab, 3);
        }
        else if (currentWave == 5)
        {
            SpawnEnemies(enemyPrefab, 3);
        }
        else if (currentWave == 6)
        {
            SpawnEnemies(enemyPrefab, 3);
        }
        else if (currentWave == 7)
        {
            SpawnEnemies(enemyPrefab, 3);
        }
        else if (currentWave == 8)
        {
            SpawnEnemies(enemyPrefab, 3);
        }
        else if (currentWave == 9)
        {
            SpawnEnemies(enemyPrefab, 3);
        }
        else if (currentWave == 10)
        {
            SpawnEnemies(enemyPrefab, 3);
        }
        else if (currentWave == 11)
        {
            SpawnEnemies(enemyPrefab, 3);
        }
        else if (currentWave == 12)
        {
            SpawnEnemies(enemyPrefab, 3);
        }
        else if (currentWave == 13)
        {
            SpawnEnemies(enemyPrefab, 3);
        }
        else if (currentWave == 14)
        {
            SpawnEnemies(enemyPrefab, 3);
        }
        else if (currentWave == 15)
        {
            SpawnEnemies(enemyPrefab, 3);
            Debug.Log("Laatste wave gestart!");
        }
    }

    private void SpawnEnemies(GameObject prefab, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject enemy = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
            aliveEnemies++;


            EnemyDeathHandler deathHandler = enemy.AddComponent<EnemyDeathHandler>();
            deathHandler.onDeath += () => aliveEnemies--;
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

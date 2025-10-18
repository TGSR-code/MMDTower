using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

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
    [SerializeField] private MoneyHandler moneyHandler;

    private int currentWave = 0;
    private int totalWaves = 15;
    private int aliveEnemies = 0;

    public void StartGame()
    {
        Destroy(startButton.gameObject);

        if (moneyHandler != null)
            moneyHandler.GainMoney(500);

        StartWave();
    }

    void Update()
    {
        if (aliveEnemies <= 0 && currentWave > 0 && currentWave < totalWaves)
            StartWave();
    }

    private void StartWave()
    {
        currentWave++;
        waveCounterText.text = $"Wave: {currentWave}/{totalWaves}";

        if (currentWave == 1)
        {
            StartCoroutine(Enmyspawndelay(EnemyPathfindingEnemy.EnemyPrefab, 3, 4f));
        }
        else if (currentWave == 2)
        {
            StartCoroutine(Enmyspawndelay(EnemyPathfindingEnemy.EnemyPrefab, 3, 4f));
            moneyHandler.GainMoney(100);
        }
        else if (currentWave == 3)
        {
            StartCoroutine(Enmyspawndelay(EnemyPathfindingEnemy.EnemyPrefab, 3, 4f));
            moneyHandler.GainMoney(125);
        }
        else if (currentWave == 4)
        {
            StartCoroutine(Enmyspawndelay(EnemyPathfindingEnemy.EnemyPrefab, 3, 4f));
            moneyHandler.GainMoney(150);
        }
        else if (currentWave == 5)
        {
            StartCoroutine(Enmyspawndelay(EnemyPathfindingEnemy.EnemyPrefab, 3, 4f));
            moneyHandler.GainMoney(175);
        }
        else if (currentWave == 6)
        {
            StartCoroutine(Enmyspawndelay(EnemyPathfindingEnemy.EnemyPrefab, 3, 4f));
            moneyHandler.GainMoney(200);
        }
        else if (currentWave == 7)
        {
            StartCoroutine(Enmyspawndelay(EnemyPathfindingEnemy.EnemyPrefab, 3, 4f));
            moneyHandler.GainMoney(225);
        }
        else if (currentWave == 8)
        {
            StartCoroutine(Enmyspawndelay(EnemyPathfindingEnemy.EnemyPrefab, 3, 4f));
            moneyHandler.GainMoney(250);
        }
        else if (currentWave == 9)
        {
            StartCoroutine(Enmyspawndelay(EnemyPathfindingEnemy.EnemyPrefab, 3, 4f));
            moneyHandler.GainMoney(275);
        }
        else if (currentWave == 10)
        {
            StartCoroutine(Enmyspawndelay(EnemyPathfindingEnemy.EnemyPrefab, 3, 4f));
            moneyHandler.GainMoney(500);
        }
        else if (currentWave == 11)
        {
            StartCoroutine(Enmyspawndelay(EnemyPathfindingEnemy.EnemyPrefab, 3, 4f));
            moneyHandler.GainMoney(325);
        }
        else if (currentWave == 12)
        {
            StartCoroutine(Enmyspawndelay(EnemyPathfindingEnemy.EnemyPrefab, 3, 4f));
            moneyHandler.GainMoney(350);
        }
        else if (currentWave == 13)
        {
            StartCoroutine(Enmyspawndelay(EnemyPathfindingEnemy.EnemyPrefab, 3, 4f));
            moneyHandler.GainMoney(375);
        }
        else if (currentWave == 14)
        {
            StartCoroutine(Enmyspawndelay(EnemyPathfindingEnemy.EnemyPrefab, 3, 4f));
            moneyHandler.GainMoney(400);
        }
        else if (currentWave == 15)
        {
            StartCoroutine(Enmyspawndelay(EnemyPathfindingEnemy.EnemyPrefab, 3, 4f));
            moneyHandler.GainMoney(1000);
            Debug.Log("LastWaveTest");
        }
    }

    private IEnumerator Enmyspawndelay(GameObject prefab, int amount, float delay)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject enemy = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
            aliveEnemies++;

            enemy.GetComponent<EnemyPathfinding>().SetTurns(Turn1, Turn2, Turn3, Turn4, Turn5, Turn6, Turn7);

            EnemyDeathHandler deathHandler = enemy.AddComponent<EnemyDeathHandler>();
            deathHandler.onDeath += () => aliveEnemies--;
            deathHandler.MoneyHandler = moneyHandler;


            enemy.GetComponent<EnemyPathfinding>().EnemyPrefab = EnemyPathfindingEnemy.EnemyPrefab;

            yield return new WaitForSeconds(delay);
        }
    }
}

public class EnemyDeathHandler : MonoBehaviour
{
    public System.Action onDeath;
    public MoneyHandler MoneyHandler;

    private void OnDestroy()
    {
        if (onDeath != null) onDeath.Invoke();
        if(MoneyHandler != null)
        {
            MoneyHandler.GainMoney(25);
            print("EnemyMoneyTest");
        }
    }
}

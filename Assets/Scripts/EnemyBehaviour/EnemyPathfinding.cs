using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPathfinding : waveSystem
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] public GameObject EnemyPrefab;
    [SerializeField] private Transform Turn1;
    [SerializeField] private Transform Turn2;
    [SerializeField] private Transform Turn3;
    [SerializeField] private Transform Turn4;
    [SerializeField] private Transform Turn5;
    [SerializeField] private Transform Turn6;
    [SerializeField] private Transform Turn7;

    private Transform[] waypoints;
    private int HuidigeWaypoint = 0;

    void Start()
    {
        waypoints = new Transform[]
        {
            Turn1, Turn2, Turn3, Turn4, Turn5, Turn6, Turn7
        };
    }

    public void SetTurns(Transform turn1, Transform turn2, Transform turn3, Transform turn4, Transform turn5, Transform turn6, Transform turn7)
    {
        Turn1 = turn1;
        Turn2 = turn2;
        Turn3 = turn3;
        Turn4 = turn4;
        Turn5 = turn5;
        Turn6 = turn6;
        Turn7 = turn7;
    }

    void Update()
    {
        if (waypoints == null || HuidigeWaypoint >= waypoints.Length) return;

        Transform target = waypoints[HuidigeWaypoint];
        Vector3 targetPos = new Vector3(target.position.x, transform.position.y, target.position.z);
        Vector3 dir = (targetPos - transform.position).normalized;

        transform.position += dir * moveSpeed * Time.deltaTime;

        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(dir);
        }

        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            HuidigeWaypoint++;
        }

        if (HuidigeWaypoint >= waypoints.Length)
        {
            BaseHealthBar baseHealth = FindAnyObjectByType<BaseHealthBar>();
            if (baseHealth != null)
            {
                baseHealth.TakeDMG(1f);
                
            }

            if (baseHealth != null && baseHealth.health <= 0f)
            {
                SceneManager.LoadScene("Gameplay");
            }

            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class EnemyUIRotation : MonoBehaviour
{
    [SerializeField] public Transform MainCamera;
    [SerializeField] public Transform TopViewCamera;
    [SerializeField] public Transform Enemylocation;
    void Start()
    {
        
    }

  
    void Update()
    {
        if (Enemylocation != null)
            transform.position = Enemylocation.position;

        if (MainCamera != null)
            transform.LookAt(MainCamera);


    }
}

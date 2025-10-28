using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField] private Camera PlayerCamera;

    private GameObject CurrentPlacingTower;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (CurrentPlacingTower != null)
        {
            Ray camray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(camray, out RaycastHit hitinfo, 100f))
            {
                CurrentPlacingTower.transform.position = hitinfo.point;
            }

            if (Input.GetMouseButtonDown(0))
            {
                CurrentPlacingTower = null;
            }
        }
    }

    public void SetTowerToPlace(GameObject tower)
    {
        CurrentPlacingTower = Instantiate(tower, Vector3.zero, Quaternion.identity);
    }
}

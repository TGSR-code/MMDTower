using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField] private LayerMask PlacementCheckMask;
    [SerializeField] private LayerMask PlacementCollideMask;
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
            RaycastHit hitinfo;

            if (Physics.Raycast(camray, out hitinfo, 100f, PlacementCollideMask))
            {
                CurrentPlacingTower.transform.position = hitinfo.point;
            }

            if (Input.GetMouseButtonDown(0) && hitinfo.collider.gameObject != null)
            {
                if(!hitinfo.collider.gameObject.CompareTag("cantPlace"))
                {
                    BoxCollider TowerCollider = CurrentPlacingTower.gameObject.GetComponent<BoxCollider>();
                    TowerCollider.isTrigger = true;

                    Vector3 BoxCenter = CurrentPlacingTower.gameObject.transform.position + TowerCollider.center;
                    Vector3 HalfExtens = TowerCollider.size / 2;
                    if (!Physics.CheckBox(BoxCenter, HalfExtens, Quaternion.identity, PlacementCheckMask, QueryTriggerInteraction.Ignore))
                    {
                        TowerCollider.isTrigger = false;
                        CurrentPlacingTower = null;
                    }
                }
            }
        }
    }

    public void SetTowerToPlace(GameObject tower)
    {
        CurrentPlacingTower = Instantiate(tower, Vector3.zero, Quaternion.identity);
    }
}

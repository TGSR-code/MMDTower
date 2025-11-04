using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    [SerializeField] GameObject SelectorObject;


    public void EnableSelector()
    {
        SelectorObject.gameObject.SetActive(true);

    }
}

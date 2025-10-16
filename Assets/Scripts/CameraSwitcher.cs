using UnityEngine;

public class CameraHandler : MonoBehaviour
{


    [Header("Camera")]
    [SerializeField] Camera MainCamera;
    [SerializeField] Camera TopViewCamera;

    [Header("Settings")]
    [SerializeField] KeyCode SwitchKey = KeyCode.Tab;
    [SerializeField] KeyCode ResetKey = KeyCode.R;
    [SerializeField] int TopViewSpeed = 8;
    [SerializeField] Transform ResetPoint;

    bool MainActive = true;

    void Start()
    {
        MainCamera.gameObject.SetActive(true);
        TopViewCamera.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(SwitchKey)) //true false switch
        {
            MainActive = !MainActive;
            MainCamera.gameObject.SetActive(MainActive);
            TopViewCamera.gameObject.SetActive(!MainActive);
            Debug.Log("CameraSwitch Pressed");
        }

        if (!MainActive) //top view camera movement
        {
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            TopViewCamera.transform.position += move * TopViewSpeed * Time.deltaTime;

            if (Input.GetKeyDown(ResetKey) && ResetPoint)
                TopViewCamera.transform.position = ResetPoint.position;
        }
    }
}
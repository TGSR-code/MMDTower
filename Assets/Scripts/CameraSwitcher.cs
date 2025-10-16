using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [Header("Cameras")]
    [SerializeField] Camera MainCamera;
    [SerializeField] Camera TopViewCamera;

    [Header("Settings")]
    [SerializeField] KeyCode SwitchKey = KeyCode.Tab;
    [SerializeField] KeyCode ResetKey = KeyCode.R;
    [SerializeField] float TopViewSpeed = 8f;
    [SerializeField] Transform ResetPoint;

    [SerializeField] PlayerMovement playerMovement;

    bool mainActive = true;
    Rigidbody topRb;
    Rigidbody playerRb;
    Vector3 topInput;

    void Start()
    {
        MainCamera?.gameObject.SetActive(true);
        TopViewCamera?.gameObject.SetActive(false);

        if (playerMovement == null)
            playerMovement = FindAnyObjectByType<PlayerMovement>();

        playerRb = playerMovement?.GetComponent<Rigidbody>();

        if (TopViewCamera != null)
        {
            topRb = TopViewCamera.GetComponent<Rigidbody>() ?? TopViewCamera.gameObject.AddComponent<Rigidbody>();
            topRb.useGravity = false;
            topRb.constraints = RigidbodyConstraints.FreezeRotation;
            topRb.interpolation = RigidbodyInterpolation.Interpolate;
            topRb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(SwitchKey))
        {
            mainActive = !mainActive;
            MainCamera?.gameObject.SetActive(mainActive);
            TopViewCamera?.gameObject.SetActive(!mainActive);

            if (playerMovement != null)
            {
                playerMovement.enabled = mainActive;
                if (!mainActive && playerRb != null)
                {
                    playerRb.linearVelocity = Vector3.zero;
                    playerRb.angularVelocity = Vector3.zero;
                }
            }
        }

        if (!mainActive && topRb != null)
        {
            topInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            if (Input.GetKeyDown(ResetKey) && ResetPoint != null)
            {
                topRb.position = ResetPoint.position;
                topRb.linearVelocity = Vector3.zero;
                topRb.angularVelocity = Vector3.zero;
            }
        }
        else topInput = Vector3.zero;
    }

    void FixedUpdate()
    {
        if (!mainActive && topRb != null && topInput.sqrMagnitude > 0f)
            topRb.MovePosition(topRb.position + topInput.normalized * TopViewSpeed * Time.fixedDeltaTime);
    }
}